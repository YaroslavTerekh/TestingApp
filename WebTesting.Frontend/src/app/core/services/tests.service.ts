import { Answer } from './../interfaces/Answer';
import { Result } from './../interfaces/Result';
import { QuestionOption } from './../interfaces/Option';
import { Question } from './../interfaces/Question';
import { CreateQuestionRequest } from './../requests/CreateQuestionRequest';
import { RegisterRequest } from './../requests/RegisterRequest';
import { CreateTestRequest } from './../requests/CreateTestRequest';
import { environment } from './../../../environments/environment';
import { Observable, ReplaySubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../interfaces/User';
import { Test } from '../interfaces/Test';
import { ModifyTestRequest } from '../requests/ModifyTestRequest';
import { ModifyQuestionRequest } from '../requests/ModifyQuestionRequest';
import { CheckAnswersRequest } from '../requests/CheckAnswersRequest';

@Injectable({
  providedIn: 'root'
})
export class TestsService {
  public lastQuestionToModify$: ReplaySubject<Question> = new ReplaySubject<Question>(1);
  public lastOptionsToModify$: ReplaySubject<QuestionOption[]> = new ReplaySubject<QuestionOption[]>(1);
  public resultTesting$: ReplaySubject<Result> = new ReplaySubject<Result>(1);

  constructor(
    private readonly httpClient: HttpClient
  ) { }

  public getAllUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(`${environment.apiAddress}/test/all-users`);
  }

  public getAllTests(): Observable<Test[]> {
    return this.httpClient.get<Test[]>(`${environment.apiAddress}/test`);
  }

  public getTest(id: string): Observable<Test> {
    return this.httpClient.get<Test>(`${environment.apiAddress}/testings/${id}`);
  }

  public getMyTests(): Observable<Test[]> {
    return this.httpClient.get<Test[]>(`${environment.apiAddress}/testings/mine`);
  }

  public deleteTest(id: string): Observable<any> {
    return this.httpClient.delete(`${environment.apiAddress}/test/${id}`);
  }

  public deleteQuestion(id: string): Observable<any> {
    return this.httpClient.delete(`${environment.apiAddress}/test/question/${id}`);
  }

  public createTest(request: CreateTestRequest): Observable<any> {
    return this.httpClient.post(`${environment.apiAddress}/test/create`, request);
  }

  public createQuestion(request: CreateQuestionRequest): Observable<any> {
    return this.httpClient.post(`${environment.apiAddress}/test/create/question`, request);
  }
  
  public modifyTest(request: ModifyTestRequest): Observable<any> {
    return this.httpClient.put(`${environment.apiAddress}/test/modify`, request);
  }

  public modifyQuestion(request: ModifyQuestionRequest): Observable<any> {
    return this.httpClient.put(`${environment.apiAddress}/test/modify/question`, request);
  }

  public checkAnswers(request: CheckAnswersRequest): Observable<Result> {
    return this.httpClient.post<Result>(`${environment.apiAddress}/testings/complete`, request);
  }
}
