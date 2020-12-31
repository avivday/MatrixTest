import { Router } from '@angular/router';
import { LoginService } from './../../shared-resources/services/login.service';
import { Component, OnDestroy } from '@angular/core';
import { RegisterModel } from '../../shared-resources/models';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnDestroy {
  private subs: Subscription = new Subscription();

  registerModel: RegisterModel = { Email: "", Fullname: "", Password: ""};

  constructor(private loginService: LoginService, private router: Router) { }

  register() {
    this.subs.add(this.loginService.register(this.registerModel)
      .subscribe(trainer => this.router.navigateByUrl("/auth/login")))
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
