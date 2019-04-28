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

    const pathDiameter = 2 * this.orbiter.pathRadius
    const topLeft = -1 * (this.orbiter.pathRadius - this.orbiter.parent.size / 2)

    orbiterPathElement.style.height
      = orbiterPathElement.style.width
      = pathDiameter.asPx()

    orbiterPathElement.style.top
      = orbiterPathElement.style.left
      = topLeft.asPx()
  }

  private setOrbiterPosition(orbiterElement: any)
  {
    orbiterElement.style.top = this.orbiter.calculateTopPosition().asPx()
    orbiterElement.style.left = this.orbiter.calculateLeftPosition().asPx()
  }

  private setOrbiterSize(orbiterElement: any)
  {
    orbiterElement.style.height
      = orbiterElement.style.width
      = this.orbiter.size.asPx()
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
    const vel = (this.orbiter.position + 1) * 5

    return [
      animate(
        `${vel}s`,
        keyframes([
          style({
            transform: `rotate(0deg) translateY(${this.orbiter.pathRadius.asPx()})`,
            offset: 0
          }),
          style({
            transform: `rotate(360deg) translateY(${this.orbiter.pathRadius.asPx()})`,
            offset: 1
          })
        ])
      )
    ]
  }

}
