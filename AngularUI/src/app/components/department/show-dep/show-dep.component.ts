import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Department } from 'src/app/models/Department';
import { MatDialog } from '@angular/material/dialog';
import { AddEditDepComponent } from '../add-edit-dep/add-edit-dep.component';
import { DepartmentService } from 'src/app/services/department/department.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css'],
})
export class ShowDepComponent implements OnInit, AfterViewInit {
  constructor(
    private depService: DepartmentService,
    private dialog: MatDialog
  ) {
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshDepList();
    });
  }

  displayedColumns: string[] = ['DepartmentId', 'DepartmentName', 'Options'];
  dataSource = new MatTableDataSource<Department>();

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  DepartmentList: Department[] = [];

  ModalTitle: string;
  ActivateAddEditDepComp: boolean = false;
  dep: Department;
  updateClicked: boolean = false;

  DepartmentIdFilter: string = '';
  DepartmentNameFilter: string = '';
  DepartmentListWithoutFilter: Department[] = [];

  ngOnInit(): void {
    this.refreshDepList();
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

  addDepartment() {
    this.updateClicked = false;
    this.dialog.open(AddEditDepComponent, {
      data: [this.dep, this.updateClicked],
    });
  }

  editClick(item: Department) {
    this.updateClicked = true;
    this.dialog.open(AddEditDepComponent, {
      data: [item, this.updateClicked],
    });
  }

  deleteClick(item: Department) {
    if (confirm('Are You Sure??')) {
      this.depService.delete(item.DepartmentId).subscribe((data) => {
        alert(data.toString());
        this.refreshDepList();
      });
    }
  }

  closeClick() {
    this.ActivateAddEditDepComp = false;
    this.refreshDepList();
  }

  refreshDepList() {
    this.depService.getAll().subscribe((data: Department[]) => {
      this.DepartmentList = data;
      this.DepartmentListWithoutFilter = data;
      this.dataSource.data = data;
    });
  }
}
