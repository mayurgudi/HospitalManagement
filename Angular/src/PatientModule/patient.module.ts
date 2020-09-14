import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PatientAddComponent } from './patient-add/patient-add.component';
import { PatientDisplayComponent } from './patient-display/patient-display.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    PatientAddComponent,
    PatientDisplayComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'Add' , component: PatientAddComponent},
      { path: 'Display' , component: PatientDisplayComponent}
    ])
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})

export class PatientModule { }