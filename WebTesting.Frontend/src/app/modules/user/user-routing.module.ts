import { ResultComponent } from './components/result/result.component';
import { TestCompletingComponent } from './components/test-completing/test-completing.component';
import { CompleteTestComponent } from './components/complete-test/complete-test.component';
import { MyTestsComponent } from './components/my-tests/my-tests.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: "my-tests", component: MyTestsComponent },
  { path: "complete-test/:id", component: CompleteTestComponent },
  { path: "completing/:id", component: TestCompletingComponent },
  { path: "result", component: ResultComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
