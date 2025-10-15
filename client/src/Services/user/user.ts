import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto } from '../../DTOs/UserDto';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../../Models/UserModel';
@Injectable({
  providedIn: 'root'
})
export class User {
  constructor(private http: HttpClient){}
  apiUrl = "http://localhost:5007/user";

  getCurrentLoggedIn(): UserDto | null{
    const data = sessionStorage.getItem("currentLoggedIn");
    if (data) {
      try {
        return JSON.parse(data) as UserDto;
      } catch (e) {
        console.error("Error parsing user data from sessionStorage:", e);
        return null;
      }
    }
    return null;  
  }

  searchUser(query: string): Observable<UserModel[]> {
    if (!query.trim()) {
      throw new Error('Query cannot be empty');
    }
  
    const encodedQuery = encodeURIComponent(query.trim());
    return this.http.get<UserModel[]>(`${this.apiUrl}/search/${encodedQuery}`);
  }
  
  
}
