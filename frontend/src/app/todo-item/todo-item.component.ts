import { Component, Input, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { switchMap } from "rxjs/operators";
import { Todo, TodoService } from "../todo-service.service";

@Component({
  selector: "todo",
  templateUrl: "./todo-item.component.html",
  styleUrls: ["./todo-item.component.css"],
})
export class TodoItemComponent implements OnInit {
  constructor(
    private snackbar: MatSnackBar,
    private todoService: TodoService
  ) {}

  @Input() public todo: Todo;
  public editing = false;
  public _title = "";

  ngOnInit(): void {}

  public toggleEdit() {
    this.editing = !this.editing;
    this._title = this.todo.title;
  }

  public update(updates: { title?: string; done?: boolean }) {
    this.editing = false;
    this._title = "";
    this.todoService
      .updateTodo$({ ...this.todo, ...updates })
      .pipe(switchMap((t) => this.todoService.refreshTodos$()))
      .subscribe();
  }

  public delete() {
    this.todoService
      .deleteTodo$(this.todo.id)
      .pipe(switchMap((t) => this.todoService.refreshTodos$()))
      .subscribe();
  }
}
