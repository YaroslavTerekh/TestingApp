import { AuthorizationService } from './../../../../core/services/authorization.service';
import { RegisterRequest } from './../../../../core/requests/RegisterRequest';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public errors: string[] = [];
  public registerGroup: FormGroup = this.fb.group({
    userName: this.fb.control('', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
    firstName: this.fb.control('', [Validators.required, Validators.minLength(2), Validators.maxLength(15)]),
    lastName: this.fb.control('', [Validators.required, Validators.minLength(2), Validators.maxLength(15)]),
    email: this.fb.control('', [Validators.required, Validators.email]),
    password: this.fb.control('', [Validators.required, Validators.minLength(6)]),
  })
  get userName(): any {
    return this.registerGroup.get('userName')
  }
  get firstName(): any {
    return this.registerGroup.get('firstName')
  }
  get lastName(): any {
    return this.registerGroup.get('lastName')
  }
  get email(): any {
    return this.registerGroup.get('email')
  }
  get password(): any {
    return this.registerGroup.get('password')
  }

  constructor(
    private readonly fb: FormBuilder,
    private readonly authorizationService: AuthorizationService,
    private readonly router: Router
  ) { }

  ngOnInit(): void {
  }

  register(): void {
    const request: RegisterRequest = {
      userName: this.userName.value,
      firstName: this.firstName.value,
      lastName: this.lastName.value,
      email: this.email.value,
      password: this.password.value
    };

    if(this.registerGroup.valid) {
      this.authorizationService.register(request)
        .subscribe({
          next: res => {
            this.authorizationService.isAuthorized$.next(true);
            localStorage.setItem('Token', res.token);
            localStorage.setItem('Expires', res.expireTime);
            this.authorizationService.isAuthorized$.next(true);
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
