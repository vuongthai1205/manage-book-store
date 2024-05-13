import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account } from '../models/account.model';
import { environment } from '../enviroments/enviroment';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class ConfigApiService {
  constructor(private http: HttpClient, private router: Router) {}

  public login = (account: Account): Observable<Account> => {
    return this.http.post<Account>(
      `${environment.accountApiUrl}/login`,
      account
    );
  };

  public getAllAccount = (): Observable<Account[]> => {
    return this.http.get<Account[]>(
      `${environment.accountApiUrl}?$orderby=createdAt desc`
    );
  };

  public addAccount = (account: Account): Observable<Account> => {
    return this.http.post<Account>(
      `${environment.accountApiUrl}/admin`,
      account
    );
  };

  public registerAccount = (account: Account): Observable<Account> => {
    return this.http.post<Account>(`${environment.accountApiUrl}`, account);
  };

  public deleteAccount = (username: string): Observable<any> => {
    return this.http.delete<any>(`${environment.accountApiUrl}/${username}`, {
      observe: 'response',
    });
  };

  public updateAccount = (account: Account): Observable<Account> => {
    return this.http.put<Account>(
      `${environment.accountApiUrl}/admin/${account.username}`,
      account
    );
  };

  public currentUser = (): Observable<User> => {
    return this.http.get<User>(`${environment.accountApiUrl}/current-user`);
  };

  public getCurrentUserFromLocal = (): any => {
    const userString = localStorage.getItem('user');
    if (userString !== null) {
      // Kiểm tra nếu giá trị không phải null trước khi parse JSON.
      return JSON.parse(userString);
    } else {
      
    }
  };

  public navigatePage = () => {
    this.currentUser().subscribe({
      next: (res: any) => {
        const userString = JSON.stringify(res);
        localStorage.setItem('user', userString);
        if (res.roleId == 1 || res.roleId == 3) {
          this.router.navigate(['admin']);
        } else {
          this.router.navigate(['home']);
        }
      },
      error: (error) => {
        console.log(error);
      },
    });
  };
}
