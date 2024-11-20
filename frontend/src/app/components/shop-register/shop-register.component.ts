import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { HeaderComponent } from '../header/header.component';
import { ShopService } from '../../Services/shop.service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-shop-register',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, HeaderComponent],
  templateUrl: './shop-register.component.html',
  styleUrl: './shop-register.component.css',
})
export class ShopRegisterComponent implements OnInit {
  shopForm: FormGroup;
  constructor(
    private toastr:ToastrService,
    private fb: FormBuilder,
    private router: Router,
    private shopService: ShopService,
    private http: HttpClient
  ) {
    this.shopForm = this.fb.group({
      shopName: ['', Validators.required],
      shopDescription: ['', Validators.required],
      category: ['', Validators.required],
      openingTime: ['', Validators.required],
      closingTime: ['', Validators.required],
      shopAddress: ['', Validators.required],
      latitude: [''],
      longitude: [''],
      // email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      // password: ['', [Validators.required, Validators.minLength(6)]],
      // confirmPassword: ['', Validators.required],
    });
  }
  // shopDetails={
  //   shopName: "",
  //     shopDescription: "",
  //     category: "",
  //     openingTime: "",
  //     closingTime: "",
  //     shopAddress: "",
  //     // email: ['', [Validators.required, Validators.email]],
  //     phoneNumber: ''
  // }
  latitude = 0;
  longitude = 0;
  shopId = Number(localStorage.getItem('sellerId'));
  shopname = localStorage.getItem('shopName');

  ngOnInit(): void {
    // Navigate after successful registration
    // this.getShopById(this.shopId)
    console.log(this.shopForm);
  }
  onSubmit(): void {
    localStorage.setItem('verified', 'true');
    if (this.shopForm.valid) {
      const shopDetails = {
        name: this.shopForm.value.shopName,
        description: this.shopForm.value.shopDescription,
        openTime: `${this.shopForm.value.openingTime}:00`,
        closeTime: `${this.shopForm.value.closingTime}:00`,
        category: this.shopForm.value.category,
        address: this.shopForm.value.shopAddress,
        longitude: this.longitude,
        latitude: this.latitude,
        email: localStorage.getItem('email'),
        phoneNumber: this.shopForm.value.phoneNumber,
        isOpen: true,
        createdAt: new Date(),
      };
      localStorage.setItem('shopName', shopDetails.name);
      console.log(shopDetails);
      this.shopService.putShop(this.shopId, shopDetails).subscribe({
        next: (response) => {
          console.log('Shop registered successfully:', response);
          this.router.navigate(['seller/home']); // Navigate after successful registration
        },
        error: (error) => {
          console.error('Error registering shop:', error);
        },
      });
      this.goToSellerHome();
    } else {
      console.log('Form is invalid');
    }
  }
  goToSellerHome() {
    this.router.navigate(['seller/home']);
  }
  goToLogin() {
    this.router.navigate(['/login']); // Adjust the path as needed
  }

  onFindAddress() {
    if ('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.latitude = position.coords.latitude;
          this.longitude = position.coords.longitude;
          console.log(
            `Latitude: ${this.latitude}, Longitude: ${this.longitude}`
          );
          this.fetchAddress(this.latitude, this.longitude);
        },

        (error) => {
          console.error('Error fetching location:', error);
          this.toastr.error(
            'Unable to retrieve location. Please ensure location services are enabled in your browser.'
          );
        }
      );
    } else {
    this.toastr.warning('Geolocation is not supported by this browser.');
    }
  }

  // Fetch address using reverse geocoding API

  private fetchAddress(latitude: number, longitude: number) {
    const apiKey = '673b6edbb3334977203142ael5c27d9';

    const url = `https://geocode.maps.co/reverse?lat=${latitude}&lon=${longitude}&api_key=${apiKey}`;

    this.http.get<any>(url).subscribe({
      next: (response) => {
        this.shopForm.value.address =
          response.display_name || 'Address not found';

        console.log('Fetched Address:', this.shopForm.value.address);
        this.shopForm.patchValue({
          shopAddress: this.shopForm.value.address,
        });
        this.toastr.success("address added sucessfully")
      },

      error: (err) => {
        console.error('Error fetching address:', err);

        this.toastr.warning('Could not fetch address. Please try again later.');
      },
    });
  }
  //  getShopById(shopId:any){
  //    this.shopService.getShopById(shopId).subscribe({
  //      next: (res) => {
  //       console.log(res)
  //        this.shopForm=res;
           
  //         category: ['', Validators.required],
  //         openingTime: ['', Validators.required],
  //         closingTime: ['', Validators.required],
  //         shopAddress:
  //         shopAddress: this.shopForm.value.address,
  //       });
  //       console.log(res);
    //   },
    //   error: (err) => {
    //     console.error('Error adding product:', err);
    //     alert(
    //       'An error occurred while adding the product. Please try again.'
    //     );
    //   },
    // })
  // }
}
