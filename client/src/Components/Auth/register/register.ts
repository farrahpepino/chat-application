import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { UserModel } from '../../../Models/UserModel';
import { Auth } from '../../../Services/auth/auth';
@Component({
  selector: 'app-register',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})

export class Register {
  constructor(private router: Router, private authService: Auth){}

  registerForm = new FormGroup({
    name: new FormControl(''),
    username: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl('')
  })

  submitForm(){
    if (this.registerForm.value.password !== this.registerForm.value.confirmPassword) {
      console.error('Passwords do not match');
      return;
    }

    var user: UserModel = {
      name: this.registerForm.value.name!,
      username: this.registerForm.value.username!,
      email: this.registerForm.value.email!,
      password: this.registerForm.value.password!
    };

    this.authService.registerUser(user).subscribe({
      next:(data)=>{
        sessionStorage.setItem("currentLoggedIn", JSON.stringify(data));
        this.router.navigate(['/home'], {replaceUrl: true})
      },
      error: (err) => console.error('Registration failed', err.error?.errors || err)
    });
  }
}