import { Routes } from '@angular/router';
import { Home } from '../Components/home/home';
import { Login } from '../Components/Auth/login/login';
import { Register } from '../Components/Auth/register/register';

export const routes: Routes = [
    {
        path: 'home',
        component: Home
    },
    {
        path: '',
        component: Login
    },
    {
        path: 'register',
        component: Register
    }
];
