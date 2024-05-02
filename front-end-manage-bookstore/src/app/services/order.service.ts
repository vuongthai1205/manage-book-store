import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from '../models/book.model';
import { Orderdetail } from '../models/orderdetail.model';
import { Order } from '../models/order.model';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../enviroments/enviroment';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  private orderDetailsSubject = new BehaviorSubject<Orderdetail[]>([]);
  orderDetails$ = this.orderDetailsSubject.asObservable();

  orderDetails: Orderdetail[] = [];
  order: Order = {
    orderDetailRequests: this.orderDetails,
    username: '',
    totalPrice: 0,
  };
  user: any;
  constructor(private http: HttpClient, private router: Router, private toastService: ToastrService) {
    const loadedOrder = this.loadOrderFromLocalStorage(); // Load the order from local storage on initialization
    if (loadedOrder) {
      this.order = loadedOrder; // If an order was loaded, set it as the current order
      this.orderDetails = this.order.orderDetailRequests || []; // Update order details
      this.orderDetailsSubject.next(this.orderDetails);
    }
    const userString = localStorage.getItem('user');
    if (userString !== null) {
      // Kiểm tra nếu giá trị không phải null trước khi parse JSON.
      this.user = JSON.parse(userString);
      this.order.username = this.user.username;
    }
  }
  handleAddToOrder(newOrderDetail: Orderdetail) {
    const existingOrderDetail = this.orderDetails.find(
      (detail) => detail.bookId === newOrderDetail.bookId
    );

    if (existingOrderDetail) {
      // If the bookId already exists, increment the quantity
      existingOrderDetail.quantity = (existingOrderDetail.quantity || 0) + 1;
    } else {
      // If the bookId does not exist, add the new order detail
      newOrderDetail.quantity = 1; // Set quantity to 1 if it's the first addition
      this.orderDetails.push(newOrderDetail);
    }
    this.updateTotalPrice();
    this.saveOrderToLocalStorage();
    this.orderDetailsSubject.next(this.orderDetails);
    console.log(this.order);
  }
  updateTotalPrice() {
    // Calculate the total price by summing the unitPrice * quantity for all order details
    this.order.totalPrice = this.orderDetails.reduce((total, detail) => {
      const quantity = detail.quantity || 1; // Default to 1 if quantity is undefined
      const unitPrice = detail.unitPrice || 0; // Default to 0 if unitPrice is undefined
      return total + quantity * unitPrice;
    }, 0); // Start with a total of 0
  }

  saveOrderToLocalStorage() {
    const orderJson = JSON.stringify(this.order); // Convert the order to JSON
    localStorage.setItem('currentOrder', orderJson); // Store the JSON in local storage
  }

  loadOrderFromLocalStorage(): Order | null {
    const storedOrder = localStorage.getItem('currentOrder'); // Retrieve JSON from local storage
    if (storedOrder) {
      return JSON.parse(storedOrder); // Convert JSON back to an Order object and return it
    }
    return null; // Return null if no order is found
  }

  placeOrder() {
    // You can implement your order placement logic here
    console.log('Order placed:', this.order);
    this.http.post(`${environment.orderApiUrl}`, this.order).subscribe({
      next: (res: any) => {
        this.toastService.success('Đặt hàng thành công','Thông báo' );

        // Clear the order from local storage after placing it
        localStorage.removeItem('currentOrder');
        this.orderDetails = [];
        this.order.orderDetailRequests = this.orderDetails;
        this.orderDetailsSubject.next(this.orderDetails);
      },
      error: (err: any) => {
        console.log(err);
      },
    });
  }
}
