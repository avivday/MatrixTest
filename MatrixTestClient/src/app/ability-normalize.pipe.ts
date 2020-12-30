import { AbilityEnum } from './shared-resources/enums/AbilityEnum';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'abilityNormalize'
})
export class AbilityNormalizePipe implements PipeTransform {

  transform(ability: AbilityEnum): string {
    if(ability === AbilityEnum.Attacker) {
      return "Attacker"
    } else if(ability === AbilityEnum.Defender) {
      return "Defender";
    }

    return "Unknown";
  }

}
