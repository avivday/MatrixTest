import { AbilityEnum } from './shared-resources/enums/AbilityEnum';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'abilityNormalize'
})
export class AbilityNormalizePipe implements PipeTransform {

  transform(ability: AbilityEnum): string {
    return AbilityEnum[ability];
  }

}
