import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BooksService } from '../../../../services/books.service';
import { Book } from '../../../../models/book.model';

@Component({
  selector: 'app-delete-book',
  templateUrl: './delete-book.component.html',
  styleUrl: './delete-book.component.scss'
})
export class DeleteBookComponent {
  onDelete() {
    this.http.deleteBook(this.data.bookId).subscribe({
      next: (res) => {
        console.log(res);
        this.dialogRef.close()
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
  constructor(
    public dialogRef: MatDialogRef<DeleteBookComponent>,
    private http: BooksService,
    @Inject(MAT_DIALOG_DATA) public data: Book
  ) {}
}
