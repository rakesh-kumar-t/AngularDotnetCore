import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {

  constructor() { }

  @Input() emp:any;

  ngOnInit(): void {
  }

}
