import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { OrderService } from '../../../services/order.service';
import { Orderdetail } from '../../../models/orderdetail.model';
import { ConfigApiService } from '../../../services/config-api.service';

@Component({
  selector: 'app-item-book',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterOutlet, RouterLink],
  templateUrl: './item-book.component.html',
  styleUrl: './item-book.component.scss',
})
export class ItemBookComponent {
  user: any | null;
  @Input() itemBook: any;
  orderDetail: Orderdetail = {
    bookId: 1,
    quantity: 1,
    unitPrice: 1,
  };
  constructor(
    private orderService: OrderService,
    private apiConfig: ConfigApiService,
    private router: Router
  ) {}

  handleOrder() {
    this.user = this.apiConfig.getCurrentUserFromLocal();
    console.log(this.user);
    
    if (this.user !== undefined) {
      this.orderDetail.bookId = this.itemBook.bookId;
      this.orderDetail.unitPrice = this.itemBook.price;
      this.orderService.handleAddToOrder(this.orderDetail);
    } else {
      this.router.navigate(['login']);
    }
  }
}
