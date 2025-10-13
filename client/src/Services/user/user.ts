import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto } from '../../DTOs/UserDto';

@Injectable({
  providedIn: 'root'
})
export class User {
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
}
