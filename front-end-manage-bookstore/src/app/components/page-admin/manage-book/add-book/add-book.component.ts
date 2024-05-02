import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BooksService } from '../../../../services/books.service';
import { Book } from '../../../../models/book.model';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.scss',
})
export class AddBookComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<AddBookComponent>,
    private http: BooksService
  ) {}
  ngOnInit(): void {
    console.log('Add book ');
  }

  onSubmit() {
    this.http.addBook(this.book).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  book: Book = {
    title: "",
    author: "",
    imageUrl: "",
    description: "",
    price: 0,
    quantity: 0,
  };
}
