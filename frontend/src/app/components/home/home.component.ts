import { Component } from '@angular/core';
import { NavBarComponent } from "../nav-bar/nav-bar.component";
import { CarousalComponent } from "../carousal/carousal.component";
import { FooterComponent } from "../footer/footer.component";
import { RouterOutlet } from '@angular/router';
import { SellerHomeComponent } from "../seller-home/seller-home.component";
import { HeaderComponent } from "../header/header.component";
import { ShopRegisterComponent } from "../shop-register/shop-register.component";
import { AdminSellerComponent } from "../admin-seller/admin-seller.component";
import { QuotesComponent } from "../quotes/quotes.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NavBarComponent, CarousalComponent, FooterComponent, RouterOutlet, HeaderComponent,  QuotesComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
Role=localStorage.getItem('role')
name=localStorage.getItem('shopName')
}
