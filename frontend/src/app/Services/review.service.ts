import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  private baseUrl='https://localhost:7000/gateway/review'
  constructor(private http:HttpClient) { 
 
  }
  postReview(reviewDetails:any):Observable<any>
  {
    return this.http.post(this.baseUrl,reviewDetails);
  }
  getAllReview():Observable<any>
  {
    return this.http.get(this.baseUrl);
  }
  getReviewByShop(shopId:any):Observable<any>
  {
    return this.http.get(`${this.baseUrl}/shop/${shopId}`);
  }
}
