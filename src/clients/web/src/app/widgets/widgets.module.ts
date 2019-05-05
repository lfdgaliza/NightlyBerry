import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { OrbiterContainerComponent } from './components/orbiter-container/orbiter-container.component';
import { OrbiterComponent } from './components/orbiter/orbiter.component';

@NgModule({
  declarations: [OrbiterComponent, OrbiterContainerComponent],
  imports: [
    CommonModule
  ],
  exports: [
    OrbiterComponent,
    OrbiterContainerComponent
  ]
})
export class WidgetsModule { }
