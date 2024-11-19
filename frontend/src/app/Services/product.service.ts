import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient) {}
  private baseUrl = 'https://localhost:7003/api/Product';
  getProductByShop(shopId: any): Observable<any> {
    return this.http.get<any[]>(this.baseUrl + '/shop?shopId=' + shopId);
  }
  putShopQuantity(id: Number, selectedQuantity: any) {
    return this.http.put(`${this.baseUrl}/${id}/${selectedQuantity}`, {});
  }
  postShop(selectedProduct: any): Observable<any> {
    return this.http.post(
      `${this.baseUrl}?sellerId=${selectedProduct.shopId}`,
      selectedProduct
    );
  }
  putShop(index: Number, selectedProduct: any) {
    return this.http.put(
      this.baseUrl+'/' + index,
      selectedProduct
    );
  }
  deleteProduct(id:number){
    return this.http
      .delete(`${this.baseUrl}/${id}`)
  }
}
