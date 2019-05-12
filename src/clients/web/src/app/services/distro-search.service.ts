import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Distro } from '../components/distro/distro-search.component';

@Injectable({
  providedIn: 'root'
})
export class DistroSearchService
{
  private distrosUrl = 'https://localhost:5001/api/distro/for-search'

  getDistros(term: string): Observable<Array<Distro>>
  {
    const url = `${this.distrosUrl}?term=${term}`
    return this.http.get<Array<any>>(url)
      .pipe(
        map(distroList => distroList.map(apiDistro => <Distro>{ id: apiDistro.i, name: apiDistro.n, logo: apiDistro.p, basedOn: apiDistro.b }))
      )
  }

  constructor(private http: HttpClient) { }
}
