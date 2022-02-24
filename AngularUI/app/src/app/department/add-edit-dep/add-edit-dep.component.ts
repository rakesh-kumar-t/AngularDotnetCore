import { Component, Input, OnInit } from '@angular/core';
import { Department } from 'src/app/models/Department';
import { SharedapiService } from 'src/app/services/sharedapi.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private service:SharedapiService) { }

  @Input() dep:Department;
  DepartmentId:Number;
  DepartmentName:string;

  ngOnInit(): void {
    this.DepartmentId=this.dep.DepartmentId;
    this.DepartmentName=this.dep.DepartmentName;
  }

  addDepartment(){
    var val:Department={
      DepartmentId:this.DepartmentId,
      DepartmentName:this.DepartmentName
    };

    this.service.addDepartment(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateDepartment(){
    var val:Department={
      DepartmentId:this.DepartmentId,
      DepartmentName:this.DepartmentName
    };

    this.service.updateDepartment(val).subscribe(res=>{
      alert(res.toString());
    });
  }

}
