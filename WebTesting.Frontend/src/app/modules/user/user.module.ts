import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { MyTestsComponent } from './components/my-tests/my-tests.component';
import { CompleteTestComponent } from './components/complete-test/complete-test.component';
import { ResultComponent } from './components/result/result.component';
import { TestCompletingComponent } from './components/test-completing/test-completing.component';


@NgModule({
  declarations: [
    MyTestsComponent,
    CompleteTestComponent,
    ResultComponent,
    TestCompletingComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    SharedModule
  ]
})
export class UserModule { }
