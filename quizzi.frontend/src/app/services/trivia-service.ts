import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Category } from '../models/category';
import { QuestionParams } from '../models/question-params';
import { Question } from '../models/question';
import { BehaviorSubject } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class TriviaService {
	http = inject(HttpClient);
	baseUrl = "http://localhost:5287/api/trivia/";
	private paramsSource = new BehaviorSubject<QuestionParams | null>(null);
  	currentparams = this.paramsSource.asObservable();
	private catagoriesSource = new BehaviorSubject<Category[]>([]);
	categories = this.catagoriesSource.asObservable();
	private scoreSource = new BehaviorSubject<number | null>(null);
	score = this.scoreSource.asObservable();

  changeParams(params: QuestionParams) {
    this.paramsSource.next(params);
  }

  setCatagories(categories: Category[]) {
	this.catagoriesSource.next(categories);
  }

  changeScore(score: number) {
	this.scoreSource.next(score);
  }

	getCategories() {
		return this.http.get<Category[]>(`${this.baseUrl}categories`);
	}

	retrieveQuestions(params: QuestionParams) {
		return this.http.post<Question[]>(`${this.baseUrl}questions`, params)
	}
}
