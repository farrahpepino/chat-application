import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto } from '../../DTOs/UserDto';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class User {
  constructor(private http: HttpClient){}
  baseUrl = "http://localhost:5007/user";

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

  searchUser(query: string): Observable<UserDto[]> {
    if (!query.trim()) {
      throw new Error('Query cannot be empty');
    }
  
    const encodedQuery = encodeURIComponent(query.trim());
    return this.http.get<UserDto[]>(`${this.baseUrl}/search/${encodedQuery}`);
  }


  getUser(userId: string): Observable<UserDto>{
    return this.http.get<UserDto>(`${this.baseUrl}/${userId}`);
  }

  deleteUser(userId: string): Observable<any>{
    return this.http.delete<any>(`${this.baseUrl}/${userId}`);
  }
}
