import { TestsService } from 'src/app/core/services/tests.service';
import { Test } from 'src/app/core/interfaces/Test';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-my-tests',
  templateUrl: './my-tests.component.html',
  styleUrls: ['./my-tests.component.scss']
})
export class MyTestsComponent implements OnInit {
  public allTests!: Test[];

  constructor(
    private readonly testsService: TestsService
  ) { }

  ngOnInit(): void {
    this.testsService.getMyTests()
      .subscribe({
        next: res => {
          this.allTests = res;
        }
      })
  }

}
