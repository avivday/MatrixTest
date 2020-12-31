import { Subscription } from 'rxjs';
import { LoginService } from './../shared-resources/services/login.service';
import { Hero } from './../shared-resources/models/hero';
import { HeroService } from './../shared-resources/services/hero.service';
import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  private subs: Subscription = new Subscription();

  heroes: Hero[] = [];

  constructor(private heroService: HeroService, private loginService: LoginService) { }

  ngOnInit(): void {
    this.subs.add(this.heroService.getHeroes()
      .subscribe(data => this.heroes = data));
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  train(heroID: number) {
    this.subs.add(this.heroService.trainHero(heroID)
      .subscribe(hero => {
        const heroIndex = this.heroes.findIndex(h => h.id === hero.id);
        this.heroes[heroIndex].currentPower = hero.currentPower;
      }));
  }

  logout() {
    this.loginService.logout();
  }

}
