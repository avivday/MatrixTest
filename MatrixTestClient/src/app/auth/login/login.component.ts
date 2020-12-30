import { LoginService } from './../../shared-resources/services/login.service';
import { LoginModel } from '../../shared-resources/models';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  loginModel: LoginModel = { Email: "", Password: ""};

  constructor(private loginService: LoginService, private router: Router) { }

  login() {
    this.loginService.login(this.loginModel)
    .subscribe(
      obs => this.router.navigateByUrl("")
    );
  }

}
