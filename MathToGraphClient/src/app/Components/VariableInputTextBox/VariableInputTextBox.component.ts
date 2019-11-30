import {
  Component,
  OnInit,
  Input,
  OnChanges,
  SimpleChanges
} from '@angular/core';
import { VariableData } from 'src/app/Models/VariableData';

@Component({
  selector: "app-VariableInputTextBox",
  templateUrl: './VariableInputTextBox.component.html',
  styleUrls: ['./VariableInputTextBox.component.css']
})
export class VariableInputTextBoxComponent implements OnInit, OnChanges {
  @Input() varData: VariableData;
  isValid = false;
  constructor() {
    this.varData = new VariableData('');
    this.checkValidity();
  }
  ngOnChanges(simple: SimpleChanges) {}
  ngOnInit() {}

  checkValidity() {
    const isNumberWithComma = new RegExp('^\\d+([,\\.]?\\d+)*$');

    const data = this.varData.data;

    this.isValid =
      isNumberWithComma.test(data) || this.varData.data.length === 0;
    console.log('this.isValid', this.isValid);
  }
}
