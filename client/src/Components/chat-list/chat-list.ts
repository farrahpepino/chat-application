import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { User } from '../../Services/user/user';
import { UserDto } from '../../DTOs/UserDto';
import { Chat } from '../../Services/chat/chat';
import { ChatListDto } from '../../DTOs/ChatListDto';

@Component({
  selector: 'app-chat-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './chat-list.html',
  styleUrls: ['./chat-list.css']
})
export class ChatList implements OnInit{
  constructor(private userService: User, private chatService: Chat) {}
  currentLoggedIn: UserDto | null = null;

  @Output() userSelected = new EventEmitter<UserDto>();
  selectedUser: UserDto | null = null;

  isActive = true;
  query = '';
  results: UserDto[] = [];
  chatlist: ChatListDto[] = [];

  ngOnInit(): void {
    this.currentLoggedIn = this.userService.getCurrentLoggedIn();
    
    if (!this.currentLoggedIn) return;
  
    this.chatService.getChatList(this.currentLoggedIn.id).subscribe({
      next: (data) => {
        this.chatlist = data;
        console.log(data);
      },
      error: (err) => {
        console.error('Failed to load chat list:', err);
        this.chatlist = [];
      }
    });
  }
  
  onSearch(): void {
    const trimmedQuery = this.query.trim();
    if (!trimmedQuery) {
      this.results = [];
      return;
    }

    this.userService.searchUser(trimmedQuery).subscribe({
      next: (data) => (this.results = data),
      error: (err) => {
        console.error('Search failed:', err);
        this.results = [];
      }
    });
  }

  selectChat(userId: string) {
    this.userService.getUser(userId).subscribe({
      next: (user) => {
        this.clickUser(user);
      },
      error: (err) => {
        console.error('Failed to fetch user:', err);
      }
    });

  }
  

  clickUser(user: UserDto): void {
    this.selectedUser = user; 
    this.userSelected.emit(user);
  }
}
