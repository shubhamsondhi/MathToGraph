import { Component, OnInit } from '@angular/core';
import { EquationSolverServiceService } from './services/equationSolverService.service';
import { VariableData } from './Models/VariableData';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'MathToGraphClient';
  equationVal = '';
  varData: VariableData[];
  constructor(public equationService: EquationSolverServiceService) {

  }
  ngOnInit() {

    this.varData = ['sdf', 'asdfd', 'csdas'].map(valu => {
      return new VariableData(valu);
    });
    console.log('this.varData', this.varData);
  }


  processIt() {
    this.equationService
      .getEquationVariables(this.equationVal)
      .subscribe(result => {
        console.table(result);

        this.varData = result.map(valu => {
          return new VariableData(valu);
        });
      });
  }
}
