import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private _http:HttpClient) { }

  getCourse(course:number): Observable<any>{
    return this._http.get(`https://localhost:44344/api/Courses/${course}`);
  }
  
  getCoursesList(): Observable<any>{
    return this._http.get('https://localhost:44344/api/Courses');
  }

  getCourseDetail(id:number): Observable<any>{
    return this._http.get(`https://localhost:44344/api/CourseDetails/${id}`);
  }

  getCourseDetailList(): Observable<any>{
    return this._http.get(`https://localhost:44344/api/CourseDetails/`);
  }

  getAssignedCoursesList(student:number): Observable<any>{
    return this._http.get(`https://localhost:44344/api/CourseDetails/student/${student}`);
  }

  createCourseDetail(courseDetail:any): Observable<any>{
    return this._http.post(`https://localhost:44344/api/CourseDetails/`, courseDetail);
  }

  deleteCourseDetail(courseDetail:number): Observable<any>{
    return this._http.delete(`https://localhost:44344/api/CourseDetails/${courseDetail}`);
  }


}