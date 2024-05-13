import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order.model';
import { ConfigApiService } from '../../services/config-api.service';
import { MatDialog } from '@angular/material/dialog';
import { OrderDetailComponent } from './order-detail/order-detail.component';

@Component({
  selector: 'app-page-manage-order',
  templateUrl: './page-manage-order.component.html',
  styleUrl: './page-manage-order.component.scss',
})
export class PageManageOrderComponent implements OnInit {
  openOrderDetailPopup(i: Order) {
    this.dialog.open(OrderDetailComponent, {
      data: i,
    });
  }
  orderList: Order[] = [];
  displayedColumns: string[] = ['id', 'totalPrice', 'action'];
  user: any

  constructor(
    private orderService: OrderService,
    private apiConfig: ConfigApiService,
    public dialog: MatDialog
  ) {
    this.user = apiConfig.getCurrentUserFromLocal()
  }
  ngOnInit(): void {
    this.loadOrderByUsername()
  }
  loadOrderByUsername(){
    this.orderService.getOrderByUsername(this.user.username).subscribe({
      next: (res: any) => {
        this.orderList = res;
        console.log(this.orderList);
      },
      error: (err: any) => {},
    });
  }
}
