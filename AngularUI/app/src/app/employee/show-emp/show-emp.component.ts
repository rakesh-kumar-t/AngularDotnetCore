import { Component, OnInit,AfterViewInit,ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from 'src/app/models/Employee';
import { SharedapiService } from 'src/app/services/sharedapi.service';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit,AfterViewInit {

  displayedColumns:string[]=['EmployeeId',	'EmployeeName',	'DepartmentId',	'DateOfJoining','action'];
  dataSource = new MatTableDataSource<Employee>();
  
  @ViewChild(MatPaginator) paginator:MatPaginator;
  @ViewChild(MatSort) sort:MatSort;

  EmployeeList:Employee[]=[];
  ModalTitle:string;
  ActivateAddEditEmpComp:boolean=false;
  emp:Employee;
  
  
  ngOnInit(): void {
    this.refreshEmpList();
  }

  constructor(private service:SharedapiService) { 
  }

  ngAfterViewInit(): void {
      this.dataSource.paginator=this.paginator;
      this.dataSource.sort=this.sort;
  }

  applyFilter(event:Event){
    const filterValue=(event.target as HTMLInputElement).value;
    this.dataSource.filter=filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

  addClick(){
    this.emp={
      EmployeeId:0,
      EmployeeName:"",
      DepartmentId:1,
      DateOfJoining:"",
      PhotoFileName:"anonymus.png"
    }
    this.ModalTitle="Add Employee";
    this.ActivateAddEditEmpComp=true;
  } 

  editClick(item:Employee){
    this.emp=item;
    this.ModalTitle="Edit Employee";
    this.ActivateAddEditEmpComp=true;
  }

  deleteClick(item:Employee){
    if(confirm("Are You Sure??")){
      this.service.deleteEmployee(item.EmployeeId).subscribe(data=>{
        alert(data.toString());
        this.refreshEmpList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditEmpComp=false;
    this.refreshEmpList();
  }

  refreshEmpList(){
    this.service.getEmpList().subscribe(data=>{
      this.EmployeeList=data;
      console.log(data)
      this.dataSource.data=data;
    })
  }

}
