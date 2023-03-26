import { Router } from '@angular/router';
import { AuthorizationService } from './../../../../core/services/authorization.service';
import { LoginRequest } from './../../../../core/requests/LoginRequest';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public errors!: string[];
  public loginGroup: FormGroup = this.fb.group({
    email: this.fb.control('', [Validators.required, Validators.email, Validators.minLength(5)]),
    password: this.fb.control('', Validators.required)
  });
  get email(): any {
    return this.loginGroup.get('email');
  }
  get password(): any {
    return this.loginGroup.get('password');
  }

  constructor(
    private readonly fb: FormBuilder,
    private readonly authorizationService: AuthorizationService,
    private readonly router: Router
  ) { }

  ngOnInit(): void {
  }

  public login(): void {
    const request: LoginRequest = {
      email: this.email.value,
      password: this.password.value
    };    

    if (this.loginGroup.valid) {
      this.authorizationService.login(request)
        .subscribe({
          next: res => {
            this.authorizationService.isAuthorized$.next(true);
            localStorage.setItem('Token', res.token);
            localStorage.setItem('Expires', res.expireTime);
            if(this.authorizationService.getRole() == "Admin") {
              this.router.navigate(['/admin-all'])
            } else if (this.authorizationService.getRole() == "SimpleUser") {
              this.router.navigate(['/my-tests'])
            };
          },
          error: err => {
            if(err.error) {
              this.errors = [];
              this.errors.push(err.error);
            } else {
              this.errors = err.errors;
            }            
          }
        })
    }
  }
}
