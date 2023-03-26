import { RegisterRequest } from './../requests/RegisterRequest';
import { environment } from './../../../environments/environment.prod';
import { LoginRequest } from './../requests/LoginRequest';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { TokenResponse } from '../responses/TokenResponse';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  public isAuthorized$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public helper = new JwtHelperService();

  constructor(
    private readonly httpClient: HttpClient
  ) { }

  public getRole(): string {
    if(localStorage.getItem('Token')) {
      return this.helper.decodeToken(localStorage.getItem('Token')!)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    }

    return '';
  }

  public isAuthorized(): boolean {
    if(localStorage.getItem('Expires')) {
      let tokenExpires: Date = new Date(Date.parse(localStorage.getItem('Expires')!.toString()))
      let today: Date = new Date(Date.now());
  
      return today < tokenExpires;
    }

    return false;
  }

  public logOut(): void {
    localStorage.removeItem('Token');
    localStorage.removeItem('Expires');
  }

  public login(request: LoginRequest): Observable<TokenResponse> {
    return this.httpClient.post<TokenResponse>(`${environment.apiAddress}/auth/login`, request);
  } 

  public register(request: RegisterRequest): Observable<TokenResponse> {
    return this.httpClient.post<TokenResponse>(`${environment.apiAddress}/auth/register`, request);
  }
}
