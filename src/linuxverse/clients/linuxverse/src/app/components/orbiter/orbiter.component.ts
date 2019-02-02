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
  @Input() position: number
  @Input() depth: number
  @Input() starSize: number

  get isStar(): boolean { return this.depth == 0 }

  constructor(
    private el: ElementRef
  ) { }

  ngOnInit() {
    const orbiterElement = this.el.nativeElement.firstChild
  }



}
