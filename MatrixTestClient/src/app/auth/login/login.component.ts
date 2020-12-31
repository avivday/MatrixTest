import { LoginService } from './../../shared-resources/services/login.service';
import { LoginModel } from '../../shared-resources/models';
import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnDestroy {

  private subs: Subscription = new Subscription();

  loginModel: LoginModel = { Email: "", Password: ""};

  constructor(private loginService: LoginService, private router: Router) { }

  login() {
    this.subs.add(this.loginService.login(this.loginModel)
    .subscribe(
      obs => this.router.navigateByUrl("")
    ));
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

}
