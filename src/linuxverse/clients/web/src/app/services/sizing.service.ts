import { Injectable } from '@angular/core'

@Injectable({
  providedIn: 'root'
})
export class SizingService {

  constructor() { }

  calculateOrbiterSize(starSize: number, depth: number): number {
    return depth == 0
      ? starSize
      : starSize / (depth + 1)
  }

  calculatePathRadius(starSize: number, depth: number, position: number) {
    const orbiterSize = this.calculateOrbiterSize(starSize, depth)
    const parentOrbiterSize = this.calculateOrbiterSize(starSize, depth - 1)

    const radius = ((position + 1) * orbiterSize * 1.2) + parentOrbiterSize / 2

    return radius
  }

}