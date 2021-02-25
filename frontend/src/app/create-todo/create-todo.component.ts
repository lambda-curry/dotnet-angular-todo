import { Component, OnInit } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { switchMap } from "rxjs/operators";
import { TodoService } from "../todo-service.service";

@Component({
  selector: "app-create-todo",
  templateUrl: "./create-todo.component.html",
  styleUrls: ["./create-todo.component.css"],
})
export class CreateTodoComponent implements OnInit {
  constructor(
    private todoService: TodoService,
    public dialogRef: MatDialogRef<CreateTodoComponent>
  ) {}

  public title = "";

  ngOnInit(): void {}

  create() {
    this.todoService
      .createTodo$(this.title)
      .pipe(switchMap((todo) => this.todoService.refreshTodos$()))
      .subscribe(() => this.dialogRef.close());
  }
}
