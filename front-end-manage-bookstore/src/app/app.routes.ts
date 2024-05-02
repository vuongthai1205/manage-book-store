import { Routes } from '@angular/router';
import { LoginLayoutComponent } from '../layouts/login-layout/login-layout.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { PageHomeComponent } from './components/page-home/page-home.component';
import { PageAdminComponent } from './components/page-admin/page-admin.component';
import { SigninLayoutComponent } from '../layouts/signin-layout/signin-layout.component';
import { authGuard } from './shared/auth.guard';
import { authAdminGuard } from './shared/auth-admin.guard';
import { ManageAccountComponent } from './components/page-admin/manage-account/manage-account.component';
import { ManageBookComponent } from './components/page-admin/manage-book/manage-book.component';
import { ManageCategoryComponent } from './components/page-admin/manage-category/manage-category.component';
import { PageCategoryComponent } from './components/page-category/page-category.component';
import { PageBookDetailComponent } from './components/page-book-detail/page-book-detail.component';
import { PageOrderComponent } from './components/page-order/page-order.component';

export const routes: Routes = [
  { path: 'login', component: LoginLayoutComponent },
  { path: 'signin', component: SigninLayoutComponent },
  { path: 'category/:id', component: PageCategoryComponent },
  { path: 'book/:id', component: PageBookDetailComponent },
  { path: 'order', component: PageOrderComponent },
  {
    path: 'admin',
    component: PageAdminComponent,
    data: { title: 'Admin' },
    canActivate: [authGuard, authAdminGuard],
    children: [
      {path: 'manage-account', component: ManageAccountComponent},
      {path: 'manage-books', component : ManageBookComponent},
      {path: 'manage-categories', component : ManageCategoryComponent}
    ]
  },
  {
    path: 'home',
    component: PageHomeComponent,
    data: { title: 'Home' }
  },
  { path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];
