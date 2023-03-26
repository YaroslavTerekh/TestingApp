import { AuthorizationService } from './../../../../core/services/authorization.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  constructor(
    private readonly authorizationService: AuthorizationService,
    private readonly router: Router
  ) { }

  ngOnInit(): void {
    if(this.authorizationService.isAuthorized()) {
      this.router.navigate(['admin-all'])
    }
  }

}
