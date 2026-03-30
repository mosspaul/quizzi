import { Component, inject } from '@angular/core';
import { TriviaService } from '../services/trivia-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-complete',
  imports: [],
  templateUrl: './complete.html',
  styleUrl: './complete.css',
})
export class Complete {
  triviaService = inject(TriviaService);
  score: number | null = null;
  message: string = "";

  constructor(private router: Router) {}

  ngOnInit() {
        this.triviaService.score.subscribe(score => {
            this.score = score;
        });
        this.message = this.displayMessage();
    }

    displayMessage(): string {
      if (this.score) {
        if (this.score <= 3000) {
          return `Better luck next time, ${this.score} points is not great.`
        }
        else if (this.score <= 6000) {
          return `Not too bad, ${this.score} points could be better.`
        }
        else if (this.score <= 9000) {
          return `Great job, ${this.score} points is amazing.`
        }
        else {
          return `Perfect score! ${this.score}, Ken Jennings better watch out.`
        }
      }
      return "";
    }

    playAgain() {
      this.triviaService.changeScore(0);
      this.router.navigate(["home"]);
    }
}
