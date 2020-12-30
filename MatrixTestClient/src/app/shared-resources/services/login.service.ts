import { Router } from '@angular/router';
import { LoginModel, RegisterModel } from './../models';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient, private router: Router) { }

  login(loginModel: LoginModel) {
    return this.http.post("/api/login", loginModel);
  }

  logout() {
    localStorage.removeItem("ticketTimestamp");
    this.router.navigateByUrl("/auth/login")
    this.http.post("/api/logout", {});
  }

  register(registerModel: RegisterModel) {
    return this.http.post("/api/signup", registerModel);
  }
}
