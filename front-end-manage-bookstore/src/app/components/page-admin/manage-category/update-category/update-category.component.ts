import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Category } from '../../../../models/category.model';
import { CategoriesService } from '../../../../services/categories.service';

@Component({
  selector: 'app-update-category',
  templateUrl: './update-category.component.html',
  styleUrl: './update-category.component.scss'
})
export class UpdateCategoryComponent implements OnInit{
  constructor(
    public dialogRef: MatDialogRef<UpdateCategoryComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Category,
    private http: CategoriesService
  ) {}
  ngOnInit(): void {
    console.log('Update category ', this.data);
  }

  onSubmit() {
    this.http.updateCategory(this.book).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  book: Category = {
    categoryId: this.data.categoryId,
    name: this.data.name,
  };
}
