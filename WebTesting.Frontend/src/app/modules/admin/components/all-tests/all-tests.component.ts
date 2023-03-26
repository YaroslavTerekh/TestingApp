import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreateTestRequest } from './../../../../core/requests/CreateTestRequest';
import { TestsService } from './../../../../core/services/tests.service';
import { AuthorizationService } from './../../../../core/services/authorization.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/core/interfaces/User';
import { Test } from 'src/app/core/interfaces/Test';

@Component({
  selector: 'app-all-tests',
  templateUrl: './all-tests.component.html',
  styleUrls: ['./all-tests.component.scss']
})
export class AllTestsComponent implements OnInit {
  public users!: User[];
  public displayUsers: User[] = [];
  public requestUsers: string[] = [];
  public allTests: Test[] = [];
  public createTestGroup: FormGroup = this.fb.group({
    title: this.fb.control('', [Validators.required, Validators.minLength(4), Validators.maxLength(30)]),
    description: this.fb.control('', [Validators.required, Validators.minLength(50), Validators.maxLength(1000)]),
  })
  get title(): any {
    return this.createTestGroup.get('title');
  }
  get description(): any {
    return this.createTestGroup.get('description');
  }

  constructor(
    private readonly testsService: TestsService,
    private readonly fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.testsService.getAllUsers()
      .subscribe({
        next: res => {
          this.users = res;
        }
      })

    this.testsService.getAllTests()
      .subscribe({
        next: res => {
          this.allTests = res;
        }
      })
  }

  addUser(user: User): void {
    this.displayUsers.push(user);
    this.requestUsers.push(user.id);
    this.users = this.users.filter(el => el.id != user.id);
  }

  remove(id: string): void {
    this.users.push(this.displayUsers.filter(el => el.id == id)[0])
    this.displayUsers = this.displayUsers.filter(el => el.id != id);
    this.requestUsers = this.requestUsers.filter(el => el != id);    
  }

  createTest(): void {
    const request: CreateTestRequest = {
      title: this.title.value,
      description: this.description.value,
      userIds: this.requestUsers
    }

    this.testsService.createTest(request)
      .subscribe({
        next: res => {
          this.testsService.getAllTests()
            .subscribe({
              next: res => {
                this.allTests = res;
              }
            })
        }
      })    
  }

  deleteTest(event: Event, id: string) {
    event.stopPropagation();

    this.testsService.deleteTest(id)
      .subscribe({
        next: res => {
          this.testsService.getAllTests()
            .subscribe({
              next: res => {
                this.allTests = res;
              }
            })
        }
      })
  }
}
