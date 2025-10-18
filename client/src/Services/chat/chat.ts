import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MessageModel } from '../../Models/MessageModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Chat {
  private baseUrl = 'https://localhost:5007/chat'; 
  constructor(private http: HttpClient) {}

  getChatRoomId(participantId1: string, participantId2: string): Observable<string>{
    var roomId = this.http.get<string>(`${this.baseUrl}`, {
      params: {
        participantId1: participantId1,
        participantId2: participantId2
      }
    });
    return roomId;
  }

  createChatRoomId(id: string, participantId1: string, participantId2: string) {
    return this.http.post<void>(`${this.baseUrl}/rooms`, {
      id,
      participants: [participantId1, participantId2]
    });
  }

  sendMessage(message: MessageModel) {
    return this.http.post(`${this.baseUrl}/messages`, message);
  }

  getMessages(){
    
  }
}
