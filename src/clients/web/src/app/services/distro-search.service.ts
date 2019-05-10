import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Distro } from '../pages/home/home.component';

@Injectable({
  providedIn: 'root'
})
export class DistroSearchService
{
  private distrosUrl = 'https://localhost:5001/api/distro/for-search'

  private distros: Array<Distro> = new Array<Distro>()

  filterDistros(distro: string): Array<Distro>
  {
    return this._filterDistros(distro)
  }

  private _filterDistros(value: string): Array<Distro>
  {
    const filterValue = value.toLowerCase();

    return this.distros.filter(distro => distro.name.toLowerCase().indexOf(filterValue) === 0);
  }

  constructor(private http: HttpClient)
  {
    if (this.distros.length == 0)
      //this.distros = 
      http.get<Array<any>>(this.distrosUrl)
        .subscribe(result =>
        {
          this.distros = result.map(apid => <Distro>{ id: apid.d, name: apid.n, logo: apid.p, basedOn: apid.b })
        });
  }
}
