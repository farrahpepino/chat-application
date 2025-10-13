import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { User } from '../../Services/user/user';
import { UserDto } from '../../DTOs/UserDto';

@Component({
  selector: 'app-profile',
  imports: [CommonModule],
  templateUrl: './profile.html',
  styleUrl: './profile.css'
})
export class Profile implements OnInit {
  constructor(private userService: User){}
  currentLoggedIn: UserDto | null = null; 
  ngOnInit(): void {
    this.currentLoggedIn = this.userService.getCurrentLoggedIn();
  }

  confirmAlertOpened = false;
  
  showConfirmAlert(){
    this.confirmAlertOpened = true;
  }
  hideConfirmAlert(){
    this.confirmAlertOpened = false;
  }
}
