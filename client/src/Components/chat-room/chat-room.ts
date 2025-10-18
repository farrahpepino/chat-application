import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { v4 as uuidv4 } from 'uuid';
import { UserDto } from '../../DTOs/UserDto';
import { Websocket } from '../../Services/websocket/websocket';
import { User } from '../../Services/user/user';
import { Chat } from '../../Services/chat/chat';
import { MessageModel } from '../../Models/MessageModel';
import { firstValueFrom } from 'rxjs';


@Component({
  selector: 'app-chat-room',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './chat-room.html',
  styleUrl: './chat-room.css'
})
export class ChatRoom implements OnInit {
  constructor(
    private websocketService: Websocket,
    private userService: User,
    private chatService: Chat
  ) {
    const displayedUser = localStorage.getItem("displayedUser");
    if (displayedUser) {
      this.recipient = JSON.parse(displayedUser);
    }
  }

  recipient: UserDto | null = null;
  currentLoggedIn: UserDto | null = null;
  messages: MessageModel[] = [];
  roomId: string | null = null;

  messageForm = new FormGroup({
    content: new FormControl('')
  });

  ngOnInit() {
    this.currentLoggedIn = this.userService.getCurrentLoggedIn();
    if (this.currentLoggedIn) {
      this.websocketService.connect(this.currentLoggedIn.id);
    }
  }

  async sendMessage(receipientId: string) {
    if (!this.currentLoggedIn || !this.recipient) return;

    const participantId1 = this.currentLoggedIn.id;
    const participantId2 = receipientId;
    this.roomId = await firstValueFrom(
      this.chatService.getChatRoomId(participantId1, participantId2)
    );
    
    if (this.roomId==null) {
      this.roomId = uuidv4().toString();
      this.chatService.createChatRoomId(this.roomId, participantId1, participantId2)
    }

    const message: MessageModel = {
      chatRoomId: this.roomId,
      senderId: participantId1,
      recipientId: participantId2,
      content: this.messageForm.value.content!,
    };

    this.chatService.sendMessage(message);
    // this.messages.push(message);

    this.messageForm.reset();
  }
}
