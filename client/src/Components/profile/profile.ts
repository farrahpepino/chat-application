import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-profile',
  imports: [CommonModule],
  templateUrl: './profile.html',
  styleUrl: './profile.css'
})
export class Profile {
  confirmAlertOpened = false;
  
  showConfirmAlert(){
    this.confirmAlertOpened = true;
  }
  hideConfirmAlert(){
    this.confirmAlertOpened = false;
  }
}
