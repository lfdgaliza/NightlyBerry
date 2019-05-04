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
    const vacuum = this.el.nativeElement.firstChild
    const orbiterElement = vacuum.firstChild

    if (this.orbiter.hasParent)
    {
      this.animateOrbiter(orbiterElement)
    }
  }

  public animateOrbiter(orbiterElement: any): void
  {
    const factory = this.builder.build(this.getOrbiterAnimationMetadata())
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

  private getOrbiterAnimationMetadata(): AnimationMetadata[]
  {
    const vel = (this.orbiter.position + 1) * 5

    return [
      animate(
        `${vel}s`,
        keyframes([
          style({
            transform: `rotate(0deg) translateY(${this.orbiter.pathRadius.asPx()})`
          }),
          style({
            transform: `rotate(360deg) translateY(${this.orbiter.pathRadius.asPx()})`
          })
        ])
      )
    ]
  }

}
