import { Component, OnInit } from '@angular/core';
import { BooksService } from '../../../services/books.service';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { MatDialog } from '@angular/material/dialog';
import { DELETE_ICON, EDIT_ICON } from '../../../shared/icons/share-icon';
import { Book } from '../../../models/book.model';
import { AddBookComponent } from './add-book/add-book.component';
import { UpdateBookComponent } from './update-book/update-book.component';
import { DeleteAccountComponent } from '../manage-account/delete-account/delete-account.component';
import { DeleteBookComponent } from './delete-book/delete-book.component';

@Component({
  selector: 'app-manage-book',
  templateUrl: './manage-book.component.html',
  styleUrl: './manage-book.component.scss',
})
export class ManageBookComponent implements OnInit {
  books: Book[] = [];
  displayedColumns: string[] = [
    'id',
    'title',
    'author',
    'imageUrl',
    'description',
    'price',
    'quantity',
    'action'
  ];
  constructor(
    private http: BooksService,
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
    public dialog: MatDialog
  ) {
    iconRegistry.addSvgIconLiteral(
      'edit-icon',
      sanitizer.bypassSecurityTrustHtml(EDIT_ICON)
    );
    iconRegistry.addSvgIconLiteral(
      'delete-icon',
      sanitizer.bypassSecurityTrustHtml(DELETE_ICON)
    );
  }
  ngOnInit(): void {
    this.loadBooks()
  }

  loadBooks() {
    this.http.getAllBook().subscribe({
      next: (res) => {
        this.books = res;
        console.log(this.books);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  openDialogAddBook() {
    this.dialog.open(AddBookComponent, {
      height: '80vh',
    });
  }
  openDialogUpdateBook(i: Book) {
    this.dialog.open(UpdateBookComponent, {
      height: '80vh',
      data: i,
    });
  }

  openDialogDeleteBook(i: Book) {
    this.dialog.open(DeleteBookComponent, {
      data: i,
    });
  }
}
