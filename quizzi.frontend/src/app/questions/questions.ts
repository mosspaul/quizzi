import { Component, inject, signal } from '@angular/core';
import { TriviaService } from '../services/trivia-service';
import { QuestionParams } from '../models/question-params';
import { catchError } from 'rxjs';
import { Question } from '../models/question';
import { decode } from 'html-entities';
import { Router } from '@angular/router';
import { NgClass } from '@angular/common';

@Component({
    selector: 'app-questions',
    imports: [NgClass],
    templateUrl: './questions.html',
    styleUrl: './questions.css',
})
export class Questions {
    triviaService = inject(TriviaService);
    questionParams: QuestionParams | null = null;
    questions = signal<Question[]>([]);
    currentQuestion = signal<Question | null>(null);
    currentAnswer: string | null = null;
    correct: boolean | null = null;
    score: number = 0;
    questionNumber: number = 0;

    constructor(private router: Router) {}

    ngOnInit() {
        this.triviaService.currentparams.subscribe(params => {
            this.questionParams = params;
            this.retrieveQuestions();
        });
    }

    retrieveQuestions() {
        if (!this.questionParams) return;

        this.triviaService.retrieveQuestions(this.questionParams)
            .pipe(catchError(err => { console.error(err); throw err; }))
            .subscribe(data => {
                this.questions.set(data);
                this.organizeQuestion(data[0]);
            });
    }

    organizeQuestion(question: Question) {
        this.formatStrings(question);
        const answers = [...question.incorrectAnswers, question.correctAnswer]
            .map(value => ({ value, sort: Math.random() }))
            .sort((a, b) => a.sort - b.sort)
            .map(({ value }) => value);

        question.incorrectAnswers = answers;
        this.currentQuestion.set(question);
        console.log(this.currentQuestion);
    }

    validateAnswer() {
        if (this.currentAnswer == null) {
            alert("Select an answer!");
        }
        else if (this.currentAnswer === this.currentQuestion()?.correctAnswer) {
            this.score++;
            this.correct = true;
        } else {
            this.correct = false;
        }
        //setTimeout(() => this.moveToNextQuestion(), 5000);
    }

    setAnswer(answer: string) {
        this.currentAnswer = answer === this.currentAnswer ? null : answer;
    }
    isSelectedAnswer(answer: string) {
        return answer === this.currentAnswer;
    }

    moveToNextQuestion() {
        this.correct = null
        this.questionNumber++;
        if (this.questionNumber >= this.questions().length) {
            this.router.navigate(["quiz/complete"]);
        }
        else {
            const next = this.questions()[this.questionNumber];
        if (next) this.organizeQuestion(next);
        }
    }

    formatStrings(question: Question) {
        question.question= decode(question.question);
        question.correctAnswer = decode(question.correctAnswer);
        question.incorrectAnswers.forEach((_) => decode(_));
    }
}
