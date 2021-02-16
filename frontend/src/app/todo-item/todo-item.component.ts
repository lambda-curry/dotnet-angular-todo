import { Component, Input, OnInit } from "@angular/core";
import { Todo } from "../todo-service.service";

@Component({
  selector: "app-todo-item",
  templateUrl: "./todo-item.component.html",
  styleUrls: ["./todo-item.component.css"],
})
export class TodoItemComponent implements OnInit {
  constructor() {}

  @Input() public todo: Todo;

  ngOnInit(): void {}

  public update(done: boolean) {
    //TODO: no pun intended. Wire this up.
  }

  public delete() {
    //TODO: no pun intended. Wire this up.
  }
}
