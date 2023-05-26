import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private _http:HttpClient) { }

  getCoursesList(): Observable<any>{
    return this._http.get('https://localhost:44344/api/Courses');
  }
}