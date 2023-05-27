import { Component, Input, OnInit } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';

import { StudentService } from 'src/app/services/student.service';
import { MatDialog } from '@angular/material/dialog';
import { StudentComponent } from '../student/student.component';


@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})

export class StudentsComponent implements OnInit {

  constructor(private _studentService: StudentService, private _modal: MatDialog) { }

  displayedColumns: string[] = ['id', 'name1', 'name2', 'lastname1', 'lastname2', 'email', 'courses'];
  dataSource !: MatTableDataSource<any>;

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit(): void {
    this.getStudentsList();
  }

  getStudentsList(){
    this._studentService.getStudentsList().subscribe({
      next:(res)=>{
        this.dataSource = new MatTableDataSource(res.result);
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }


  openModal(data:any){
      const modal = this._modal.open(StudentComponent,{
        width:'1500px',
        data
      });

    //Una vez se cierra la modal, trae nuevamente las personas 
    modal.afterClosed().subscribe({
      next:(val)=>{
        if(val){
          this.getStudentsList();
        }
      }
    });
  }
}
