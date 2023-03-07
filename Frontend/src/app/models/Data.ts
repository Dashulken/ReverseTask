import {IConcentration} from "./Concentration";

export interface IData {
  Concentrations?: Array<IConcentration>,
  StopCriterion: number
}
