import { Routes } from '@angular/router';
import { Home } from '../Components/home/home';
import { Login } from '../Components/Auth/login/login';
import { Register } from '../Components/Auth/register/register';
import { Profile } from '../Components/profile/profile';
import { ChatList } from '../Components/chat-list/chat-list';

export const routes: Routes = [
    {
        path: '',
        component: Home
    },
    {
        path: 'login',
        component: Login
    },
    {
        path: 'register',
        component: Register
    }
];
