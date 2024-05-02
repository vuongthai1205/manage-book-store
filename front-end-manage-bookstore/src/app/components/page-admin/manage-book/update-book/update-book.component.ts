import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BooksService } from '../../../../services/books.service';
import { Book } from '../../../../models/book.model';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrl: './update-book.component.scss',
})
export class UpdateBookComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<UpdateBookComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Book,
    private http: BooksService
  ) {}
  ngOnInit(): void {
    console.log('Update book ', this.data);
  }

  onSubmit() {
    this.http.updateBook(this.book).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  book: Book = {
    bookId: this.data.bookId,
    title: this.data.title,
    author: this.data.author,
    imageUrl: this.data.imageUrl,
    description: this.data.description,
    price: this.data.price,
    quantity: this.data.quantity,
  };
}
