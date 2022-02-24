import { Department } from "./Department";

export interface Employee{
    EmployeeId:Number;
    EmployeeName:string;
    DepartmentId:Number;
    DateOfJoining:string;
    PhotoFileName:string;
    Department?:Department;
}