import { Component, Inject, Input, OnInit } from '@angular/core';
import { Department } from 'src/app/models/Department';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { DepartmentService } from 'src/app/services/department/department.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css'],
})
export class AddEditDepComponent {
  addDepartmentForm: FormGroup;
  constructor(
    private depService: DepartmentService,
    private toastr: ToastrService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<AddEditDepComponent>,
    @Inject(MAT_DIALOG_DATA) public data: [Department, boolean]
  ) {
    this.addDepartmentForm = this.fb.group({
      DepartmentId: new FormControl(
        this.data[0] == null ? 0 : this.data[0].DepartmentId,
        Validators.required
      ),
      DepartmentName: new FormControl(
        this.data[0] == null ? null : this.data[0].DepartmentName,
        Validators.required
      ),
    });
  }

  updateClicked: boolean = this.data[1];

  addDepartment() {
    this.depService.add(this.addDepartmentForm.value).subscribe({
      next: (res) => {
        this.toastr.success('Added Successfully', 'Add New Department');
        this.CloseDialog();
      },
      error: (err) => {
        console.log(err);
        this.toastr.error('Error adding Department', 'Add new department');
      },
    });
  }

  CloseDialog() {
    this.dialogRef.close();
  }

  updateDepartment(department: Department) {
    this.depService.update(department).subscribe({
      next: (res) => {
        this.toastr.success('Department Updated!', 'Update Department');
        this.CloseDialog();
      },
      error: (err) => {
        console.log(err);
        this.toastr.error('Error updating Department', 'Update Department');
      },
    });
  }
}
