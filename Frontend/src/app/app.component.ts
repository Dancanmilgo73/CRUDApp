import { Component } from '@angular/core';
import { TodoService } from '../core/service/todo.service';
import { Todo } from '../core/interfaces/Todo';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  todos: Todo[] = [];
  title = new FormControl('', Validators.required);
  description = new FormControl('');
  isLoading: boolean = false;
  todoForm = new FormGroup({
    title: this.title,
    description: this.description,
  })

  ngOnInit() {
    this.getTodos();
  }

  constructor(private todoService: TodoService) {
    
  }

  getTodos() {
    this.isLoading = true;
    this.todoService.getTodos().subscribe(res => {
      this.todos = res;
      this.isLoading = false;
    });
  }

  onSubmit() {
    if (this.todoForm.valid) {
    const values = this.todoForm.value;
    const todo: Todo = {
      title: values.title ?? '',
      description: values.description ?? '',
    };
    this.todoService.addTodo(todo).subscribe(() => {
      this.todoForm.reset();
      this.getTodos();
    });
  }
  }

  getFactorials() {
    this.todoService.getFactorials().subscribe((res) => {
      this.todos = res;
    });
  }
}
