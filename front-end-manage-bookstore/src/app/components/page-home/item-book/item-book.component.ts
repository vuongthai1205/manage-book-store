import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { RouterLink, RouterOutlet } from '@angular/router';
import { OrderService } from '../../../services/order.service';
import { Orderdetail } from '../../../models/orderdetail.model';

@Component({
  selector: 'app-item-book',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterOutlet, RouterLink],
  templateUrl: './item-book.component.html',
  styleUrl: './item-book.component.scss',
})
export class ItemBookComponent {

  @Input() itemBook: any;
  orderDetail: Orderdetail = {
    bookId: 1,
    quantity: 1,
    unitPrice: 1
  }
  constructor(private orderService: OrderService){}

  handleOrder(){
    this.orderDetail.bookId = this.itemBook.bookId
    this.orderDetail.unitPrice = this.itemBook.price
    this.orderService.handleAddToOrder(this.orderDetail)
  }
}
