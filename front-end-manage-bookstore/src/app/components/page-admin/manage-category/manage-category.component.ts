import { Component, OnInit } from '@angular/core';
import { DELETE_ICON, EDIT_ICON } from '../../../shared/icons/share-icon';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { CategoriesService } from '../../../services/categories.service';
import { Category } from '../../../models/category.model';
import { AddCategoryComponent } from './add-category/add-category.component';
import { UpdateCategoryComponent } from './update-category/update-category.component';
import { DeleteCategoryComponent } from './delete-category/delete-category.component';

@Component({
  selector: 'app-manage-category',
  templateUrl: './manage-category.component.html',
  styleUrl: './manage-category.component.scss',
})
export class ManageCategoryComponent implements OnInit {
  categories: Category[] = [];
  displayedColumns: string[] = ['id', 'name', 'action'];

  constructor(
    private http: CategoriesService,
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
    this.loadCategories();
  }

  loadCategories() {
    this.http.getAllCategory().subscribe({
      next: (res) => {
        this.categories = res;
        console.log(this.categories);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  openDialogDeleteCategory(i: Category) {
    this.dialog.open(DeleteCategoryComponent, {
      data: i,
    });
  }
  openDialogUpdateCategory(i: Category) {
    this.dialog.open(UpdateCategoryComponent, {
      height: '80vh',
      data: i,
    });
  }
  openDialogAddCategory() {
    this.dialog.open(AddCategoryComponent, {
      height: '80vh',
    });
  }
}
