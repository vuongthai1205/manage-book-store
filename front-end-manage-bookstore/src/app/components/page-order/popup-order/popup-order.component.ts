import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { OrderService } from '../../../services/order.service';
import { Order } from '../../../models/order.model';

@Component({
  selector: 'app-popup-order',
  templateUrl: './popup-order.component.html',
  styleUrl: './popup-order.component.scss'
})
export class PopupOrderComponent  implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<PopupOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Order,
    private orderService: OrderService
  ) {}
  ngOnInit(): void {
    console.log("popup order");
    
  }
  onCancel(): void {
    this.dialogRef.close();
  }

  onOrder(formValue: any): void {
    // Xử lý logic đặt hàng với giá trị từ form
    console.log('Đặt hàng với ghi chú:', formValue.notes);
    this.dialogRef.close();
  }
}
