import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private _http:HttpClient) { }

  getPeopleList(): Observable<any>{
    return this._http.get('https://localhost:44344/api/Students');
  }
}
