import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GenericServiceModel } from 'src/app/models/GenericServiceModel';

export class GenericService<T, ID> implements GenericServiceModel<T, ID> {
  constructor(private http: HttpClient, private baseUrl: string) {}

  add(t: T): Observable<any> {
    return this.http.post<T>(this.baseUrl, t);
  }

  update(t: T): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/`, t);
  }

  getById(id: ID): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${id}`);
  }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.baseUrl);
  }

  delete(id: ID): Observable<any> {
    return this.http.delete<T>(`${this.baseUrl}/${id}`);
  }
}
