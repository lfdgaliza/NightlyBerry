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
    const orbiterElement = this.el.nativeElement.firstChild.firstChild

    if (this.orbiter.hasParent)
      this.animate(orbiterElement)
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
