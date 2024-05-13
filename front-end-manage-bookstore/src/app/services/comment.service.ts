import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Comment } from '../models/comment.model';
import { environment } from '../enviroments/enviroment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private httpClient: HttpClient, private router: Router) { }

  public addComment = (comment : Comment) : Observable<Comment> => {
    return this.httpClient.post<Comment>(`${environment.commentApiUrl}`, comment)
  }

  public getCommentByBookId = (bookId : number) : Observable<Comment[]> => {
    return this.httpClient.get<Comment[]>(`${environment.commentApiUrl}/idBook/${bookId}?$orderBy=CreateAt desc`)
  }
}
