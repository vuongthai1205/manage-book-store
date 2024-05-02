import { Component, Input, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Comment } from '../../../models/comment.model';
import { CommonModule } from '@angular/common';
import { CommentService } from '../../../services/comment.service';

@Component({
  selector: 'app-comment-section',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './comment-section.component.html',
  styleUrls: ['./comment-section.component.scss'], // Corrected from styleUrl to styleUrls
})
export class CommentSectionComponent implements OnInit {
  @Input() bookId: number = 0;
  username: string = '';
  comment: Comment = {
    bookId: 0,
    username: '',
    content: '',
  };
  comments: Comment[] = [];

  constructor(private fb: FormBuilder, private httpComment: CommentService) {
    // Initialize the comment with the user's username from local storage
    const userJson = localStorage.getItem('user');
    if (userJson) {
      try {
        const user = JSON.parse(userJson);
        this.username = user.username || ''; // Set username if it exists, else empty string
      } catch (error) {
        console.error('Error parsing user from local storage:', error);
      }
    }
  }

  ngOnInit(): void {
    this.comment = {
      bookId: this.bookId,
      username: this.username,
      content: '',
    };
    this.loadComments()
  }

  loadComments(){
    this.httpComment.getCommentByBookId(this.bookId).subscribe({
      next: (res) => {
        this.comments = res 
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  submitComment(): void {
    console.log(this.bookId);

    console.log(this.comment);
    this.httpComment.addComment(this.comment).subscribe({
      next: (res) => {
        console.log(res);
        this.loadComments()
      },
      error: (err) => {
        console.log(err);
      },
    });

  }
}
