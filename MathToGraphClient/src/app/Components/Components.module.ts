import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentsComponent } from './Components.component';
import { VariableInputTextBoxComponent } from './VariableInputTextBox/VariableInputTextBox.component';

@NgModule({
  imports: [
    CommonModule,
  ],
  exports:[VariableInputTextBoxComponent],
  declarations: [ComponentsComponent, VariableInputTextBoxComponent]
})
export class ComponentsModule { }
