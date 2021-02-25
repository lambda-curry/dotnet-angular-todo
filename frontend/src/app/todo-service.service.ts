import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { _getOptionScrollPosition } from "@angular/material/core";
import { BehaviorSubject, Observable } from "rxjs";
import { debounceTime, map, switchMap, take, tap } from "rxjs/operators";
import { environment } from "src/environments/environment";

export interface Todo {
  id: number;
  title: string;
  done: boolean;
  createdDate: Date | string;
}

@Injectable({
  providedIn: "root",
})
export class TodoService {
  public _todos = new BehaviorSubject(null);
  public todos$ = this._todos.asObservable();

  public _filters = new BehaviorSubject({ search: "", includeDone: false });

  constructor(public http: HttpClient) {
    this.refreshTodos$().subscribe();
    this._filters
      .pipe(
        debounceTime(100),
        switchMap(() => this.refreshTodos$())
      )
      .subscribe();
  }

  public updateFilters(filters: { search: string; includeDone: boolean }) {
    this._filters.next(filters);
  }

  refreshTodos$(): Observable<Todo[]> {
    return this._filters.pipe(
      take(1),
      switchMap((filters) => this.fetchTodos$(filters)),
      tap((todos) => this._todos.next(todos))
    );
  }

  fetchTodos$({
    search,
    includeDone,
  }: {
    search: string;
    includeDone: boolean;
  }): Observable<Todo[]> {
    return this.http
      .get(
        `${environment.url}/api/Todo?search=${search}&includeDone=${includeDone}`
      )
      .pipe(map((r: any) => r.data));
  }

  createTodo$(title: string): Observable<Todo> {
    return this.http.post(`${environment.url}/api/Todo`, {
      title,
    }) as Observable<Todo>;
  }

  updateTodo$(todo: Todo): Observable<Todo> {
    return this.http.put(`${environment.url}/api/Todo`, {
      ...todo,
    }) as Observable<Todo>;
  }

  deleteTodo$(id: number): Observable<number> {
    return this.http.delete(
      `${environment.url}/api/Todo/?id=${id}`
    ) as Observable<number>;
  }
}
