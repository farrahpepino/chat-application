import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ChatList } from '../chat-list/chat-list';
import { ChatRoom } from '../chat-room/chat-room';
import { Profile } from '../profile/profile';
import { UserDto } from '../../DTOs/UserDto';

@Component({
  selector: 'app-Home',
  imports: [CommonModule, ChatList, ChatRoom, Profile],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {
  constructor(private router: Router){}
  componentSelected = "chats";
  createFormOpened = false;
  confirmAlertOpened = false;
  emptyRecipient = true;

  selectedUser: UserDto | null = null;

  onUserSelected(user: UserDto) {
    this.selectedUser = user;
  }
  

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

  logout(){
    sessionStorage.clear();
    this.router.navigate(['/']);
  }

}
