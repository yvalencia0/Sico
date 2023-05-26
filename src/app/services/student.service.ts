import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private _http:HttpClient) { }

  getStudentsList(): Observable<any>{
    return this._http.get('https://localhost:44344/api/Students');
  }

  getStudent(id:number): Observable<any>{
    return this._http.get(`https://localhost:44344/api/Students/${id}`);
  }
}