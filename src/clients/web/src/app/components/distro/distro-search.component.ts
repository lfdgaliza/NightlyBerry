import { animate, AnimationBuilder, AnimationPlayer, style } from '@angular/animations';
import { AfterViewInit, Component, ElementRef, OnInit, Renderer2 } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { distinctUntilChanged, switchMap } from 'rxjs/operators';
import { DistroSearchService } from 'src/app/services/distro-search.service';

export class Distro
{
  id: string;
  name: string;
  logo: string;
  basedOn: string;
}
@Component({
  selector: 'dg-distro-search',
  templateUrl: './distro-search.component.html',
  styleUrls: ['./distro-search.component.scss']
})
export class HomeComponent implements OnInit, AfterViewInit
{
  distroCtrl = new FormControl();
  filteredDistros: Observable<Array<Distro>>;

  constructor(
    private distroSearchService: DistroSearchService,
    private router: Router,
    private builder: AnimationBuilder,
    private el: ElementRef,
    private renderer: Renderer2) { }

  ngOnInit(): void
  {
    this.filteredDistros = this.distroCtrl.valueChanges.pipe(
      distinctUntilChanged(),
      switchMap((term: string) => this.distroSearchService.getDistros(term))
    )
  }

  ngAfterViewInit(): void
  {
    const player = this.fadeInSearchPlayer()
    player.play()
    player.onDone(() => this.renderer.selectRootElement("#searchInput").focus())
  }

  showName(distro?: Distro): string | undefined
  {
    return distro ? distro.name : undefined;
  }

  public optionSelected(evt: MatAutocompleteSelectedEvent): void
  {
    const player = this.fadeOutSearchPlayer();
    player.onDone(() => this.router.navigateByUrl(`/distro/detail/${(<Distro>evt.option.value).id}`));
    player.play()
  }

  public fadeInSearchPlayer(): AnimationPlayer
  {
    const metadata = animate(`300ms ease-in`, style({ opacity: `1` }))
    const factory = this.builder.build(metadata)
    return factory.create(this.el.nativeElement.firstChild)
  }

  public fadeOutSearchPlayer(): AnimationPlayer
  {
    const metadata = animate(`250ms ease-in`, style({ opacity: `0` }))
    const factory = this.builder.build(metadata)
    return factory.create(this.el.nativeElement)
  }
}
