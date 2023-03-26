import { Test } from 'src/app/core/interfaces/Test';
import { Router, ActivatedRoute } from '@angular/router';
import { TestsService } from 'src/app/core/services/tests.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-complete-test',
  templateUrl: './complete-test.component.html',
  styleUrls: ['./complete-test.component.scss']
})
export class CompleteTestComponent implements OnInit {
  public checked: boolean = false;
  public test!: Test;

  constructor(
    private readonly testsService: TestsService,
    private readonly router: Router,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.testsService.getTest(this.route.snapshot.params['id'])
      .subscribe({
        next: res => {
          this.test = res;
        }
      })
  }

}
