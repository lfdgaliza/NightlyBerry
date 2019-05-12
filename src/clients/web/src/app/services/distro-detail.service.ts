import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { WikipediaApiBuilder } from '../builders/api/concrete/wikipedia-api.builder';

@Injectable({
  providedIn: 'root'
})
export class DistroDetailService
{
  constructor(private http: HttpClient) { }

  public getSummary(): Observable<string>
  {
    const url = new WikipediaApiBuilder()
      .withLang("en")
      .withTitle("Fedora_Linux")
      .buildUrl()

    console.log(url)

    return this.http.get<any>(url)
      .pipe(
        map(response =>
        {
          const pages = response.query.pages
          const page = pages[Object.keys(pages)[0]]
          return page.extract
        })
      )
  }
}
