import { Component, OnInit } from '@angular/core';
import { ConfigApiService } from '../../../services/config-api.service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule, MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { DELETE_ICON, EDIT_ICON } from '../../../shared/icons/share-icon';
import { Dialog } from '@angular/cdk/dialog';
import { AddAccountComponent } from './add-account/add-account.component';
import { MatDialog } from '@angular/material/dialog';
import { UpdateAccountComponent } from './update-account/update-account.component';
import { Account } from '../../../models/account.model';
import { DeleteAccountComponent } from './delete-account/delete-account.component';
@Component({
  selector: 'app-manage-account',
  standalone: true,
  imports: [MatTableModule, MatButtonModule, MatIconModule],
  templateUrl: './manage-account.component.html',
  styleUrl: './manage-account.component.scss',
})
export class ManageAccountComponent implements OnInit {
  openDialogAddAccount() {
    this.dialog.open(AddAccountComponent, {
      height: '80vh',
    });
  }
  openDialogUpdateAccount(i: Account) {
    this.dialog.open(UpdateAccountComponent, {
      height: '80vh',
      data: i,
    });
  }

  openDialogDeleteAccount(i: Account) {
    this.dialog.open(DeleteAccountComponent, {
      data: i,
    });
  }
  constructor(
    private apiConfig: ConfigApiService,
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
  account: Account[] = [];
  displayedColumns: string[] = [
    'username',
    'firstName',
    'lastName',
    'gender',
    'address',
    'avatar',
    'dateOfBirth',
    'email',
    'languagePreference',
    'phoneNumber',
    'roleId',
    'status',
    'action',
  ];
  ngOnInit(): void {
    this.loadAccount();
  }
  loadAccount() {
    this.apiConfig.getAllAccount().subscribe({
      next: (res) => {
        this.account = res;
        console.log(this.account);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
