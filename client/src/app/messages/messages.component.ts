import { Component } from '@angular/core';

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.css'
})
export class MessagesComponent {

  ngOnInit(): void {
    console.log('MESSAGES COMPONENT LOADED!');
  }
  
}
