import { Component, OnInit } from '@angular/core';

import { Orb } from './models/orb.model';
import { Orbiter } from './models/orbiter.model';
import { Star } from './models/star.model';

@Component({
  selector: "nb-lv-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit
{
  public star: Orb

  ngOnInit(): void
  {
    const subMoon = new Orbiter(Guid.newGuid(), "Sub Moon")

    const earth = new Orbiter(Guid.newGuid(), "Earth")
      .addChild(new Orbiter(Guid.newGuid(), "Moon")
        .addChild(subMoon) as Orbiter
      )



    const star = new Star(Guid.newGuid(), "Sun", 50)
      .addChild(new Orbiter(Guid.newGuid(), "Mercury"))
      .addChild(new Orbiter(Guid.newGuid(), "Venus"))
      .addChild(earth as Orbiter)
      .addChild(new Orbiter(Guid.newGuid(), "Mars"))
      .addChild(new Orbiter(Guid.newGuid(), "Jupiter"))
      .addChild(new Orbiter(Guid.newGuid(), "Saturn"))
      .addChild(new Orbiter(Guid.newGuid(), "Uranus"))
      .addChild(new Orbiter(Guid.newGuid(), "Netun"))
      .addChild(new Orbiter(Guid.newGuid(), "Pluto"))

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
