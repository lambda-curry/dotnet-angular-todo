import { Component, Input, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Todo } from "../todo-service.service";

@Component({
  selector: "todo",
  templateUrl: "./todo-item.component.html",
  styleUrls: ["./todo-item.component.css"],
})
export class TodoItemComponent implements OnInit {
  constructor(private dialog: MatDialog, private snackbar: MatSnackBar) {}

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
    this.implementWarningSnackbar();

    //TODO: no pun intended. Wire this up to API using TodoService.
  }

  public delete() {
    this.implementWarningSnackbar();
    //TODO: no pun intended. Wire this up to API using TodoService.
  }

  public openCreate() {
    // TODO: Consider using a dialog to create a modal to collect the name of todo.
    // this.dialog.open(CreateTodoComponent, {
    // });
  }

  public create(title: string) {}

  private implementWarningSnackbar() {
    this.snackbar.open("You need to implement this!", "", {
      panelClass: ["mat-toolbar", "mat-warn"],
    });
  }
}
