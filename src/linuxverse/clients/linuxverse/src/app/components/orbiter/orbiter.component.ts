import 'src/app/services/extensions/number-extensions'

import { Component, ElementRef, Input, OnInit } from '@angular/core'

import { Orbiter } from '../../services/models/orbiter.model'

@Component({
  selector: 'nb-lv-orbiter',
  templateUrl: './orbiter.component.html',
  styleUrls: ['./orbiter.component.scss']
})
export class OrbiterComponent implements OnInit {

  @Input() orbiter: Orbiter
  @Input() starSize: number
  @Input() factor: number

  constructor(
    private el: ElementRef
  ) { }

  ngOnInit() {
    const orbiterElement = this.el.nativeElement.firstChild
    const orbiterSize = this.orbiter.getSize(this.starSize, this.factor)

    // Sizing
    orbiterElement.style.height = orbiterSize.toPxString()
    orbiterElement.style.width = orbiterSize.toPxString()

    // Centralizing
    if (this.orbiter.isStar) {
      const margin = ((orbiterSize / 2) * -1).toPxString()
      orbiterElement.style.marginLeft = margin
      orbiterElement.style.marginTop = margin
    } else {
      const parentSize = this.orbiter.parent.getSize(this.starSize, this.factor)
      const remainingSpace = (1 - this.factor) * parentSize
      orbiterElement.style.marginLeft = (remainingSpace / 2).toPxString()
    }
  }



}
