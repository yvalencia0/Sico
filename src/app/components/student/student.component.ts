import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CourseService } from 'src/app/services/course.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  studentForm: FormGroup;
  courses:any[] = [];
  assignedCourses:any[] = [];
  
  


  constructor(
    private _courseService: CourseService,
    private _fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public student:any) {

      this.studentForm = this._fb.group({
        id:new FormControl(),
        name1:new FormControl(),
        name2:new FormControl(),
        lastname1:new FormControl(),
        lastname2:new FormControl(),
        email:new FormControl()
      });
  }


    
  ngOnInit(): void {
    this.studentForm.patchValue(this.student);
    this.getStudent();
    this.getCourses();
    this.getAssignedCoursesList(this.student.id);
  }

  getStudent(){
    
  }

  getCourses(){
    this._courseService.getCoursesList().subscribe({
      next:(res) => {
        this.courses =  res.result;
      },
    });
  }

  getAssignedCoursesList(student:number){
    this._courseService.getAssignedCoursesList(student).subscribe({
      next:(res) => {
        this.assignedCourses =  res.result;
      },
    });

  }
}
