import { Component, OnInit } from '@angular/core';
import { DefaultLayoutComponent } from '../../../layouts/default-layout/default-layout.component';
import { ListBookComponent } from './list-book/list-book.component';
import { HomeSlideComponent } from './home-slide/home-slide.component';
import { BooksService } from '../../services/books.service';
import { Book } from '../../models/book.model';

@Component({
  selector: 'app-page-home',
  standalone: true,
  imports: [DefaultLayoutComponent, ListBookComponent, HomeSlideComponent],
  templateUrl: './page-home.component.html',
  styleUrl: './page-home.component.scss',
})
export class PageHomeComponent implements OnInit {
  constructor(private apiBook: BooksService) {}
  book: Book[] = [];
  bookTop4: Book[] = [];
  ngOnInit(): void {
    this.getAllBook();
    this.getTop4Book()
  }

  getTop4Book = () => {
    this.apiBook.getTop4Book().subscribe({
      next: (res) => {
        this.bookTop4 = res;
      },
      error: (error) => {
        console.log(error);
      },
    });
  };

  getAllBook = () => {
    this.apiBook.getAllNewBook().subscribe({
      next: (res) => {
        this.book = res;
        console.log(this.book);
      },
      error: (error) => {
        console.log(error);
      },
    });
  };
}
