import { Injectable } from '@angular/core';

import { Orbiter } from '../models/orbiter.model';

@Injectable({
  providedIn: 'root'
})
export class SizingService
{

  constructor() { }

  calculatePathRadius(position: number, orbiter: Orbiter)
  {
    const orbiterSize = orbiter.getSize()
    const parentOrbiterSize = orbiter.parent.getSize()

    const radius = ((position + 1) * orbiterSize * 1.2) + parentOrbiterSize / 2

    return radius
  }

}