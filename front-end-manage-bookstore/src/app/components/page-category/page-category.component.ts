import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { BooksService } from '../../services/books.service';
import { Book } from '../../models/book.model';

@Component({
  selector: 'app-page-category',
  templateUrl: './page-category.component.html',
  styleUrl: './page-category.component.scss',
})
export class PageCategoryComponent implements OnInit , OnChanges {
  @Input() id?: number;
  @Input() name?: string;
  booksWithCategory: Book[] = [];
  constructor(private httpBook: BooksService) {}
  ngOnChanges(changes: SimpleChanges): void {
    this.loadBookWithCategory();
  }

  ngOnInit(): void {
    this.loadBookWithCategory();
    console.log(this.name);
    
  }
  loadBookWithCategory() {
    this.httpBook.getAllBookFilterCategory(this.id).subscribe({
      next: (res) => {
        this.booksWithCategory = res
        console.log(this.booksWithCategory);
        
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
