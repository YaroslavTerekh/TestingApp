import { AuthorizationService } from './core/services/authorization.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'WebTesting.Frontend';
  isAuthorized: boolean = false;

  constructor(
    private readonly authorizationService: AuthorizationService
  ) {}

  ngOnInit(): void {
    this.authorizationService.isAuthorized$
      .subscribe({
        next: res => {
          console.log(res);
          
          this.isAuthorized = res;
        }
      })
      
    let tokenExpires: Date = new Date(Date.parse(localStorage.getItem('Expires')!.toString()))
    let today: Date = new Date(Date.now());

    if(today > tokenExpires) {
      localStorage.removeItem('Token');
      localStorage.removeItem('Expires');
    } else {
      this.authorizationService.isAuthorized$.next(true);
    }

    
  }

  logout(): void {
    this.authorizationService.logOut();
    this.authorizationService.isAuthorized$.next(false);
  }
}
