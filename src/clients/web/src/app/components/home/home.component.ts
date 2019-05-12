import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { distinctUntilChanged, switchMap, tap } from 'rxjs/operators';
import { DistroSearchService } from 'src/app/services/distro-search.service';

export class Distro
{
  id: string;
  name: string;
  logo: string;
  basedOn: string;
}
@Component({
  selector: 'dg-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit
{
  distroCtrl = new FormControl();
  filteredDistros: Observable<Array<Distro>>;
  isLoading: boolean;

  constructor(
    private distroSearchService: DistroSearchService,
    private router: Router) { }

  ngOnInit(): void
  {
    this.filteredDistros = this.distroCtrl.valueChanges.pipe(
      // wait 300ms after each keystroke before considering the term
      //debounceTime(300),

      // ignore new term if same as previous term
      distinctUntilChanged(),

      tap(t => this.isLoading = true),

      // switch to new search observable each time the term changes
      switchMap((term: string) => this.distroSearchService.getDistros(term).pipe(tap(t => this.isLoading = false)))
    )
  }

  showName(distro?: Distro): string | undefined
  {
    return distro ? distro.name : undefined;
  }

  public optionSelected(evt: MatAutocompleteSelectedEvent): void
  {
    this.router.navigateByUrl(`/distro/detail/${(<Distro>evt.option.value).id}`)
  }
}
