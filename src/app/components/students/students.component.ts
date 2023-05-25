import { Component, OnInit } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

import { StudentService } from 'src/app/services/student.service';
import { PersonService } from 'src/app/services/person.service';
import { MatDialog } from '@angular/material/dialog';
import { StudentComponent } from '../student/student.component';

export interface PeriodicElement {
  id: number;
  name1: string;
  name2: string;
  lastname1: string;
  lastname2: string;
  email: string;
  tuition: string;
  courses: string;
}

/*
const ELEMENT_DATA: PeriodicElement[] = [
  {id: 1, name1: "Julio", name2: 'Yosimar', lastname1: 'Valencia', lastname2: 'Ortega', email:'correo'},
  {id: 1, name1: "Julio", name2: 'Yosimar', lastname1: 'Valencia', lastname2: 'Ortega', email:'correo'},
  {id: 1, name1: "Julio", name2: 'Yosimar', lastname1: 'Valencia', lastname2: 'Ortega', email:'correo'},
  {id: 1, name1: "Julio", name2: 'Yosimar', lastname1: 'Valencia', lastname2: 'Ortega', email:'correo'},
];
*/
@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  constructor(private _studentService: StudentService, private _personService: PersonService, private _modal: MatDialog) { }

  displayedColumns: string[] = ['id', 'name1', 'name2', 'lastname1', 'lastname2', 'email', 'tuition', 'courses'];
  dataSource !: MatTableDataSource<any>;

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit(): void {
    this.getPeopleList();
  }

  getPeopleList(){
    this._studentService.getPeopleList().subscribe({
      next:(res)=>{

        res.result.forEach((student:any) => {
          console.log(this._personService.getPeopleList(student.id).subscribe({
            next:(res)=>{
              console.log(res.result);
            }
          }));

        });
        //console.log(res.result);
        
        this.dataSource = new MatTableDataSource(res.result);
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }


  openModal(student:number){
    //Abre la modal y le cambia el tamaño predeterminado
    const modal = this._modal.open(StudentComponent,{
        width: '800px'
      });

    //Una vez se cierra la modal, trae nuevamente las personas 
    modal.afterClosed().subscribe({
      next:(val)=>{
        if(val){
          this.getPeopleList();
        }
      }
    });
  }
}
