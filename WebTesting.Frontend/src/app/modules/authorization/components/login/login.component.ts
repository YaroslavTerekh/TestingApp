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
    private readonly authorizationService: AuthorizationService
  ) { }

  ngOnInit(): void {
  }

  public login(): void {
    let request: LoginRequest = {
      email: this.email.value,
      password: this.password.value
    };

    this.authorizationService.login(request)
      .subscribe({
        next: res => {
          console.log(res);          
        }
      })
  }
}
