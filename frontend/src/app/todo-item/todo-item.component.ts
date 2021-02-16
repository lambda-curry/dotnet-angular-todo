import { Component, Input, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { Todo } from "../todo-service.service";

@Component({
  selector: "todo",
  templateUrl: "./todo-item.component.html",
  styleUrls: ["./todo-item.component.css"],
})
export class TodoItemComponent implements OnInit {
  constructor(public dialog: MatDialog) {}

  @Input() public todo: Todo;
  public editing = false;
  public _title = "";

  ngOnInit(): void {}

  public toggleEdit() {
    this.editing = !this.editing;
    this._title = this.todo.title;
  }

  public update(done: boolean) {
    this.editing = false;
    this._title = "";
    //TODO: no pun intended. Wire this up to API using TodoService.
  }

  public delete() {
    //TODO: no pun intended. Wire this up to API using TodoService.
  }

  public openCreate() {
    // TODO: Consider using a dialog to create a modal to collect the name of todo.
    // this.dialog.open(CreateTodoComponent, {
    // });
  }

  public create(title: string) {}
}
