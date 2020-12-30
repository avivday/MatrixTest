import { Hero } from './shared-resources/models/hero';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sortHeroes'
})
export class SortHeroesPipe implements PipeTransform {

  transform(heroes: Hero[]): Hero[] {
    return heroes && heroes.sort( (a,b) => b.currentPower - a.currentPower);
  }

}
