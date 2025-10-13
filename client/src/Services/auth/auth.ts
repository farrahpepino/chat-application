import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDto } from '../../DTOs/UserDto';
import { UserModel } from '../../Models/UserModel';
import { LoginDto } from '../../DTOs/LoginDto';
@Injectable({
  providedIn: 'root'
})
export class Auth {
  constructor (private http: HttpClient){}
  apiUrl = "http://localhost:5007/auth";

  registerUser(user: UserModel): Observable<UserDto>{
    return this.http.post<UserDto>(`${this.apiUrl}/register`, user);
  }

  loginUser(user: LoginDto): Observable<UserDto>{
    return this.http.post<UserDto>(`${this.apiUrl}/login`, user);
  }
}
