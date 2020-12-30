import { AbilityEnum } from './../enums/AbilityEnum';

export interface Hero {
  id: number;
  name: string;
  guidID: string;
  ability: AbilityEnum;
  suitColor: string;
  startingPower: number;
  currentPower: number;
  firstTrainingDate: Date;
}
