import { Component, ElementRef, Input } from '@angular/core';
import { Orbiter } from 'src/app/services/models/orbiter';

@Component({
  selector: 'nb-lv-orbiter',
  templateUrl: './orbiter.component.html',
  styleUrls: ['./orbiter.component.scss']
})
export class OrbiterComponent {
  @Input() orbiter: Orbiter
  @Input() position: number
  @Input() depth: number
  @Input() starSize: number

  constructor(private el: ElementRef) {
    this.depth = this.depth || 0
  }

  ngAfterViewInit() {
    const orbiterElement = this.el.nativeElement.firstChild
    const parentOrbiter = orbiterElement.parentElement.parentElement

    this.resizeOrbiter(parentOrbiter, orbiterElement);

    if (this.orbiter.name == "Moon") {
      console.log(parentOrbiter)
      console.log(orbiterElement)
    }


  }

  private resizeOrbiter(parentOrbiter: any, orbiterElement: any) {
    const newSize = this.depth > 0
      ? this.starSize / (this.depth + 1)
      : this.starSize
    orbiterElement.style.height = `${newSize}px`;
    orbiterElement.style.width = `${newSize}px`;
  }
}
