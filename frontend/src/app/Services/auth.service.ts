import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  http = inject(HttpClient);
  private baseUrl = 'https://localhost:7000/gateway/auth';
  isLoggedIn = false; // This variable tracks the login status

  constructor() {}

  // This method simulates logging in
  register(registerObj: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/register`, registerObj);
  }
  login(loginObj:any):Observable<any>{
    return this.http.post(`${this.baseUrl}/login`,loginObj);
  }
  // This method simulates logging out
  logout() {
    localStorage.clear()
    this.isLoggedIn = false;
    //Clear any stored data if necessary
  }
}
