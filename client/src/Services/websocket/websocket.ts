import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Websocket {
  private socket?: WebSocket;

  connect(userId: string) {
    this.socket = new WebSocket(`wss://localhost:5007/ws/chat?userId=${userId}`);

    this.socket.onopen = () => console.log('Connected to WebSocket');
    this.socket.onmessage = (event) => {
      const message = JSON.parse(event.data);
      console.log('New message:', message);
    };
    this.socket.onclose = () => console.log('WebSocket closed');
  }

  sendMessage(message: any) {
    if (this.socket?.readyState === WebSocket.OPEN) {
      this.socket.send(JSON.stringify(message));
    }
  }
}
