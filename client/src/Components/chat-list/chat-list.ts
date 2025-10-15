import { Component } from '@angular/core';
import { User } from '../../Services/user/user';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserModel } from '../../Models/UserModel';
@Component({
  selector: 'app-chat-list',
  imports: [FormsModule, CommonModule],
  templateUrl: './chat-list.html',
  styleUrl: './chat-list.css'
})
export class ChatList {
  constructor(private userService: User) {}
  isActive=true;
  query = '';
  results: UserModel[] = [];
  
// fix
  onSearch(): void {
    const trimmedQuery = this.query.trim();
    if (!trimmedQuery) {
      this.results = [];
      return;
    }

    this.userService.searchUser(trimmedQuery).subscribe({
      next: (data) => {
        this.results = data;
      },
      error: (err) => {
        console.error('Search failed:', err);
        this.results = [];
      }
    });
  }

  clickUser(user: UserModel){
    const displayedUser = localStorage.getItem("displayedUser");
    if(displayedUser){
      localStorage.removeItem("displayedUser");
    }
    localStorage.setItem("displayedUser", JSON.stringify(user));
  }
}
