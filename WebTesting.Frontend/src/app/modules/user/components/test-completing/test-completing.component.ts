import { CheckAnswersRequest } from './../../../../core/requests/CheckAnswersRequest';
import { Answer } from './../../../../core/interfaces/Answer';
import { Question } from './../../../../core/interfaces/Question';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Test } from 'src/app/core/interfaces/Test';
import { TestsService } from 'src/app/core/services/tests.service';

@Component({
  selector: 'app-test-completing',
  templateUrl: './test-completing.component.html',
  styleUrls: ['./test-completing.component.scss']
})
export class TestCompletingComponent implements OnInit {
  public questions!: Question[];
  public index: number = 0;
  public currentQuestion!: Question;
  public answers: Answer[] = [];
  public selectedOptionId: any;

  constructor(
    private readonly testsService: TestsService,
    private readonly router: Router,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.testsService.getTest(this.route.snapshot.params['id'])
      .subscribe({
        next: res => {
          this.questions = res.questions;
          this.currentQuestion = res.questions[0];
        }
      })
  }

  next(): void {
    if(this.selectedOptionId) {
      const answer: Answer = {
        questionId: this.currentQuestion.id,
        optionId: this.selectedOptionId
      }
  
      this.answers.push(answer);
      
      this.index++;
      this.currentQuestion = this.questions[this.index];
    }
  }

  finish(): void {
    const answer: Answer = {
      questionId: this.currentQuestion.id,
      optionId: this.selectedOptionId
    }

    this.answers.push(answer);
    
    const request: CheckAnswersRequest = {
      id: this.currentQuestion.testId,
      checkAnswers: this.answers
    }

    this.testsService.checkAnswers(request)
      .subscribe({
        next: res => {
          this.testsService.resultTesting$.next(res);
          this.router.navigate(['/result']);
        }
      })
  }
}
