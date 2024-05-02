import { DialogRef } from '@angular/cdk/dialog';
import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Account } from '../../../../models/account.model';
import { ConfigApiService } from '../../../../services/config-api.service';
import { environment } from '../../../../enviroments/enviroment';
import { roles } from '../../../../shared/constant';

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrl: './add-account.component.scss',
})
export class AddAccountComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<AddAccountComponent>,
    private configApi: ConfigApiService
  ) {}

  roles: any[] = roles
  account: Account = {
    username: '',
    password: '',
    email: '',
    roleId: 0,
    status: '1',
    firstName: '',
    lastName: '',
    dateOfBirth: new Date(),
    gender: '',
    address: '',
    phoneNumber: '',
    languagePreference: '',
    avatar: '',
  };

  onSubmit() {
    this.configApi.addAccount(this.account).subscribe({
      next: (res) => {
        console.log(res);
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
