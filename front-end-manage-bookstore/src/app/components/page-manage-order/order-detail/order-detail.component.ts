import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Order } from '../../../models/order.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Orderdetail } from '../../../models/orderdetail.model';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrl: './order-detail.component.scss'
})
export class OrderDetailComponent implements OnInit {
  displayedColumns: string[] = ['bookId', 'quantity', 'unitPrice', 'createAt' ];
  dataSource = new MatTableDataSource<Orderdetail>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor(
    public dialogRef: MatDialogRef<OrderDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Order
  ) {}
  ngOnInit(): void {
    console.log(this.data);
    if (this.data) {
      const orderDetails = this.data.orderDetails || []; // Ensure it's an array, even if empty
      this.dataSource.data = orderDetails;
      this.dataSource.paginator = this.paginator; // Attach paginator
      this.dataSource.sort = this.sort; // Attach sorting
    }
  }
}
