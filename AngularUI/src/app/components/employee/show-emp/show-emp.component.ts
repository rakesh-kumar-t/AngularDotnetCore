import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { Employee } from 'src/app/models/Employee';
import { EmployeeService } from 'src/app/services/employee/employee.service';
import { AddEditEmpComponent } from '../add-edit-emp/add-edit-emp.component';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css'],
})
export class ShowEmpComponent implements OnInit, AfterViewInit {
  constructor(
    private empService: EmployeeService,
    private toastr: ToastrService,
    private dialog: MatDialog
  ) {
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshEmpList();
    });
  }

  displayedColumns: string[] = [
    'EmployeeId',
    'EmployeeName',
    'DepartmentId',
    'DateOfJoining',
    'action',
  ];
  dataSource = new MatTableDataSource<Employee>();

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  EmployeeList: Employee[] = [];
  ModalTitle: string;
  ActivateAddEditEmpComp: boolean = false;
  emp: Employee;
  updateClicked: boolean = false;

  ngOnInit(): void {
    this.refreshEmpList();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  addEmployee() {
    this.updateClicked = false;
    this.dialog.open(AddEditEmpComponent, {
      data: [null, this.updateClicked],
    });
  }

  editEmployee(item: Employee) {
    this.updateClicked = true;
    this.dialog.open(AddEditEmpComponent, {
      data: [item, this.updateClicked],
    });
  }

  deleteEmployee(item: Employee) {
    if (confirm('Are You Sure??')) {
      this.empService.delete(item.EmployeeId).subscribe({
        next: (res) => {
          this.toastr.info('Employee Deleted!', 'Delete Employee');
          this.refreshEmpList();
        },
      });
    }
  }

  closeClick() {
    this.ActivateAddEditEmpComp = false;
    this.refreshEmpList();
  }

  refreshEmpList() {
    this.empService.getAll().subscribe({
      next: (res) => {
        this.EmployeeList = res;
        this.dataSource.data = res;
      },
      error: (err) => {
        console.log(err);
        this.toastr.error('Error Fetching data', 'EmployeeList');
      },
    });
  }
}
