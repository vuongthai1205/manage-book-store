import { Component, OnInit } from '@angular/core';
import { Order } from '../../../models/order.model';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { EDIT_ICON } from '../../../shared/icons/share-icon';
import { OrderService } from '../../../services/order.service';
import { MatDialog } from '@angular/material/dialog';
import { UpdateOrderComponent } from './update-order/update-order.component';

@Component({
  selector: 'app-manage-order',
  templateUrl: './manage-order.component.html',
  styleUrl: './manage-order.component.scss',
})
export class ManageOrderComponent implements OnInit {
  displayedColumns: string[] = ['id', 'username','note','totalPrice', 'action'];
  orders: Order[] = [];
  constructor(
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
    private orderService: OrderService,
    public dialog: MatDialog
  ) {
    iconRegistry.addSvgIconLiteral(
      'edit-icon',
      sanitizer.bypassSecurityTrustHtml(EDIT_ICON)
    );
  }
  ngOnInit(): void {
    this.loadAllOrder();
  }
  loadAllOrder() {
    this.orderService.getAllOrder().subscribe({
      next: (res: any) => {
        this.orders = res;
        console.log(this.orders);
      },
      error: (err: any) => {},
    });
  }
  openDialogUpdateOrder(i: any) {
    this.dialog.open(UpdateOrderComponent, {
      height: '80vh',
      data: i,
    });
  }
}
