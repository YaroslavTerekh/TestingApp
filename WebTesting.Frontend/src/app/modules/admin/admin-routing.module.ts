import { TestComponent } from './components/test/test.component';
import { AllTestsComponent } from './components/all-tests/all-tests.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuestionComponent } from './components/question/question.component';

const routes: Routes = [
  { path:'admin-all', component: AllTestsComponent },
  { path:'admin-test/:id', component: TestComponent },
  { path:'question/:id', component: QuestionComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
