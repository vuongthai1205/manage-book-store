import { Component, OnInit } from '@angular/core';
import { DefaultLayoutComponent } from '../default-layout/default-layout.component';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ConfigApiService } from '../../app/services/config-api.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Account } from '../../app/models/account.model';
import { roles } from '../../app/shared/constant';

@Component({
  selector: 'app-signin-layout',
  templateUrl: './signin-layout.component.html',
  styleUrl: './signin-layout.component.scss',
})
export class SigninLayoutComponent implements OnInit {
  account: Account = {
    username: '',
    password: '',
    email: '',
    roleId: 0,
    status: '0',
    firstName: '',
    lastName: '',
    dateOfBirth: new Date(),
    gender: '',
    address: '',
    phoneNumber: '',
    languagePreference: '',
    avatar: '',
  };

  constructor(
    public configApi: ConfigApiService,
    public dialog: MatDialog,
    private toastr: ToastrService,
    private router: Router
  ) {}
  onSubmit() {
    this.configApi.registerAccount(this.account).subscribe({
      next: (res) => {
        this.toastr.success('Đăng ký thành công!','Thông báo' );
        this.router.navigate(["login"])
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
  ngOnInit(): void {
    console.log('Add acocunt ');
  }
}
