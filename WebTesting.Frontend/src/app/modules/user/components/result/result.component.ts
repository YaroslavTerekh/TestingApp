import { Result } from './../../../../core/interfaces/Result';
import { TestsService } from 'src/app/core/services/tests.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {
  public testResult!: Result;
  public result!: number;

  constructor(
    private readonly testsService: TestsService
  ) { }

  ngOnInit(): void {
    this.testsService.resultTesting$
      .subscribe({
        next: res => {
          this.testResult = res;
          this.result = Math.floor((this.testResult.point / this.testResult.totalQuestions) * 100);
        }
      })
  }

}
