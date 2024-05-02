import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { CategoriesService } from '../../../app/services/categories.service';
import { Category } from '../../../app/models/category.model';
@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [
    MatListModule,
    CommonModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    MatDividerModule,
  ],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class SidebarComponent implements OnInit {

  categories: Category[] = [];

  constructor(private httpCategory: CategoriesService) {};
  ngOnInit(): void {
    this.loadCategories()
  }
  loadCategories() {
    this.httpCategory.getAllCategory().subscribe({
      next: (res) => {
        this.categories = res;
        console.log(this.categories);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
