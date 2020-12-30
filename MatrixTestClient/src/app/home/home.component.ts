import { LoginService } from './../shared-resources/services/login.service';
import { Hero } from './../shared-resources/models/hero';
import { HeroService } from './../shared-resources/services/hero.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  heroes: Hero[] = [];

  constructor(private heroService: HeroService, private loginService: LoginService) { }

  ngOnInit(): void {
    this.heroService.getHeroes()
      .subscribe(data => this.heroes = data);
  }

  train(heroID: number) {
    this.heroService.trainHero(heroID)
      .subscribe(hero => {
        const heroIndex = this.heroes.findIndex(h => h.id === hero.id);
        this.heroes[heroIndex].currentPower = hero.currentPower;
      });
  }

  logout() {
    this.loginService.logout();
  }

}
