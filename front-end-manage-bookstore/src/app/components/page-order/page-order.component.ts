import { Component, OnInit } from '@angular/core';
import { Orderdetail } from '../../models/orderdetail.model';
import { OrderService } from '../../services/order.service';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { DELETE_ICON } from '../../shared/icons/share-icon';
import { MatDialog } from '@angular/material/dialog';
import { PopupOrderComponent } from './popup-order/popup-order.component';

@Component({
  selector: 'app-page-order',
  templateUrl: './page-order.component.html',
  styleUrl: './page-order.component.scss',
})
export class PageOrderComponent implements OnInit {
  orderDetails: Orderdetail[] = [];
  displayedColumns: string[] = [
    'bookId',
    'quantity',
    'unitPrice',
    'totalPrice',
    'action',
  ];
  totalOrderPrice = 0;

  constructor(
    private orderService: OrderService,
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
    private dialog: MatDialog
  ) {
    iconRegistry.addSvgIconLiteral(
      'delete-icon',
      sanitizer.bypassSecurityTrustHtml(DELETE_ICON)
    );
  }
  ngOnInit(): void {
    const order = this.orderService.loadOrderFromLocalStorage(); // Get order from local storage
    if (order) {
      this.orderDetails = order.orderDetailRequests || [];
      this.updateTotalPrice(); // Update the total order price
    }
  }

  updateTotalPrice() {
    this.totalOrderPrice = this.orderDetails.reduce((total, item) => {
      const quantity = item.quantity || 1;
      const unitPrice = item.unitPrice || 0;
      return total + quantity * unitPrice;
    }, 0);
  }

  openPopupOrder() {
    const dialogRef = this.dialog.open(PopupOrderComponent, {
      height: '80vh',
      data: { note: '' },
    });
    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
      console.log(result);
      if (result !== undefined) {
        this.orderDetails = [];
        this.orderService.placeOrder(result);
      }
    });
  }

  deleteOrderByBookId(arg0: any) {
    this.orderService.removeOrderDetail(arg0);
    const order = this.orderService.loadOrderFromLocalStorage();
    if (order) {
      this.orderDetails = order.orderDetailRequests || [];
      this.updateTotalPrice(); // Update the total order price
    }
  }
}
