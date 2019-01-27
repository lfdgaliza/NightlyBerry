import { animate, AnimationBuilder, AnimationMetadata, AnimationPlayer, keyframes, style } from '@angular/animations'
import { Component, ElementRef, Input, OnInit } from '@angular/core'
import { Orbiter } from 'src/app/services/models/orbiter'

@Component({
  selector: "nb-lv-orbiter",
  templateUrl: "./orbiter.component.html",
  styleUrls: ["./orbiter.component.scss"]
})
export class OrbiterComponent implements OnInit {
  @Input() orbiter: Orbiter
  @Input() position: number
  @Input() depth: number
  @Input() starSize: number

  private isStar: boolean

  get orbiterSize(): number {
    return this.isStar ? this.starSize : this.starSize / (this.depth + 1)
  }

  get parentOrbiterSize() {
    return this.starSize / this.depth
  }

  get pathRadius() {
    return ((this.position + 1) * this.orbiterSize * 1.2) + this.parentOrbiterSize / 2
  }

  constructor(private el: ElementRef, private builder: AnimationBuilder) { }

  ngOnInit(): void {
    if (this.depth === undefined) {
      this.depth = 0
      this.isStar = true
    }
  }

  ngAfterViewInit() {
    const orbiterElement = this.el.nativeElement.firstChild

    this.setOrbiterSize(orbiterElement)
    this.setOrbiterPosition(orbiterElement)
    if (!this.isStar)
      this.animate(orbiterElement)

    if (!this.isStar) {
      const orbiterPathElement = this.el.nativeElement.children[1]
      orbiterPathElement.style.height = `${this.pathRadius * 2}px`
      orbiterPathElement.style.width = `${this.pathRadius * 2}px`
      orbiterPathElement.style.top = `-${this.pathRadius - this.orbiterSize}px`
      orbiterPathElement.style.left = `-${this.pathRadius - this.orbiterSize}px`
      console.log(orbiterPathElement)
    }

  }

  private setOrbiterPosition(orbiterElement: any) {
    let topPosition = 0
    let leftPosition = 0
    if (this.isStar) {
      topPosition = (this.orbiterSize / 2) * -1
      leftPosition = topPosition
    }
    else {
      topPosition = this.parentOrbiterSize / 4 - this.position * this.orbiterSize
      leftPosition = this.parentOrbiterSize / 4
    }

    orbiterElement.style.top = `${topPosition}px`
    orbiterElement.style.left = `${leftPosition}px`
  }

  private setOrbiterSize(orbiterElement: any) {
    orbiterElement.style.height = `${this.orbiterSize}px`
    orbiterElement.style.width = `${this.orbiterSize}px`
  }

  public animate(orbiter: any): void {
    const factory = this.builder.build(this.translateMetadata())
    const player = factory.create(orbiter)
    this.play(player)
  }

  private play(player: AnimationPlayer = undefined): any {
    player.restart()
    player.onDone(() => {
      this.play(player)
    })
  }

  private translateMetadata(): AnimationMetadata[] {
    const vel = this.position + 1 * 10
    return [
      animate(
        `${vel}s`,
        keyframes([
          style({
            transform: `rotate(0deg) translateY(${this.pathRadius}px)`,
            offset: 0
          }),
          style({
            transform: `rotate(360deg) translateY(${this.pathRadius}px)`,
            offset: 1
          })
        ])
      )
    ]
  }
}
