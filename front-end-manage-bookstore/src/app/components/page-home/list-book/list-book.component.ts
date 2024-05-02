import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { BooksService } from '../../../services/books.service';
import { ItemBookComponent } from '../item-book/item-book.component';
import { Book } from '../../../models/book.model';

@Component({
  selector: 'app-list-book',
  standalone: true,
  imports: [ItemBookComponent],
  templateUrl: './list-book.component.html',
  styleUrl: './list-book.component.scss',
})
export class ListBookComponent implements OnChanges{
  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
    
  }
  @Input() book: Book[] = [];
}
