import { Component, OnInit } from '@angular/core';
import { AdminLayoutComponent } from '../../../layouts/admin-layout/admin-layout.component';
import { ConfigApiService } from '../../services/config-api.service';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-page-admin',
  templateUrl: './page-admin.component.html',
  styleUrl: './page-admin.component.scss',
})
export class PageAdminComponent implements OnInit {
  gotoManageAccount() {
    this.router.navigate(["admin/manage-account"])
  }
  constructor(private apiConfig: ConfigApiService, private router: Router) {}
  user: any;
  ngOnInit(): void {
    console.log('page admin init');
  }
}
