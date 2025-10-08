import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from '../Components/navbar/navbar';
import { ChatRoom } from '../Components/chat-room/chat-room';
import { ChatList } from '../Components/chat-list/chat-list';
import { Profile } from '../Components/profile/profile';
import { Login } from '../Components/Auth/login/login';
import { Register } from '../Components/Auth/register/register';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navbar, ChatList, ChatRoom, Profile, Login, Register],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('client');
}
