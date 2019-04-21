import 'src/app/services/extensions/number-extensions';

import { animate, AnimationBuilder, AnimationMetadata, AnimationPlayer, keyframes, style } from '@angular/animations';
import { Component, ElementRef, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Orb } from 'src/app/services/models/orb.model';
import { Orbiter } from 'src/app/services/models/orbiter.model';
import { SizingService } from 'src/app/services/sizing.service';

@Component({
  selector: "nb-lv-orb",
  templateUrl: "./orb.component.html",
  styleUrls: ["./orb.component.scss"]
})
export class OrbComponent implements OnInit
{
  @Input() orb: Orb
  @Input() position: number
  @Input() depth: number

  @Output() spaceCalculated = new EventEmitter<number>();

  onSpaceCalculated(space: number)
  {

  }

  private isStar: boolean

  constructor(
    private el: ElementRef,
    private builder: AnimationBuilder,
    private sizingService: SizingService) { }

  ngOnInit(): void
  {
    if (this.depth === undefined)
    {
      this.depth = 0
      this.isStar = true
    }
  }

  ngAfterViewInit()
  {
    const orbiterElement = this.el.nativeElement.firstChild

    this.setOrbiterSize(orbiterElement)
    this.setOrbiterPosition(orbiterElement)

    if (!this.isStar)
    {
      this.configurePath()
      this.animate(orbiterElement)
    }
  }

  configurePath(): any
  {
    const orbiterPathElement = this.el.nativeElement.children[1]
    const pathRadius = this.sizingService.calculatePathRadius(this.position, (<Orbiter>this.orb))

    orbiterPathElement.style.height = (pathRadius * 2).toPxString()
    orbiterPathElement.style.width = (pathRadius * 2).toPxString()
    orbiterPathElement.style.top = ((pathRadius - this.orb.size) * -1).toPxString()
    orbiterPathElement.style.left = ((pathRadius - this.orb.size) * -1).toPxString()
  }

  private setOrbiterPosition(orbiterElement: any)
  {
    let topPosition = 0
    let leftPosition = 0

    const orbiterSize = this.orb.size

    if (this.isStar)
    {
      topPosition = (orbiterSize / 2) * -1
      leftPosition = topPosition
    }
    else
    {
      topPosition = (<Orbiter>this.orb).parent.size / 4 - this.position * orbiterSize
      leftPosition = (<Orbiter>this.orb).parent.size / 4
    }

    orbiterElement.style.top = topPosition.toPxString()
    orbiterElement.style.left = leftPosition.toPxString()
  }

  private setOrbiterSize(orbiterElement: any)
  {
    const orbiterSize = this.orb.size.toPxString()
    orbiterElement.style.height = orbiterSize
    orbiterElement.style.width = orbiterSize
  }

  public animate(orbiter: any): void
  {
    const factory = this.builder.build(this.translateMetadata())
    const player = factory.create(orbiter)
    this.play(player)
  }

  private play(player: AnimationPlayer = undefined): any
  {
    player.restart()
    player.onDone(() =>
    {
      this.play(player)
    })
  }

  private translateMetadata(): AnimationMetadata[]
  {
    const vel = this.position + 1 * 10
    let pathRadius = this.sizingService.calculatePathRadius(this.position, (<Orbiter>this.orb))

    if (this.orb.children.length > 0)
    {
      const childrenPathRadius = this.sizingService.calculatePathRadius(this.orb.children.length - 1, (<Orbiter>this.orb))
      pathRadius += childrenPathRadius
    }

    this.spaceCalculated.emit(pathRadius)

    return [
      animate(
        `${vel}s`,
        keyframes([
          style({
            transform: `rotate(0deg) translateY(${pathRadius.toPxString()})`,
            offset: 0
          }),
          style({
            transform: `rotate(360deg) translateY(${pathRadius.toPxString()})`,
            offset: 1
          })
        ])
      )
    ]
  }
}
