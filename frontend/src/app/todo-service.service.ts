import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, tap } from "rxjs/operators";
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
export class TodoServiceService {
  constructor(public http: HttpClient) {}

  fetchTodos(): Observable<Todo[]> {
    return this.http.get(`${environment.url}/api/Todo`).pipe(
      tap((r) => console.log("response", r)),
      map((r: any) => r.data)
    );
  }
}
