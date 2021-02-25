import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { CreateTodoComponent } from "../create-todo/create-todo.component";
import { Todo, TodoService } from "../todo-service.service";

@Component({
  selector: "app-todo-list",
  templateUrl: "./todo-list.component.html",
  styleUrls: ["./todo-list.component.css"],
})
export class TodoListComponent implements OnInit {
  public includeDone = false;
  public search = "";

  constructor(public todoService: TodoService, private dialog: MatDialog) {}

  ngOnInit(): void {}

  public updateFilters() {
    this.todoService._filters.next({
      search: this.search,
      includeDone: this.includeDone,
    });
  }

  openTodoModal() {
    this.dialog.open(CreateTodoComponent);
  }
}
