import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {
  yourName = 'NearYou';
  yourPhoneNumber = '+91-7795248354';
  yourEmail="NearYou@gmail.com"
}
