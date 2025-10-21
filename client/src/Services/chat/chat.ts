import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MessageModel } from '../../Models/MessageModel';
import { Observable } from 'rxjs';
import { ChatListDto } from '../../DTOs/ChatListDto';

@Injectable({
  providedIn: 'root'
})
export class Chat {
  private baseUrl = '/chat'; 
  constructor(private http: HttpClient) {}

  getChatRoomId(participantId1: string, participantId2: string): Observable<string>{
    var roomId = this.http.get<string>(`${this.baseUrl}`, {
      params: {
        participantId1: participantId1,
        participantId2: participantId2
      },
    });
    return roomId;
  }

  createChatRoomId(id: string, participantId1: string, participantId2: string) {
    if (participantId1 == participantId2){
      return this.http.post<void>(`${this.baseUrl}/rooms`, {
        id,
        participants: [participantId1]
      });
    }
    else{
      return this.http.post<void>(`${this.baseUrl}/rooms`, {
        id,
        participants: [participantId1, participantId2]
      });
    }

  }

  sendMessage(message: MessageModel) {  
    return this.http.post(`${this.baseUrl}/messages`, 
      {
        chatRoomId:  message.chatRoomId!,
        senderId: message.senderId,
        recipientId: message.recipientId,
        content: message.content
     
    });
  }

  getMessages(roomId: string): Observable<MessageModel[]>{
      return this.http.get<MessageModel[]>(`${this.baseUrl}/${roomId}/messages`)
    }

  getChatList(userId: string): Observable<ChatListDto[]>{
    return this.http.get<ChatListDto[]>(`${this.baseUrl}/${userId}/chats`);
  }
}
