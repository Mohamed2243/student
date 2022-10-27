import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  baseUrl = 'https://localhost:7230/swagger/index.html'

  constructor(private http: HttpClient) { }

  
  GetAllStudents(){
this.http.get('baseUrl');
  }
}
// Test 
