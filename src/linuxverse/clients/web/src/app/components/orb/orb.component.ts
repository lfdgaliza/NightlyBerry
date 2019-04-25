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
  @Input() position: number

  @Output() spaceCalculated = new EventEmitter<number>();

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
    const pathRadius = (<Orbiter>this.orb).calculatePathRadius(this.position)

    orbiterPathElement.style.height = (pathRadius * 2).toPxString()
    orbiterPathElement.style.width = (pathRadius * 2).toPxString()
    orbiterPathElement.style.top = ((pathRadius - this.orb.getSize()) * -1).toPxString()
    orbiterPathElement.style.left = ((pathRadius - this.orb.getSize()) * -1).toPxString()
  }

  private setOrbiterPosition(orbiterElement: any)
  {
    let topPosition = 0
    let leftPosition = 0

    const orbiterSize = this.orb.getSize()

    if ((this.orb instanceof Star))
    {
      topPosition = (orbiterSize / 2) * -1
      leftPosition = topPosition
    }
    else
    {
      topPosition = (<Orbiter>this.orb).parent.getSize() / 4 - this.position * orbiterSize
      leftPosition = (<Orbiter>this.orb).parent.getSize() / 4
    }

    orbiterElement.style.top = topPosition.toPxString()
    orbiterElement.style.left = leftPosition.toPxString()
  }

  private setOrbiterSize(orbiterElement: any)
  {
    const orbiterSize = this.orb.getSize().toPxString()
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
    let pathRadius = (<Orbiter>this.orb).calculatePathRadius(this.position)

    if (this.orb.children.length > 0)
    {
      const childrenPathRadius = (<Orbiter>this.orb).calculatePathRadius(this.orb.children.length - 1)
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
