import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ChatList } from '../chat-list/chat-list';
import { ChatRoom } from '../chat-room/chat-room';
import { Profile } from '../profile/profile';

@Component({
  selector: 'app-Home',
  imports: [CommonModule, RouterLink, ChatList, ChatRoom, Profile],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {
  componentSelected = "chats";
  createFormOpened = false;
  confirmAlertOpened = false;

  switchView(component: string){
    if (component=="profile"){
      this.componentSelected="profile"
    }
    else if(component=="chats"){
      this.componentSelected="chats"
    }
  }

  showCreateForm(){
    this.createFormOpened=true;
  }
  hideCreateForm(){
    this.createFormOpened=false;
  }

}
