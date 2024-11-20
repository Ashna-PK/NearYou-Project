import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { delay } from 'rxjs';
import { ProductService } from '../../Services/product.service';
import { HeaderComponent } from '../header/header.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-seller-home',
  standalone: true,
  imports: [FormsModule, CommonModule, HeaderComponent],
  templateUrl: './seller-home.component.html',
  styleUrl: './seller-home.component.css',
})
export class SellerHomeComponent implements OnInit {
  products: any[] = [];
  selectedProduct: any = null;
  isAddMode: boolean = false;

  constructor(private productService: ProductService,
    private toastr:ToastrService ) {
    // this.shopID =Number(localStorage.getItem('sellerId'));
    // console.log(this.shopID)
  }
  http = inject(HttpClient);
  ngOnInit(): any {
    // window.location.reload()
    // delay(2000)

    this.getProductsByShop();
  }
  openUpdateModal(index: number) {
    if (index < 0 || index >= this.products.length) {
      console.error('Invalid product index:', index);
      return;
    }
    this.isAddMode = false;
    this.selectedProduct = { ...this.products[index] };
    console.log(this.selectedProduct);
  }
  openAddModal() {
    this.isAddMode = true;
    this.selectedProduct = {
      id: null,
      name: '',
      rating: 0,
      description: '',
      shopId: Number(localStorage.getItem('sellerId')),
      price: 0,
      quantity: 0,
      // count: 0,
      //  cumulativeSum:0
    };
  }
  saveProduct() {
    if (!this.selectedProduct) {
      this.toastr.warning('No product data to save.');
      return;
    }
    if (this.isAddMode) {
      console.log(this.selectedProduct);
      this.productService.postProduct(this.selectedProduct)
        .subscribe({
          next: (res) => {
            this.toastr.success('product added succesfuly');
            this.products.push(res);
            console.log(res);
          },
          error: (err) => {
            console.error('Error adding product:', err);
            this.toastr.error(
              'An error occurred while adding the product. Please try again.'
            );
          },
        });
      this.isAddMode = false;
    } else {
      const index = Number(this.selectedProduct.id);
      console.log(this.selectedProduct);
      if (!index) {
        console.log('Invalid product ID.');
        return;
      }
      console.log(this.selectedProduct.name);
      this.productService.putShop(index,this.selectedProduct)
        .subscribe({
          next: (res) => {
            console.log(this.selectedProduct);
            this.getProductsByShop();
            this.toastr.success(
              `Your product  was updated successfully!`
            );
            this.selectedProduct = null;
          },
          error: (err) => {
            console.error('Error updating product:', err);
            this.toastr.error(
              'An error occurred while updating the product. Please try again.'
            );
          },
        });
    }
    this.closeModal(); // Close modal
  }
  deleteProduct(index: number) {
    const productToDelete = this.products[index];
    this.toastr.warning(`the product : ${productToDelete.name} will be deleted !`);
    this.productService.deleteProduct(productToDelete.id)
      .subscribe({
        next: () => {
          this.products.splice(index, 1);
          this.getProductsByShop();
          delay(1000);
          this.toastr.success(
            `Your product '${productToDelete.name}' was deleted successfully!`
          );
        },
        error: (err) => {
          console.error('Error deleting product:', err);
          this.toastr.error(
            'An error occurred while deleting the product. Please try again.'
          );
        },
      });
  }
  closeModal() {
    this.selectedProduct = null;
  }
  getProductsByShop() {
   
    const sellerId = localStorage.getItem('sellerId');
    console.log(sellerId);
    if (sellerId) {
      this.productService
        .getProductByShop(sellerId)
        .subscribe({
          next: (res) => {
            console.log(res);
            this.products = res;
            console.log(this.products);
           
          },
          error: (err) => {
            console.error('Error fetching products:', err);
          },
        });
    }
    // else {
    //   window.location.reload();
    // }
  }
}
