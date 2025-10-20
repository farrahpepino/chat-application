import { Injectable, NgZone } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { MessageModel } from '../../Models/MessageModel';
@Injectable({
  providedIn: 'root'
})
export class Websocket {
  private socket?: WebSocket;
  private messageSubject = new Subject<any>();
  constructor(private ngZone: NgZone) {}

  connect(userId: string) {
    this.socket = new WebSocket(`ws://localhost:5007/ws/chat?userId=${userId}`);

    this.socket.onopen = () => console.log('Connected to WebSocket');
    this.socket.onmessage = (event) => {
      const data = JSON.parse(event.data);
    
      const message: MessageModel = {
        chatRoomId: data.chatRoomId || data.ChatRoomId,
        senderId: data.senderId || data.SenderId,
        recipientId: data.recipientId || data.RecipientId,
        content: data.content || data.Content,
        createdAt: data.createdAt || data.CreatedAt
      };

      this.messageSubject.next(message);


    };
    this.socket.onclose = () => console.log('WebSocket closed');
  }

  sendMessage(message: any) {
    if (this.socket?.readyState === WebSocket.OPEN) {
      this.socket.send(JSON.stringify(message));
    }
  }

  getMessages(): Observable<any> {
    return this.messageSubject.asObservable();
  }
  
}
