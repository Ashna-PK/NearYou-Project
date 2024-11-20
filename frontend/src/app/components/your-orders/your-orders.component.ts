import { Component, TemplateRef, ViewChild } from '@angular/core';
import { CommonModule, LocationChangeListener } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BookingService } from '../../Services/booking.service';
import { HeaderComponent } from '../header/header.component';
import { ReviewService } from '../../Services/review.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-your-orders',
  standalone: true,
  imports: [FormsModule, CommonModule, HeaderComponent],
  templateUrl: './your-orders.component.html',
  styleUrl: './your-orders.component.css',
})
export class YourOrdersComponent {
  reviewdetails: any = {
    // bookingId:0,
    productId: 0,
    shopid: 0,
    userid: 0,
    // dateTime: new Date(Date.now()).toISOString(),
    // message:'',
    userRating: 0,
  };
  role: any = localStorage.getItem('role');
  orders: any[] = [];
  reviewText = '';
  rating: number | null = null; // Store the rating
  showReviewModal = false;
  selectedOrder: any = null;

  constructor(
    private bookingService: BookingService,
    private reviewService: ReviewService,
    private toastr:ToastrService
  ) {
    this.loadOrders();
  }

  loadOrders() {
    if (this.role === 'user') {
      this.bookingService
        .getBookingsOfUser(localStorage.getItem('userId'))
        .subscribe({
          next: (res) => {
            this.orders = res;
            console.log('orders retrieved succesfuly');
            console.log(res);
          },
          error: (err) => {
            console.error('Error loading orders', err);
            this.toastr.error(
              'An error occurred while loading the orders. Please try again.'
            );
          },
        });
    } else if (this.role === 'seller') {
      this.bookingService
        .getBookingsOfShop(localStorage.getItem('sellerId'))
        .subscribe({
          next: (res) => {
            this.orders = res;
           console.log('orders retrieved succesfuly');
            console.log(res);
          },
          error: (err) => {
            console.error('Error loading orders', err);
            console.log(
              'An error occurred while loading the orders. Please try again.'
            );
          },
        });
    }
  }

  openReviewModal(order: any) {
    this.showReviewModal = true;
    console.log(this.showReviewModal);
    this.selectedOrder = order;
    this.reviewText = '';
    this.rating = null; // Reset the rating
  }

  closeReviewModal() {
    this.showReviewModal = false;
    this.selectedOrder = null;
  }

  submitReview() {
    if (this.reviewText.trim() === '') {
      this.toastr.warning('Review text cannot be empty.');
      return;
    }
    if (!this.rating) {
      this.toastr.warning('Please select a rating.');
      return;
    }
    this.reviewdetails.bookingId = 0;
    this.reviewdetails.productId = this.selectedOrder.productId;
    this.reviewdetails.shopid = this.selectedOrder.vendorId;
    this.reviewdetails.userid = localStorage.getItem('userId');
    this.reviewdetails.dateTime = new Date(Date.now()).toISOString();
    this.reviewdetails.message = this.reviewText;
    this.reviewdetails.userRating = this.rating;
    this.reviewService.postReview(this.reviewdetails).subscribe({
      next: (res) => {
        this.toastr.success('review added succesfuly');
        console.log(res);
      },
      error: (err) => {
        console.error('Error addding review', err);
        this.toastr.error('An error occurred while loading the orders. Please try again.');
      },
    });
    console.log(
      'Review Submitted for:',
      this.selectedOrder.productName,
      'with text:',
      this.reviewText,
      'and rating:',
      this.rating
    );

    this.closeReviewModal();
  }
}
