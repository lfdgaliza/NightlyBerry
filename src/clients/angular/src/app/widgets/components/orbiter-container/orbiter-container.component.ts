import { AfterContentInit, Component, ContentChild } from '@angular/core';

import { OrbiterComponent } from '../orbiter/orbiter.component';
import { Orbiter } from '../orbiter/orbiter.model';

@Component({
  selector: 'dg-orbiter-container',
  templateUrl: './orbiter-container.component.html',
  styleUrls: ['./orbiter-container.component.scss']
})
export class OrbiterContainerComponent implements AfterContentInit
{
  constructor() { }

  @ContentChild(OrbiterComponent, {static: false})
  orbiterComponent: OrbiterComponent

  size: number

  ngAfterContentInit(): void
  {
    if (this.orbiterComponent.orbiter === undefined) return;

    const lastChildIndex = this.orbiterComponent.orbiter.children.length - 1
    const lastChild = this.orbiterComponent.orbiter.children[lastChildIndex]
    this.size = (<Orbiter>lastChild).pathDiameter + (<Orbiter>lastChild).size
  }

}
