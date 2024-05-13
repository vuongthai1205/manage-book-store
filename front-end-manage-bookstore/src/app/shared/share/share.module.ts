import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddAccountComponent } from '../../components/page-admin/manage-account/add-account/add-account.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {
  ErrorStateMatcher,
  ShowOnDirtyErrorStateMatcher,
} from '@angular/material/core';
import { UpdateAccountComponent } from '../../components/page-admin/manage-account/update-account/update-account.component';
import {
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogTitle,
} from '@angular/material/dialog';
import { DeleteAccountComponent } from '../../components/page-admin/manage-account/delete-account/delete-account.component';
import { AdminLayoutComponent } from '../../../layouts/admin-layout/admin-layout.component';
import { RouterLink, RouterOutlet } from '@angular/router';
import { PageAdminComponent } from '../../components/page-admin/page-admin.component';
import { ManageBookComponent } from '../../components/page-admin/manage-book/manage-book.component';
import { MatTableModule } from '@angular/material/table';
import { AddBookComponent } from '../../components/page-admin/manage-book/add-book/add-book.component';
import { UpdateBookComponent } from '../../components/page-admin/manage-book/update-book/update-book.component';
import { DeleteBookComponent } from '../../components/page-admin/manage-book/delete-book/delete-book.component';
import { ManageCategoryComponent } from '../../components/page-admin/manage-category/manage-category.component';
import { AddCategoryComponent } from '../../components/page-admin/manage-category/add-category/add-category.component';
import { UpdateCategoryComponent } from '../../components/page-admin/manage-category/update-category/update-category.component';
import { DeleteCategoryComponent } from '../../components/page-admin/manage-category/delete-category/delete-category.component';
import { PageCategoryComponent } from '../../components/page-category/page-category.component';
import { DefaultLayoutComponent } from '../../../layouts/default-layout/default-layout.component';
import { ListBookComponent } from '../../components/page-home/list-book/list-book.component';
import { PageBookDetailComponent } from '../../components/page-book-detail/page-book-detail.component';
import { ItemBookComponent } from '../../components/page-home/item-book/item-book.component';
import { MatCardModule } from '@angular/material/card';
import { CommentSectionComponent } from '../../components/page-book-detail/comment-section/comment-section.component';
import { PageOrderComponent } from '../../components/page-order/page-order.component';
import { SigninLayoutComponent } from '../../../layouts/signin-layout/signin-layout.component';
import { PageManageOrderComponent } from '../../components/page-manage-order/page-manage-order.component';
import { OrderDetailComponent } from '../../components/page-manage-order/order-detail/order-detail.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { ManageOrderComponent } from '../../components/page-admin/manage-order/manage-order.component';
import { UpdateOrderComponent } from '../../components/page-admin/manage-order/update-order/update-order.component';
import { PopupOrderComponent } from '../../components/page-order/popup-order/popup-order.component';
import { PageBookComponent } from '../../components/page-book/page-book.component';
@NgModule({
  declarations: [
    AddAccountComponent,
    UpdateAccountComponent,
    DeleteAccountComponent,
    PageAdminComponent,
    ManageBookComponent,
    AddBookComponent,
    UpdateBookComponent,
    DeleteBookComponent,
    ManageCategoryComponent,
    AddCategoryComponent,
    UpdateCategoryComponent,
    DeleteCategoryComponent,
    PageCategoryComponent,
    PageBookDetailComponent,
    PageOrderComponent,
    SigninLayoutComponent,
    PageManageOrderComponent,
    OrderDetailComponent,
    ManageOrderComponent,
    UpdateOrderComponent,
    PopupOrderComponent,
    PageBookComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDividerModule,
    MatIconModule,
    MatSelectModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatDialogTitle,
    MatTableModule,
    MatCardModule,
    MatPaginatorModule,
    MatSortModule,

    AdminLayoutComponent,
    DefaultLayoutComponent,
    CommentSectionComponent,
    ListBookComponent,
    RouterOutlet,
    RouterLink,
  ],
  exports: [
    AddAccountComponent,
    UpdateAccountComponent,
    DeleteAccountComponent,
    PageAdminComponent,
    ManageBookComponent,
    AddBookComponent,
    UpdateBookComponent,
    DeleteBookComponent,
    ManageCategoryComponent,
    AddCategoryComponent,
    UpdateCategoryComponent,
    DeleteCategoryComponent,
    PageCategoryComponent,
    PageBookDetailComponent,
    PageOrderComponent,
    SigninLayoutComponent,
    PageManageOrderComponent,
    OrderDetailComponent,
    ManageOrderComponent,
    UpdateOrderComponent,
    PopupOrderComponent,
    PageBookComponent
  ],
  providers: [
    { provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher },
  ],
})
export class ShareModule {}
