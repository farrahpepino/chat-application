import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { UserDto } from '../../DTOs/UserDto';
interface Message{
  sender: string;
  receipient: string;
  content: string;
  createdAt: string;
}

@Component({
  selector: 'app-chat-room',
  imports: [CommonModule],
  templateUrl: './chat-room.html',
  styleUrl: './chat-room.css'
})
export class ChatRoom {
  recipient: UserDto | null = null;
  constructor(){
    const displayedUser = localStorage.getItem("displayedUser")
    if (displayedUser){
      this.recipient = JSON.parse(displayedUser);
    }
  }

  messages: Message[] | null = [];
}
