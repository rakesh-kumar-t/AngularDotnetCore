import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Department } from 'src/app/models/Department';
import { environment } from 'src/environments/environment';
import { GenericService } from '../genericService/generic.service';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService extends GenericService<Department, number> {
  constructor(private httpClient: HttpClient) {
    super(httpClient, `${environment.APIUrl}/Department`);
  }
}
