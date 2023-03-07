import {Injectable} from '@angular/core';
import {IConcentration} from "../models/Concentration";
import {HttpClient} from "@angular/common/http";
import {IData} from "../models/Data";

@Injectable({
  providedIn: 'root'
})
export class ConcentrationService {

  constructor(private http: HttpClient) {
  }

  Concentrations: IConcentration[] = []

  Add(concentration: IConcentration) {
    this.Concentrations.push(concentration);
  }

  CalculateCriterion() {
    return this.http.post<number>("/api/Concentration/CalculateCriterion", this.Concentrations).pipe()
  }


  Save(data: IData) {
    data.Concentrations = this.Concentrations
    return this.http.post<number>("/api/Concentration/Save", data).pipe()
  }
}
