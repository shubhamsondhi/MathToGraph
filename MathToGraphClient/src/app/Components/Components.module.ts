import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentsComponent } from './Components.component';
import { VariableInputTextBoxComponent } from './VariableInputTextBox/VariableInputTextBox.component';
import {MatGridListModule} from '@angular/material/grid-list';
import { FormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MatGridListModule
  ],
  exports:[VariableInputTextBoxComponent],
  declarations: [ComponentsComponent, VariableInputTextBoxComponent]
})
export class ComponentsModule { }
