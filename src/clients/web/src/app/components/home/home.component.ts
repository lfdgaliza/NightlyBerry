import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
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
export class HomeComponent
{

  distroCtrl = new FormControl();
  filteredDistros: Observable<Distro[]>;

  constructor(distroSearchService: DistroSearchService)
  {
    this.filteredDistros = this.distroCtrl.valueChanges
      .pipe(
        startWith(''),
        map(distro => distroSearchService.filterDistros(distro))
      );
  }
}
