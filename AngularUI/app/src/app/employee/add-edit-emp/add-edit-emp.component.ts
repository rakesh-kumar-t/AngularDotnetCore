import { Component, Input, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/Employee';
import { SharedapiService } from 'src/app/services/sharedapi.service';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {

  constructor(private service:SharedapiService) { }

  @Input() emp:Employee;
  EmployeeId:Number;
  EmployeeName:string;
  DepartmentId:Number;
  DateOfJoining:string;
  PhotoFileName:string;
  PhotoFilePath:string;

  //For Department names dropdown
  DepartmentsList:any=[];

  ngOnInit(): void {
    this.loadDepartmentsList();
  }

  loadDepartmentsList(){
    this.service.getAllDepartmentNames().subscribe((data:any)=>{
      this.DepartmentsList=data;
      
      this.EmployeeId=this.emp.EmployeeId;
      this.EmployeeName=this.emp.EmployeeName;
      this.DepartmentId=this.emp.DepartmentId;
      this.DateOfJoining=this.emp.DateOfJoining;
      this.PhotoFileName=this.emp.PhotoFileName;
      this.PhotoFilePath=this.service.PhotoUrl+this.PhotoFileName;
    })
  }

  addEmployee(){

    var val:Employee={
      EmployeeId:this.EmployeeId,
      EmployeeName:this.EmployeeName,
      DepartmentId:this.DepartmentId,
      DateOfJoining:this.DateOfJoining,
      PhotoFileName:this.PhotoFileName
    };

    this.service.addEmployee(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateEmployee(){
    var val:Employee={
      EmployeeId:this.EmployeeId,
      EmployeeName:this.EmployeeName,
      DepartmentId:this.DepartmentId,
      DateOfJoining:this.DateOfJoining,
      PhotoFileName:this.PhotoFileName
    };

    this.service.updateEmployee(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  uploadPhoto(event:any){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile',file,file.name);

    this.service.UploadPhoto(formData).subscribe((data:any)=>{
      this.PhotoFileName=data.toString();
      this.PhotoFilePath=this.service.PhotoUrl+this.PhotoFileName;
    })
  }

}
