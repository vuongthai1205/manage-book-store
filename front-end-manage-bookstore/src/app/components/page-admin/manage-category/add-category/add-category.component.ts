import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CategoriesService } from '../../../../services/categories.service';
import { Category } from '../../../../models/category.model';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.scss'
})
export class AddCategoryComponent {
  constructor(
    public dialogRef: MatDialogRef<AddCategoryComponent>,
    private http: CategoriesService
  ) {}
  ngOnInit(): void {
    console.log('Add book ');
  }

  onSubmit() {
    this.http.addCategory(this.book).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  book: Category = {
    name: "",
  };
}
