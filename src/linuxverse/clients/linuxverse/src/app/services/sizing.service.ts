import { Injectable } from '@angular/core'

@Injectable({
  providedIn: 'root'
})
export class SizingService {

  constructor() { }

  public setOrbiterSize(orbiterElement: any, starSize: number, depth: number) {
    const orbiterSize = this.calculateOrbiterSize(starSize, depth).toPxString()
    orbiterElement.style.height = orbiterSize
    orbiterElement.style.width = orbiterSize
  }

  public calculateOrbiterSize(starSize: number, depth: number): number {
    return depth == 0
      ? starSize
      : starSize / (depth + 1)
  }
}
