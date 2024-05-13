import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Order } from '../../../../models/order.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { OrderService } from '../../../../services/order.service';
import { Orderdetail } from '../../../../models/orderdetail.model';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { StatusHistory } from '../../../../models/statusHistory.model';
import { statusHistories } from '../../../../shared/constant';

@Component({
  selector: 'app-update-order',
  templateUrl: './update-order.component.html',
  styleUrl: './update-order.component.scss',
})
export class UpdateOrderComponent implements OnInit {
  
  displayedColumns: string[] = ['bookId', 'quantity', 'unitPrice', 'createAt'];
  dataSource = new MatTableDataSource<Orderdetail>([]);
  statusHistory: StatusHistory = {
    orderId: this.data.id!,
    orderStatusId: this.data?.statusHistoryResponses?.[this.data?.statusHistoryResponses?.length-1]?.orderStatusId ?? 0,
    note: '',
  };
  checkOrderStatusId : string | number | undefined
  statusHistories = statusHistories;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor(
    public dialogRef: MatDialogRef<UpdateOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Order,
    private orderService: OrderService
  ) {
    this.checkOrderStatusId = this.data?.statusHistoryResponses?.[this.data?.statusHistoryResponses?.length-1]?.orderStatusId
  }
  ngOnInit(): void {
    console.log(this.data);
    this.loadOrderDetail();
  }
  loadOrderDetail() {
    if (this.data) {
      const orderDetails = this.data.orderDetails || []; // Ensure it's an array, even if empty
      this.dataSource.data = orderDetails;
      this.dataSource.paginator = this.paginator; // Attach paginator
      this.dataSource.sort = this.sort; // Attach sorting
    }
  }
  onSubmit() {
    this.orderService.updateStatusHistory(this.statusHistory).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  checkValid(){
    if(this.checkOrderStatusId === 3){
      return true
    }
    return false
  }
}
