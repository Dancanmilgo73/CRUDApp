import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../interfaces/Todo';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private apiUrl = 'http://localhost:7100/api';

  constructor(private http: HttpClient) { }

  getTodos(): Observable<Todo[]> {
    return this.http.get<Todo[]>(`${this.apiUrl}/todos`);
  }

  addTodo(todo: Todo): Observable<Todo> {
    return this.http.post(`${this.apiUrl}/todo`, todo);
  }

  getFactorials(): Observable<Todo[]> {
    return this.http.get<Todo[]>(`${this.apiUrl}/factorial`);
  }
}
