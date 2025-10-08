import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from '../navbar/navbar';
import { ChatList } from '../chat-list/chat-list';
import { ChatRoom } from '../chat-room/chat-room';
import { Profile } from '../profile/profile';
import { Login } from '../Auth/login/login';
import { Register } from '../Auth/register/register';

@Component({
  selector: 'app-hero',
  imports: [RouterOutlet, Navbar, ChatList, ChatRoom, Profile, Login, Register],
  templateUrl: './hero.html',
  styleUrl: './hero.css'
})
export class Hero {

}
