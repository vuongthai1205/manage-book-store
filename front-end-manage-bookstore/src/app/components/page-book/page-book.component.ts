import { Component } from '@angular/core';
import { BooksService } from '../../services/books.service';
import { Book } from '../../models/book.model';
import { Search } from '../../models/search.model';

@Component({
  selector: 'app-page-book',
  templateUrl: './page-book.component.html',
  styleUrl: './page-book.component.scss',
})
export class PageBookComponent {
  constructor(private apiBook: BooksService) {}
  book: Book[] = [];
  searchInput: Search = {
    content: '',
    filterWith: 'title',
  };
  ngOnInit(): void {
    this.getAllBook();
  }

  getAllBookWithSearch = () => {
    this.apiBook.getAllBookWithSearch(this.searchInput).subscribe({
      next: (res) => {
        this.book = res;
      },
      error: (error) => {
        console.log(error);
      },
    });
  };

  getAllBook = () => {
    this.apiBook.getAllBook().subscribe({
      next: (res) => {
        this.book = res;
      },
      error: (error) => {
        console.log(error);
      },
    });
  };
  onSearchSubmit() {
    this.getAllBookWithSearch()
  }
}
