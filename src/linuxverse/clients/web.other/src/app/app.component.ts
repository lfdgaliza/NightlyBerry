import { Component, OnInit } from '@angular/core';

import { Orbiter } from './models/orbiter.model';
import { Star } from './models/star.model';

@Component({
  selector: 'nb-lv-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit
{
  public star: Star

  ngOnInit(): void
  {
    const star = new Star(Guid.newGuid(), "Sun", 50)
    star.addChild(new Orbiter(Guid.newGuid(), "Mercury"))
    star.addChild(new Orbiter(Guid.newGuid(), "Venus"))

    const earth = new Orbiter(Guid.newGuid(), "Earth")
    star.addChild(earth)
    earth.addChild(new Orbiter(Guid.newGuid(), "Satellite"))
    earth.addChild(new Orbiter(Guid.newGuid(), "Moon"))

    star.addChild(new Orbiter(Guid.newGuid(), "Mars"))

    console.log(star)
    this.star = star
  }
}

class Guid
{
  static newGuid()
  {
    return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c)
    {
      var r = (Math.random() * 16) | 0,
        v = c == "x" ? r : (r & 0x3) | 0x8;
      return v.toString(16);
    });
  }
}