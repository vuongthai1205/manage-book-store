import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ConfigApiService } from '../../../../services/config-api.service';
import { Account } from '../../../../models/account.model';
import { roles, statuses } from '../../../../shared/constant';

@Component({
  selector: 'app-update-account',
  templateUrl: './update-account.component.html',
  styleUrl: './update-account.component.scss',
})
export class UpdateAccountComponent {
  roles: any[] = roles;
  statuses: any[] = statuses;
  onSubmit() {
    this.configApi.updateAccount(this.account).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
  constructor(
    public dialogRef: MatDialogRef<UpdateAccountComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Account,
    private configApi: ConfigApiService
  ) {}

  account: Account = {
    username: this.data.username,
    password: '',
    email: this.data.email,
    roleId: this.data.roleId,
    status: this.data.status,
    firstName: this.data.firstName,
    lastName: this.data.lastName,
    dateOfBirth: this.data.dateOfBirth,
    gender: this.data.gender,
    address: this.data.address,
    phoneNumber: this.data.phoneNumber,
    languagePreference: this.data.languagePreference,
    avatar: this.data.avatar,
  };
}
