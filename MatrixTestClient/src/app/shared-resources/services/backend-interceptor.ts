import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse
} from '@angular/common/http';

import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { handleError } from '../helpers';

@Injectable()
export class BackendInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>> {

    const request = req.clone({
      url: environment.baseUrl + req.url,
      withCredentials: true
    });

    return next.handle(request).pipe(
      map(event => {
        if(event instanceof HttpResponse) {
          const timestamp = event.headers.get("TicketTimestamp");
          if(timestamp) {
            localStorage.setItem("ticketTimestamp", timestamp);
          }
        }
        return event;
      }),
      catchError(handleError)
    );
  }

}
