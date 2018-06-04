import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'nb-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private _router: Router) {   }

  isActive(path: string) {
    return this._router.url.endsWith(path);
  }
}
