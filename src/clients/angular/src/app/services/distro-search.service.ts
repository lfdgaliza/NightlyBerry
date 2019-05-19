import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { DistroGuideApiBuilder } from '../builders/api/concrete/distro-guide-api.builder';
import { Distro } from '../components/distro/distro-search.component';

@Injectable({
  providedIn: 'root'
})
export class DistroSearchService
{
  constructor(private http: HttpClient) { }

  getDistros(term: string): Observable<Array<Distro>>
  {
    const url = new DistroGuideApiBuilder()
      .withPath("distro/for-search")
      .withParameters([{ key: "term", value: term }])
      .buildUrl()

    return this.http.get<Array<any>>(url)
      .pipe(
        map(distroList => distroList.map(apiDistro => <Distro>{ id: apiDistro.i, name: apiDistro.n, logo: apiDistro.p, basedOn: apiDistro.b }))
      )
  }
}
