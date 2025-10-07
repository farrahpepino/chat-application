import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from '../Components/navbar/navbar';
import { ChatRoom } from '../Components/chat-room/chat-room';
import { ChatList } from '../Components/chat-list/chat-list';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navbar, ChatList, ChatRoom],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('client');
}
