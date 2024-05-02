import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CategoriesService } from '../../../../services/categories.service';
import { Category } from '../../../../models/category.model';

@Component({
  selector: 'app-delete-category',
  templateUrl: './delete-category.component.html',
  styleUrl: './delete-category.component.scss'
})
export class DeleteCategoryComponent {
  onDelete() {
    this.http.deleteCategory(this.data.categoryId).subscribe({
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
    public dialogRef: MatDialogRef<DeleteCategoryComponent>,
    private http: CategoriesService,
    @Inject(MAT_DIALOG_DATA) public data: Category
  ) {}
}
