import { Question } from './../../../../core/interfaces/Question';
import { CreateQuestionRequest } from './../../../../core/requests/CreateQuestionRequest';
import { QuestionOption } from './../../../../core/interfaces/Option';
import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Test } from 'src/app/core/interfaces/Test';
import { User } from 'src/app/core/interfaces/User';
import { CreateTestRequest } from 'src/app/core/requests/CreateTestRequest';
import { ModifyTestRequest } from 'src/app/core/requests/ModifyTestRequest';
import { TestsService } from 'src/app/core/services/tests.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  models: QuestionOption[] = [];
  public test!: Test;
  public questions: Question[] = [];
  public users!: User[];
  public displayUsers: User[] = [];
  public requestUsers: string[] = [];
  public createTestGroup: FormGroup = this.fb.group({
    title: this.fb.control('', [Validators.required, Validators.minLength(4), Validators.maxLength(30)]),
    description: this.fb.control('', [Validators.required, Validators.minLength(50), Validators.maxLength(1000)]),
  });
  public optionGroup: FormGroup = this.fb.group({});
  public createQuestionGroup: FormGroup = this.fb.group({
    question: this.fb.control('', Validators.required)
  });
  get title(): any {
    return this.createTestGroup.get('title');
  }
  get description(): any {
    return this.createTestGroup.get('description');
  }
  get question(): any {
    return this.createQuestionGroup.get('question');
  }

  constructor(
    private readonly testsService: TestsService,
    private readonly fb: FormBuilder,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.createModel();
    this.refreshTest();
  }

  addUser(user: User): void {
    this.displayUsers.push(user);
    this.requestUsers.push(user.id);
    this.users = this.users.filter(el => el.id != user.id);
  }

  remove(id: string): void {
    this.users.push(this.displayUsers.filter(el => el.id == id)[0])
    this.displayUsers = this.displayUsers.filter(el => el.id != id);
    this.requestUsers = this.requestUsers.filter(el => el != id);
  }

  modifyTest(): void {
    const request: ModifyTestRequest = {
      id: this.test.id,
      title: this.title.value,
      description: this.description.value,
      userIds: this.requestUsers
    }

    this.testsService.modifyTest(request)
      .subscribe({
        next: res => {
        }
      })
  }

  createModel(): void {
    if (this.models.length < 10) {
      const i = this.models.length;
      this.models.push({
        answer: '',
        isRight: false,
        id: '',
        questionId: ''
      });

      this.optionGroup.addControl('text' + i, this.fb.control('', Validators.required));
      this.optionGroup.addControl('isRight' + i, this.fb.control(false));
    }
  }

  removeModel(): void {
    if (this.models.length > 1)
      this.models.pop();
  }

  addQuestion(): void {
    const formValue = this.optionGroup.value;
    const models: QuestionOption[] = [];

    for (let i = 0; i < this.models.length; i++) {
      models.push({
        answer: formValue['text' + i],
        isRight: formValue['isRight' + i],
        id: '00000000-0000-0000-0000-000000000000',
        questionId: '00000000-0000-0000-0000-000000000000'
      });
    }

    const request: CreateQuestionRequest = {
      testId: this.test.id,
      text: this.question.value,
      options: models
    }

    this.testsService.createQuestion(request)
      .subscribe({
        next: res => {
          this.refreshTest();
        }
      })
  }

  deleteQuestion(event: Event, id: string): void {
    event.stopPropagation();

    this.testsService.deleteQuestion(id)
      .subscribe({
        next: res => {
          this.refreshTest();
        }
      })
  }

  emitQuestion(question: Question): void {
    this.testsService.lastQuestionToModify$.next(question);
    this.testsService.lastOptionsToModify$.next(question.options);
  }

  refreshTest(): void {
    this.testsService.getTest(this.route.snapshot.params['id'])
      .subscribe({
        next: res => {
          this.test = res;
          this.questions = res.questions;

          this.createTestGroup = this.fb.group({
            title: this.fb.control(res.title, [Validators.required, Validators.minLength(4), Validators.maxLength(30)]),
            description: this.fb.control(res.description, [Validators.required, Validators.minLength(50), Validators.maxLength(1000)]),
          })

          this.displayUsers = res.users;
          this.requestUsers = res.users.map(el => el.id)

          this.testsService.getAllUsers()
            .subscribe({
              next: res => {
                const combinedArr = res.concat(this.displayUsers);
                const uniqueArr = combinedArr.filter(item => {
                  return (
                    combinedArr.filter(otherItem => otherItem.id === item.id).length === 1
                  );
                });
                
                this.users = uniqueArr;
                
              }
            })
        }
      })
  }
}
