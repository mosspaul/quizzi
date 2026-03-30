import { Component, inject, signal, OnInit } from '@angular/core';
import { TriviaService } from '../services/trivia-service';
import { Category } from '../models/category';
import { catchError } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { QuestionParams } from '../models/question-params';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  triviaService = inject(TriviaService);
  categories = signal<Category[]>([]);
  difficulties = ["easy", "medium", "hard"];
  selectedCategory: number = 0;
  selectedDifficulty: string = "";
  questionParams: QuestionParams = {
    Difficulty: 'medium',
    Amount: 10,
    Category: 0,
    Type: ''
  };

  constructor(private router: Router) {}

  ngOnInit() {
    this.getCatagories()

  }

  getCatagories() {
    this.triviaService.getCategories().pipe(catchError(error => {
      console.log(error);
      throw error;
    }))
      .subscribe(data => {
        this.categories.set(data);
      })
  }
  startGame() {
    this.questionParams.Category = this.selectedCategory;
    this.questionParams.Difficulty = this.selectedDifficulty;
    this.triviaService.changeparams(this.questionParams);
    console.log(this.questionParams)
    this.router.navigate(["quiz"]);
  }

}
