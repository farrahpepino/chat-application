import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
interface Message{
  sender: string;
  receipient: string;
  content: string;
  createdAt: string;
}

@Component({
  selector: 'app-chat-room',
  imports: [CommonModule],
  templateUrl: './chat-room.html',
  styleUrl: './chat-room.css'
})
export class ChatRoom {

  messages: Message[] =[
    {
      sender: "farrah",
      receipient: "aisha",
      content: "can you please buy me iced chocolate?",
      createdAt: "October 7, 2025"
    },
    {
      sender: "aisha",
      receipient: "farrah",
      content: "okay, but cook meatballs",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "fine",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "can you please buy me iced chocolate?",
      createdAt: "October 7, 2025"
    },
    {
      sender: "aisha",
      receipient: "farrah",
      content: "okay, but cook meatballs",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "fine",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "can you please buy me iced chocolate?",
      createdAt: "October 7, 2025"
    },
    {
      sender: "aisha",
      receipient: "farrah",
      content: "okay, but cook meatballs",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "fine",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "can you please buy me iced chocolate?",
      createdAt: "October 7, 2025"
    },
    {
      sender: "aisha",
      receipient: "farrah",
      content: "okay, but cook meatballs",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "fine",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "can you please buy me iced chocolate?",
      createdAt: "October 7, 2025"
    },
    {
      sender: "aisha",
      receipient: "farrah",
      content: "okay, but cook meatballs",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "fine",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "can you please buy me iced chocolate?",
      createdAt: "October 7, 2025"
    },
    {
      sender: "aisha",
      receipient: "farrah",
      content: "okay, but cook meatballs",
      createdAt: "October 7, 2025"
    },
    {
      sender: "farrah",
      receipient: "aisha",
      content: "okieee",
      createdAt: "October 7, 2025"
    }

  ]
}
