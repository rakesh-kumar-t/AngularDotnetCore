import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/models/Employee';
import { environment } from 'src/environments/environment';
import { GenericService } from '../genericService/generic.service';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService extends GenericService<Employee, number> {
  readonly PhotoUrl = 'https://localhost:5000/Photos/';
  constructor(private httpClient: HttpClient) {
    super(httpClient, `${environment.APIUrl}/Employee`);
  }
  getAllDepartmentNames(): Observable<any[]> {
    return this.httpClient.get<any[]>(`${environment.APIUrl}/Department`);
  }

  UploadPhoto(val: any) {
    return this.httpClient.post(`${environment.APIUrl}/Employee/SaveFile`, val);
  }
}
