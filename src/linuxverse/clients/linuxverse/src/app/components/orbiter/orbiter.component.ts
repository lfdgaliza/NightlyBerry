import 'src/app/services/extensions/number-extensions'

import { Component, ElementRef, Input, OnInit } from '@angular/core'
import { Orbiter } from 'src/app/services/models/orbiter.model'
import { PositioningService } from 'src/app/services/positioning.service'
import { SizingService } from 'src/app/services/sizing.service'

@Component({
  selector: 'nb-lv-orbiter',
  templateUrl: './orbiter.component.html',
  styleUrls: ['./orbiter.component.scss']
})
export class OrbiterComponent implements OnInit {

  @Input() orbiter: Orbiter
  @Input() position: number
  @Input() depth: number
  @Input() starSize: number

  get isStar(): boolean { return this.depth == 0 }

  constructor(
    private el: ElementRef,
    private sizingService: SizingService,
    private positioningService: PositioningService
  ) { }

  ngOnInit() {
    const orbiterElement = this.el.nativeElement.firstChild

    this.sizingService.setOrbiterSize(orbiterElement, this.starSize, this.depth)
    this.positioningService.placeOrbiter(orbiterElement)
  }



}
