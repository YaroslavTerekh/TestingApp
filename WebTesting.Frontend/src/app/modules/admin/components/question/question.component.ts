import { Question } from './../../../../core/interfaces/Question';
import { ModifyQuestionRequest } from './../../../../core/requests/ModifyQuestionRequest';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { QuestionOption } from 'src/app/core/interfaces/Option';
import { CreateQuestionRequest } from 'src/app/core/requests/CreateQuestionRequest';
import { TestsService } from 'src/app/core/services/tests.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  models: QuestionOption[] = [];
  public currentQuestion!: Question;
  public optionGroup: FormGroup = this.fb.group({});
  public createQuestionGroup: FormGroup = this.fb.group({
    question: this.fb.control('', Validators.required)
  });
  get question(): any {
    return this.createQuestionGroup.get('question');
  }

  constructor(
    private readonly testsService: TestsService,
    private readonly fb: FormBuilder,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.testsService.lastQuestionToModify$
      .subscribe({
        next: res => {
          this.currentQuestion = res;
          this.createQuestionGroup = this.fb.group({
            question: this.fb.control(res.questionDescription, Validators.required)
          });
          
          for (let i = 0; i < res.options.length; i++) {
            this.createModel(res.options[i]);
            // this.optionGroup.setControl('text' + i, res.options[i].answer);
            // this.optionGroup.setControl('isRight' + i, res.options[i].isRight);
          }      
        }
      })
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

    const request: ModifyQuestionRequest = {
      id: this.route.snapshot.params['id'],
      text: this.question.value,
      options: models
    }

    this.testsService.modifyQuestion(request)
      .subscribe({
        next: res => {

        }
      })
    
  }

  createModel(option: QuestionOption | null): void {
    if (this.models.length < 10) {
      const i = this.models.length;
      this.models.push({
        answer: '',
        isRight: false,
        id: '',
        questionId: ''
      });

      this.optionGroup.addControl('text' + i, this.fb.control(option == null ? '' : option.answer, Validators.required));
      this.optionGroup.addControl('isRight' + i, this.fb.control(option == null ? '' : option.isRight));
    }
  }

  removeModel(): void {
    if (this.models.length > 1)
      this.models.pop();
  }
}
