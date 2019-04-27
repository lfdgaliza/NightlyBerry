import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { OrbiterComponent } from './orbiter/orbiter.component';

@NgModule({
  declarations: [OrbiterComponent],
  imports: [
    CommonModule
  ],
  exports: [
    OrbiterComponent
  ]
})
export class WidgetsModule { }
