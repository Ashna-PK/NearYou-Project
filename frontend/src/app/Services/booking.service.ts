import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http:HttpClient) { }
    private baseUrl='https://localhost:7000/gateway/booking';
    getBookingsOfUser(id:any):Observable<any>{
     return this.http.get(`${this.baseUrl}/user/${id}`);
    }
    getBookingsOfShop(id:any):Observable<any>{
     return  this.http.get(`${this.baseUrl}/shop/${id}`);
    }
    postBooking(bookingDetails:any):Observable<any>{
    return  this.http.post(this.baseUrl,bookingDetails)
  }
}
