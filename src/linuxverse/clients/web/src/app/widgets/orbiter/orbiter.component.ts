import 'src/app/extensions/number-extensions';

import { animate, AnimationBuilder, AnimationMetadata, AnimationPlayer, keyframes, style } from '@angular/animations';
import { AfterViewInit, Component, ElementRef, Input } from '@angular/core';

import { Orbiter } from './orbiter.model';

@Component({
  selector: 'dg-orbiter',
  templateUrl: './orbiter.component.html',
  styleUrls: ['./orbiter.component.scss']
})
export class OrbiterComponent implements AfterViewInit
{
  constructor(
    private el: ElementRef,
    private builder: AnimationBuilder) { }

  @Input() orbiter: Orbiter

  ngAfterViewInit(): void
  {
    const orbiterElement = this.el.nativeElement.firstChild

    this.setOrbiterSize(orbiterElement)
    this.setOrbiterPosition(orbiterElement)

    if (this.orbiter.hasParent)
    {
      this.configurePath()
      this.animate(orbiterElement)
    }
  }

  configurePath(): any
  {
    const orbiterPathElement = this.el.nativeElement.children[1]
    const pathRadius = this.orbiter.calculatePathRadius()
    const pathDiameter = 2 * pathRadius
    const topLeft = pathRadius - this.orbiter.parent.calculateSize() / 2

    orbiterPathElement.style.height = pathDiameter.asPx()
    orbiterPathElement.style.width = pathDiameter.asPx()
    orbiterPathElement.style.top = (topLeft * -1).asPx()
    orbiterPathElement.style.left = (topLeft * -1).asPx()
  }

  private setOrbiterPosition(orbiterElement: any)
  {
    let topPosition = 0
    let leftPosition = 0

    const orbiterSize = this.orbiter.calculateSize()

    if ((this.orbiter.isStar))
    {
      topPosition = (orbiterSize / 2) * -1
      leftPosition = topPosition
    }
    else
    {
      topPosition = this.orbiter.calculateTopPosition()
      leftPosition = this.orbiter.calculateLeftPosition()
    }

    orbiterElement.style.top = topPosition.asPx()
    orbiterElement.style.left = leftPosition.asPx()
  }

  private setOrbiterSize(orbiterElement: any)
  {
    const orbiterSize = this.orbiter.calculateSize().asPx()
    orbiterElement.style.height = orbiterSize
    orbiterElement.style.width = orbiterSize
  }

  public animate(orbiterElement: any): void
  {
    const factory = this.builder.build(this.translateMetadata())
    const player = factory.create(orbiterElement)
    this.play(player)
  }

  private play(player: AnimationPlayer): void
  {
    player.restart()
    player.onDone(() =>
    {
      this.play(player)
    })
  }

  private translateMetadata(): AnimationMetadata[]
  {
    const vel = this.orbiter.position + 1 * 10
    const pathRadius = this.orbiter.calculatePathRadius()

    return [
      animate(
        `${vel}s`,
        keyframes([
          style({
            transform: `rotate(0deg) translateY(${pathRadius.asPx()})`,
            offset: 0
          }),
          style({
            transform: `rotate(360deg) translateY(${pathRadius.asPx()})`,
            offset: 1
          })
        ])
      )
    ]
  }

}
