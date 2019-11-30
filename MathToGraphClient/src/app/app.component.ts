import { Component } from '@angular/core';
import { EquationSolverServiceService } from './services/equationSolverService.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MathToGraphClient';
  equationVal = '';
  constructor(public equationService: EquationSolverServiceService) {}
  processIt() {
    console.log('equationVal', this.equationVal);
    this.equationService.getEquationVariables(this.equationVal).subscribe(result => {
      console.table(result);
    });
  }
}
