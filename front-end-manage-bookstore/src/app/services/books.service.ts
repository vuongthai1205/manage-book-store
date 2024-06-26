import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../enviroments/enviroment';
import { Book } from '../models/book.model';
import { Search } from '../models/search.model';

@Injectable({
  providedIn: 'root',
})
export class BooksService {
  constructor(private httpClient: HttpClient, private router: Router) {}

  public getAllBook = (): Observable<Book[]> => {
    return this.httpClient.get<Book[]>(`${environment.bookApiUrl}?$orderBy=CreateAt desc`);
  };

  public getAllBookWithSearch = (searchInput : Search): Observable<Book[]> => {
    return this.httpClient.get<Book[]>(`${environment.bookApiUrl}?$filter=contains(tolower(${searchInput.filterWith}), tolower('${searchInput.content}'))`);
  };
  public getTop4Book = (): Observable<Book[]> => {
    return this.httpClient.get<Book[]>(`${environment.bookApiUrl}?$orderBy=Quantity asc&$top=4`);
  };

  public getAllNewBook = (): Observable<Book[]> => {
    return this.httpClient.get<Book[]>(`${environment.bookApiUrl}?$orderBy=CreateAt desc&$top=4`);
  };

  public getAllBookFilterCategory = (id?: number): Observable<Book[]> => {
    return this.httpClient.get<Book[]>(`${environment.bookApiUrl}?$filter=categoryId eq ${id}`);
  };

  public getBook = (id?: number): Observable<Book[]> => {
    return this.httpClient.get<Book[]>(`${environment.bookApiUrl}?$filter=bookId eq ${id}`);
  };

  public addBook = (book : Book) : Observable<Book> => {
    return this.httpClient.post<Book>(`${environment.bookApiUrl}`, book)
  }

  public deleteBook = (id? : number) : Observable<HttpResponse<Book>> => {
    return this.httpClient.delete<Book>(`${environment.bookApiUrl}/${id}`, {observe: 'response'})
  }

  public updateBook = (book: Book) : Observable<Book> => {
    return this.httpClient.put<Book>(`${environment.bookApiUrl}/${book.bookId}`, book)
  }
}
