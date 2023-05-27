import { Component, Input, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course.service';

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
  idCourse:number = 0;
  
  constructor( private _courseService: CourseService) { }

  ngOnInit(): void {
    this.getCourse(this.idCourseDetail);
    //console.log("Student->", this.studentId)
    //console.log(this.coursesList);
    //console.log(this.assignedCourses);
  }

  getCourse(id:number){

    this._courseService.getCourse(id).subscribe({
      next:(res) => {
        this.description =  res.result.description;
        //console.log(respuesta.result);
        
      },
    });
    
    // this._courseService.getCourseDetail(id).subscribe({
    //   next:(res) => {

    //     this.idCourse =  res.result.fkCourse;
    //     this._courseService.getCourse(this.idCourse).subscribe({
    //       next:(res) => {
    //         this.description =  res.result.description;
    //         //console.log(respuesta.result);
            
    //       },
    //     });

    //   },
    // });

    
  }

  assignedCourse(course:number){
    
    console.log("Curso-->",course, " Student-->", this.studentId);

    //console.log("student->", this.studentId, "  assignedList->",this.assignedCourses, "  coursesList->",this.coursesList);
    console.log(this.assignedCourses);
    
    const isAsignedCourse = this.assignedCourses.filter(e => e.fkCourse == course);
    //(isAsignedCourse.length > 0) ? console.log(`Este curso no se puede asignar`) : console.log("Assignado");
    if(isAsignedCourse.length > 0){
        //this._courseService.
    }



    
    // this._courseService.getAssignedCoursesList(this.studentId).subscribe({
    //   next:(res) => {
    //     this.assignedCourses =  res.result;
    //     console.log(res.result);
        
    //   },
    // });
    
    //const isAsigned = this.assignedCourses.filter(e => e.id = course);
    // if(isAsigned.length > 0){
    //   return console.log("Error Assigned->", course);
    // }
    
    // return console.log("Assigned->", course);

  }

  unAssignedCourse(courseDetail:number){
    //console.log("student->", this.studentId, "  assignedList->",this.assignedCourses, "  coursesList->",this.coursesList);
    // console.log("unAssigned->", courseDetail);
    // console.log(courseDetail);

    this._courseService.deleteCourseDetail(courseDetail).subscribe({
      next:(res) => {
        this.assignedCourses =  res.result;
        console.log(res.result);
      },
    });
    
  }

}
