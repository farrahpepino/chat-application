import { Component } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup } from '@angular/forms';
import {  Router, RouterLink } from '@angular/router';
import { Auth } from '../../../Services/auth/auth';
@Component({
  selector: 'app-login',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})

export class Login {
  constructor(private authService: Auth, private router: Router){}

  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  })

  submitForm(){
    var user = {
      email: this.loginForm.value.email!,
      password: this.loginForm.value.password!
    };

    this.authService.loginUser(user).subscribe({
      next:(data)=>{
        sessionStorage.setItem("currentLoggedIn", JSON.stringify(data));
        this.router.navigate(['/home'], {replaceUrl: true})
      },
      error: (err) => console.error('Login failed', err.error?.errors || err)
    });
  }
}
