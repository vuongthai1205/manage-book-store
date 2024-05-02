import { Component, Input, OnInit } from '@angular/core';
import { Book } from '../../models/book.model';
import { BooksService } from '../../services/books.service';

@Component({
  selector: 'app-page-book-detail',
  templateUrl: './page-book-detail.component.html',
  styleUrl: './page-book-detail.component.scss',
})
export class PageBookDetailComponent implements OnInit {
  @Input() id!: number;
  book: Book = {
    title: '',
    author: '',
    imageUrl: '',
    description: '',
    price: 0,
    quantity: 0,
  };
  constructor(private httpBook: BooksService) {}
  ngOnInit(): void {
    this.loadBookDetail();
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
