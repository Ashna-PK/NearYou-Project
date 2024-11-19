import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-quotes',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './quotes.component.html',
  styleUrl: './quotes.component.css',
})


export class QuotesComponent implements OnInit {
  quoteContent: string = '';
  quoteAuthor: string = '';
  isTypingComplete: boolean = false;
  loading: boolean = true;
  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.fetchQuote();
  }
  
  fetchQuote(): void {
    const category = 'happiness'; // Change the category as needed
    const apiUrl = `https://api.api-ninjas.com/v1/quotes?category=${category}`;
    const apiKey = 'IFIHue/TzNlqPrDkQNoHcA==57n8A3AN99r7VfY3'; // Replace with your actual API key

    const headers = new HttpHeaders({
      'X-Api-Key': apiKey,
      'Content-Type': 'application/json',
    });
    this.loading = true; 
  // this.http.get<any[]>(apiUrl, { headers }).subscribe(
  //   (response) => {
  //     this.loading = false; 
  //     if (response.length > 0) {
  //       // Clear current quote text for typing effect
  //       this.quoteContent = '';
  //       this.quoteAuthor = '';

  //       // Use typing animation for fetched content
  //       const fetchedQuote = response[0].quote;
  //       const fetchedAuthor = response[0].author;
  //       this.typeQuoteAndAuthor(fetchedQuote, fetchedAuthor, 30, 10, 500);
  //     } else {
  //       console.warn('No quotes found for the given category.');
  //     }
  //   },
  //   (error) => {
  //     this.loading = false; 
  //     console.error('Error fetching quote:', error);
  //   }
  // );
}

typeQuoteAndAuthor(
  quoteText: string,
  authorText: string,
  quoteSpeed: number,
  authorSpeed: number,
  delay: number
): void {
  this.typeText('quoteContent', quoteText, quoteSpeed, () => {
    setTimeout(() => {
      this.typeText('quoteAuthor', `- ${authorText}`, authorSpeed);
    }, delay);
  });
}

typeText(
  property: 'quoteContent' | 'quoteAuthor',
  text: string,
  speed: number,
  callback?: () => void
): void {
  let index = 0;
  const interval = setInterval(() => {
    if (index < text.length) {
      this[property] += text.charAt(index);
      index++;
    } else {
      clearInterval(interval);
      if (callback) {
        callback();
      }
    }
  }, speed);
}  
}