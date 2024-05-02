import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from '../models/category.model';
import { Observable } from 'rxjs';
import { environment } from '../enviroments/enviroment';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  constructor(private httpClient: HttpClient, private router: Router) {}
  public getAllCategory = (): Observable<Category[]> => {
    return this.httpClient.get<Category[]>(`${environment.categoryApiUrl}`);
  };

  public addCategory = (Category: Category): Observable<Category> => {
    return this.httpClient.post<Category>(
      `${environment.categoryApiUrl}`,
      Category
    );
  };

  public deleteCategory = (id?: number): Observable<HttpResponse<Category>> => {
    return this.httpClient.delete<Category>(
      `${environment.categoryApiUrl}/${id}`,
      { observe: 'response' }
    );
  };

  public updateCategory = (Category: Category): Observable<Category> => {
    return this.httpClient.put<Category>(
      `${environment.categoryApiUrl}/${Category.categoryId}`,
      Category
    );
  };
}
