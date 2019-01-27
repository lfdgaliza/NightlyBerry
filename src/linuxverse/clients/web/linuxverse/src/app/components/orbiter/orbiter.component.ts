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

    if (!this.isStar) this.setOrbiterPosition(orbiterElement)
  }

  private setOrbiterPosition(orbiterElement: any) {
    console.log(orbiterElement)
    const topPosition =
      this.parentOrbiterSize / 4 - this.position * this.orbiterSize
    const leftPosition = this.parentOrbiterSize / 4
    orbiterElement.style.top = `${topPosition}px`
    orbiterElement.style.left = `${leftPosition}px`

    this.animate(orbiterElement)
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
    const translation = ((this.position + 1) * this.orbiterSize * 2) + this.parentOrbiterSize / 2
    const vel = this.position + 1 * 10
    return [
      animate(
        `${vel}s`,
        keyframes([
          style({
            transform: `rotate(0deg) translateY(${translation}px)`,
            offset: 0
          }),
          style({
            transform: `rotate(360deg) translateY(${translation}px)`,
            offset: 1
          })
        ])
      )
    ]
  }
}
