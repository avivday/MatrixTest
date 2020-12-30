import { Hero } from './../models/hero';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HeroService {

  constructor(private http: HttpClient) { }

  getHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>("/api/heroes");
  }

  trainHero(heroID): Observable<Hero> {
    let headers: HttpHeaders = new HttpHeaders().append('Content-Length', '0');
    return this.http.put<Hero>(`/api/hero/${heroID}/train`, {}, { headers });
  }
}
