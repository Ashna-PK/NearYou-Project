import { Component ,OnInit} from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { CommonModule } from '@angular/common';
import { ReviewService } from '../../Services/review.service';
@Component({
  selector: 'app-review',
  standalone: true,
  imports: [HeaderComponent,CommonModule],
  templateUrl: './review.component.html',
  styleUrl: './review.component.css'
})
export class ReviewComponent implements OnInit{
  reviews:any[]=[];
    role = localStorage.getItem('role')
  
    constructor(private reviewService:ReviewService) {}
  
    ngOnInit(): void {
      const role = Number(localStorage.getItem('role'))
      if(this.role=='admin')
      this.getAllReviews()
      else if(this.role=='seller')
      this.getReviewByShop()
    }
    getAllReviews(){
        this.reviewService.getAllReview().subscribe({
          next: (res) => {
            this.reviews=res.result
            console.log(this.reviews)
            alert(`review retrieved successfully!`);
           console.log(res) // Reset selected quantity
          },
          error: (err) => {
            console.error('Error booking product:', err);
            alert('An error occurred while booking the product. Please try again.');
          }
        })
    }
    getReviewByShop(){
      this.reviewService.getReviewByShop(localStorage.getItem('sellerId')).subscribe({
        next: (res) => {
          this.reviews=res.result
          console.log(res)
          alert(`review retrieved successfully!`);
         console.log(res) // Reset selected quantity
        },
        error: (err) => {
          console.error('Error booking product:', err);
          alert('An error occurred while booking the product. Please try again.');
        }
      })
    }
  }
