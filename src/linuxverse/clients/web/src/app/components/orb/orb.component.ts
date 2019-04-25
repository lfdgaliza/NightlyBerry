import 'src/app/services/extensions/number-extensions';

import { animate, AnimationBuilder, AnimationMetadata, AnimationPlayer, keyframes, style } from '@angular/animations';
import { AfterViewInit, Component, ElementRef, EventEmitter, Input, Output } from '@angular/core';
import { Orb } from 'src/app/models/orb.model';
import { Orbiter } from 'src/app/models/orbiter.model';
import { Star } from 'src/app/models/star.model';

@Component({
  selector: "nb-lv-orb",
  templateUrl: "./orb.component.html",
  styleUrls: ["./orb.component.scss"]
})
export class OrbComponent implements AfterViewInit
{
  @Input() orb: Orb

  constructor(
    private el: ElementRef,
    private builder: AnimationBuilder) { }

  ngAfterViewInit()
  {
    const orbiterElement = this.el.nativeElement.firstChild

    this.setOrbiterSize(orbiterElement)
    this.setOrbiterPosition(orbiterElement)

    if (!(this.orb instanceof Star))
    {
      this.configurePath()
      this.animate(orbiterElement)
    }
  }

  configurePath(): any
  {
    const orbiterPathElement = this.el.nativeElement.children[1]
    const pathRadius = Orbiter.calculatePathRadius(this.orb as Orbiter)
    const thisOrbSize = this.orb.calculateSize()

    orbiterPathElement.style.height = (pathRadius * 2).toPxString()
    orbiterPathElement.style.width = (pathRadius * 2).toPxString()
    orbiterPathElement.style.top = ((pathRadius - thisOrbSize) * -1).toPxString()
    orbiterPathElement.style.left = ((pathRadius - thisOrbSize) * -1).toPxString()
  }

  private setOrbiterPosition(orbiterElement: any)
  {
    let topPosition = 0
    let leftPosition = 0

    const orbiterSize = this.orb.calculateSize()

    if ((this.orb instanceof Star))
    {
      topPosition = (orbiterSize / 2) * -1
      leftPosition = topPosition
    }
    else
    {
      topPosition = (<Orbiter>this.orb).parent.calculateSize() / 4 - this.orb.position * orbiterSize
      leftPosition = (<Orbiter>this.orb).parent.calculateSize() / 4
    }

    orbiterElement.style.top = topPosition.toPxString()
    orbiterElement.style.left = leftPosition.toPxString()
  }

  private setOrbiterSize(orbiterElement: any)
  {
    const orbiterSize = this.orb.calculateSize().toPxString()
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
    const vel = this.orb.position + 1 * 10
    const pathRadius = Orbiter.calculatePathRadius(this.orb as Orbiter);

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
