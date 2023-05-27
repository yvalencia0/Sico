import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CourseService } from 'src/app/services/course.service';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  @Input() idCourseDetail:number = 0;
  @Input() isAsigned:boolean = false;
  @Input() studentId:number = 0;
  @Input() assignedCourses:any[] = [];
  @Input() coursesList:any[] = [];

  description: string = "";
  teacher: string = "";
  idCourse:number = 0;
  idNewCourseDetails:number = 0;
  courseDetailList:any[] = [];


  constructor( private _courseService: CourseService, private _personService: PersonService, private _modal: MatDialog) { }

  ngOnInit(): void {
    this.getCourse(this.idCourseDetail);
  }

  getCourse(id:number){

    this._courseService.getCourse(id).subscribe({
      next:(res) => {
        this.description =  res.result.description;

        this._personService.getPeopleList(res.result.fkTeacher).subscribe({
          next:(res) => {
            this.teacher =  `${res.result.name1}  ${res.result.lastname1}`;
          },
        });
      },
    });
    
  }

  assignedCourse(course:number){
    
    const isAsignedCourse = this.assignedCourses.filter(e => e.fkCourse == course);
    (isAsignedCourse.length > 0) ? console.log(`Este curso no se puede asignar`) : console.log("Assignado");
    
    if(isAsignedCourse.length < 1){

      this._courseService.getCourseDetailList().subscribe({
        next:(res) => {
          this.courseDetailList = res.result;
          this.idNewCourseDetails = (this.courseDetailList[this.courseDetailList.length-1].id) + 1;

          const newCourseDetail = {
            id: this.idNewCourseDetails,
            fkCourse: course,
            fkStudent: this.studentId
          };
          
          this._courseService.createCourseDetail(newCourseDetail).subscribe();
        },
      });
      
    }

    this._modal.closeAll();

  }

  unAssignedCourse(courseDetail:number){
    
    const courseDetailId = this.assignedCourses.filter(e => e.fkCourse == courseDetail);
    
    this._courseService.deleteCourseDetail(courseDetailId[0].id).subscribe();
    
    this._modal.closeAll();
  }
  
}
