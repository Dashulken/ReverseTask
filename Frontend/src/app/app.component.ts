import {Component} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ConcentrationService} from "./services/concentration.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(public concentrationService: ConcentrationService) {
  }

  form = new FormGroup(
    {
      "C1A": new FormControl(),
      "C2A": new FormControl(),
      "C1C": new FormControl(),
      "C2C": new FormControl()
    }
  )

  Add() {
    this.concentrationService.Add(
      {
        C1A: this.form.value.C1A as number,
        C2A: this.form.value.C2A as number,
        C1C: this.form.value.C1C as number,
        C2C: this.form.value.C2C as number
      }
    );
  }

  Clear() {
    this.concentrationService.Concentrations = []
  }

  criterion: number = 0;
  myText: string = ""

  formCrit = new FormGroup(
    {
      "stopCriterion": new FormControl()
    }
  )

  CalculateCriterion() {
    this.concentrationService.CalculateCriterion()
      .subscribe(
        (result: number) => {
          this.criterion = result;
        }
      )
    this.myText = ""
    if (this.criterion as Number > this.formCrit.value.stopCriterion!) {
      this.myText = "Критерий адекватности больше критерия остановки.Необходимо оптимизировать константы скорости химической реакции"
    } else {
      this.myText = "Константы скорости химической реакции соответствует заданным требованиям"
    }
  }

  Save() {
    this.concentrationService.Save(
      {
        StopCriterion: this.formCrit.value.stopCriterion!
      }).subscribe();
  }
}
