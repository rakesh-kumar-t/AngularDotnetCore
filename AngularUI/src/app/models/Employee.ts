import { Department } from './Department';

export interface Employee {
  EmployeeId: number;
  EmployeeName: string;
  DepartmentId: number;
  DateOfJoining: string;
  PhotoFileName: string;
  Department?: Department;
}
