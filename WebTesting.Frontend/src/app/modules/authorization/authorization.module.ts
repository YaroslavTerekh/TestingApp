import { LoginComponent } from './components/login/login.component';
import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorizationRoutingModule } from './authorization-routing.module';
import { RegisterComponent } from './components/register/register.component';
import { MainComponent } from './components/main/main.component';


@NgModule({
  declarations: [
    RegisterComponent,
    MainComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    AuthorizationRoutingModule,
    SharedModule
  ]
})
export class AuthorizationModule { }
