import { Component, Input, OnInit } from '@angular/core';
import { Book } from '../../models/book.model';
import { BooksService } from '../../services/books.service';
import { Orderdetail } from '../../models/orderdetail.model';
import { ConfigApiService } from '../../services/config-api.service';
import { OrderService } from '../../services/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-book-detail',
  templateUrl: './page-book-detail.component.html',
  styleUrl: './page-book-detail.component.scss',
})
export class PageBookDetailComponent implements OnInit {
  user: any | null;
  @Input() id!: number;
  book: Book = {
    title: '',
    author: '',
    imageUrl: '',
    description: '',
    price: 0,
    quantity: 0,
  };

  orderDetail: Orderdetail = {
    bookId: this.id,
    quantity: 1,
    unitPrice: this.book.price,
  };
  constructor(
    private httpBook: BooksService,
    private apiConfig: ConfigApiService,
    private orderService: OrderService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.loadBookDetail();
  }

  handleOrder() {
    this.user = this.apiConfig.getCurrentUserFromLocal();
    console.log(this.user);

    if (this.user !== undefined) {
      this.orderDetail.bookId = this.book.bookId;
      this.orderDetail.unitPrice = this.book.price;
      this.orderService.handleAddToOrder(this.orderDetail);
    } else {
      this.router.navigate(['login']);
    }
  }

  loadBookDetail() {
    this.httpBook.getBook(this.id).subscribe({
      next: (res) => {
        this.book = res[0];
        console.log(this.book);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
