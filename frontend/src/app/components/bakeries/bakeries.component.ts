// import { CommonModule } from '@angular/common';
// import { HttpClient } from '@angular/common/http';
// import { Component, inject, OnInit } from '@angular/core';
// import { Router } from '@angular/router';
// import { ShopService } from '../../Services/shop.service';
// import { HeaderComponent } from "../header/header.component";

// @Component({
//   selector: 'app-bakeries',
//   standalone: true,
//   imports: [CommonModule, HeaderComponent],
//   templateUrl: './bakeries.component.html',
//   styleUrl: './bakeries.component.css',
// })
// export class BakeriesComponent implements OnInit {
//   bakeries: any[] = [];
//   http = inject(HttpClient);

//   ngOnInit(): void {
//     this.getShops();
//   }
//   constructor(private router: Router,
//     private shopService:ShopService) {}

//   goToProducts(sellerId: number) {
//     this.router.navigate([`/product_list/${sellerId}`]);
//   }

//   getShops() {
//     this.shopService.getShops()   //service
//     .subscribe((res: any) => {
//       console.log(res);

//       if (res) {
//         this.bakeries = res;
//       }
//     });
//   }
// }
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShopService } from '../../Services/shop.service';
import { HeaderComponent } from '../header/header.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-bakeries',
  standalone: true,
  imports: [CommonModule, HeaderComponent],
  templateUrl: './bakeries.component.html',
  styleUrls: ['./bakeries.component.css'],
})
export class BakeriesComponent implements OnInit {
  bakeries: any[] = [];
  userLocation: { latitude: number; longitude: number } | null = null;

  http = inject(HttpClient);

  ngOnInit(): void {
    this.getShops();
    this.getUserLocation(); // Get user location when the component initializes
  }

  constructor(private router: Router,
     private shopService: ShopService,
     private toastr: ToastrService,
     ) {}

  goToProducts(sellerId: number) {
    this.router.navigate([`/product_list/${sellerId}`]);
  }

  getShops() {
    this.shopService.getShops().subscribe((res: any) => {
      if (res) {
        this.bakeries = res;
      }
    });
  }

  // Function to get the user's current location
  getUserLocation() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.userLocation = {
            latitude: 8.526803,
            longitude: 76.890983,
            // latitude: position.coords.latitude,
            // longitude: position.coords.longitude,
          };
        },
        (error) => {
          console.error('Error getting location', error);
          this.userLocation = null; // Set to null if location is not accessible
        }
      );
    }
  }

  // Function to get the directions URL
  getDirections(shop: any) {
    if (!this.userLocation) {
     this.toastr.error('Unable to get your location. Please enable location services.');
      return;
    }
    
    const origin = `${this.userLocation.latitude},${this.userLocation.longitude}`;
    const destination = `${shop.latitude},${shop.longitude}`;
    const directionsUrl = `https://www.google.com/maps/dir/${origin}/${destination}`;

    window.open(directionsUrl, '_blank'); // Open the directions in a new tab
  }
}
