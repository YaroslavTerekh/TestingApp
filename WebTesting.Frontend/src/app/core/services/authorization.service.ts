import { environment } from './../../../environments/environment.prod';
import { LoginRequest } from './../requests/LoginRequest';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenResponse } from '../responses/TokenResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor(
    private readonly httpClient: HttpClient
  ) { }

  public login(request: LoginRequest): Observable<TokenResponse> {
    return this.httpClient.post<TokenResponse>(`${environment.apiAddress}/auth/login`, request);
  } 
}
