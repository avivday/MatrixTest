import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserGuardGuard implements CanActivate {

  constructor(private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const now = new Date();
    const ticketTime = localStorage.getItem("ticketTimestamp");

    if (!ticketTime || now > new Date(+ticketTime)) {
      this.router.navigateByUrl('/auth/login');
      return false;
    }

    return true;
  }
}
