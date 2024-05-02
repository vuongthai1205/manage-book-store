import { Component, OnInit } from '@angular/core';
import { DefaultLayoutComponent } from '../default-layout/default-layout.component';
import { ConfigApiService } from '../../app/services/config-api.service';
import { Account } from '../../app/models/account.model';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormControl, FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { PopupComponent } from '../../app/components/popup/popup.component';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { appConfig } from '../../app/app.config';

@Component({
  selector: 'app-login-layout',
  standalone: true,
  imports: [
    DefaultLayoutComponent,
    MatInputModule,
    MatSlideToggleModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatDialogModule,
  ],
  templateUrl: './login-layout.component.html',
  styleUrl: './login-layout.component.scss',
})
export class LoginLayoutComponent implements OnInit {
  constructor(
    private store: Store,
    public configApi: ConfigApiService,
    public dialog: MatDialog,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }
  ngOnInit(): void {
    console.log('component layout login init');
  }
  account: Account | any;
  token = '';
  formAccount = new FormGroup({
    username: new FormControl('', { nonNullable: true }),
    password: new FormControl('', { nonNullable: true }),
  });
  goToSigninPage() {
    this.router.navigate(['signin']);
  }
  goToHomePage() {
    this.router.navigate(['home']);
  }
  submitLogin = () => {
    this.account = this.formAccount.value;
    this.configApi.login(this.account).subscribe({
      next: (res:any) => {
        localStorage.setItem('token', res.token)
        this.toastr.success('Login success!','Notification' );
        this.configApi.navigatePage();
        this.formAccount.setValue({ username: '', password: '' });
      },
      error: (error) => {
        this.dialog.open(PopupComponent, {
          data: {
            title: 'Đã có lỗi xảy ra',
            content: error.error.Message
          },
        });
      },
    });
  };
}
