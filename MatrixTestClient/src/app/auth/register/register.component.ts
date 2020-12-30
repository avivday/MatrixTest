import { Router } from '@angular/router';
import { LoginService } from './../../shared-resources/services/login.service';
import { Component } from '@angular/core';
import { RegisterModel } from '../../shared-resources/models';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent  {

  registerModel: RegisterModel = { Email: "", Fullname: "", Password: ""};

  constructor(private loginService: LoginService, private router: Router) { }

  register() {
    this.loginService.register(this.registerModel)
      .subscribe(trainer => this.router.navigateByUrl("/auth/login"));
  }
}
