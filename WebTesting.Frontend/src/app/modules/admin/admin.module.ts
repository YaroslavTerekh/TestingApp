import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AllTestsComponent } from './components/all-tests/all-tests.component';
import { TestComponent } from './components/test/test.component';
import { QuestionComponent } from './components/question/question.component';


@NgModule({
  declarations: [
    AllTestsComponent,
    TestComponent,
    QuestionComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ]
})
export class AdminModule { }
