import { Routes } from '@angular/router';
import { Hero } from '../Components/hero/hero';
import { Login } from '../Components/Auth/login/login';
import { Register } from '../Components/Auth/register/register';
import { Profile } from '../Components/profile/profile';
import { ChatList } from '../Components/chat-list/chat-list';

export const routes: Routes = [
    {
        path: 'login',
        component: Hero
    },
    {
        path: '',
        component: Login
    },
    {
        path: 'register',
        component: Register
    },
    {
        path: 'profile',
        component: Profile
    },
    {
        path: 'chats',
        component: ChatList
    },
];
