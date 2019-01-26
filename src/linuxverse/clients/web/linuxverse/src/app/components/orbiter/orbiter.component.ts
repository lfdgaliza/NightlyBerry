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

  constructor(private el: ElementRef) {
    this.depth = this.depth || 0
  }

  ngAfterViewInit() {
    const orbiterElement = this.el.nativeElement.firstChild
    const parentOrbiter = orbiterElement.parentElement.parentElement

    this.resizeOrbiter(parentOrbiter, orbiterElement);


  }


  private resizeOrbiter(parentOrbiter: any, orbiterElement: any) {
    if (this.depth > 0) {
      const newSize = parentOrbiter.clientHeight / (this.depth + 1);
      orbiterElement.style.height = `${newSize}px`;
      orbiterElement.style.width = `${newSize}px`;
    }
  }
}
