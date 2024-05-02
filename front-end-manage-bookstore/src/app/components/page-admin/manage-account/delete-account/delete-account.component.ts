import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ConfigApiService } from '../../../../services/config-api.service';
import { Account } from '../../../../models/account.model';

@Component({
  selector: 'app-delete-account',
  templateUrl: './delete-account.component.html',
  styleUrl: './delete-account.component.scss',
})
export class DeleteAccountComponent {
  onDelete() {
    console.log(this.data.username);
    this.configApi.deleteAccount(this.data.username).subscribe({
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
    public dialogRef: MatDialogRef<DeleteAccountComponent>,
    private configApi: ConfigApiService,
    @Inject(MAT_DIALOG_DATA) public data: Account
  ) {}
}
