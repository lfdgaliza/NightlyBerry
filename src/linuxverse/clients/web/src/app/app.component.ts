import { Component, OnInit } from '@angular/core';

import { Orbiter } from './models/orbiter.model';

@Component({
  selector: "nb-lv-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit
{
  public star: Orbiter

  ngOnInit(): void
  {
    // const subMoon = new Orbiter(Guid.newGuid(), "Sub Moon")

    const earth = new Orbiter(Guid.newGuid(), "Earth")
      .addChild(new Orbiter(Guid.newGuid(), "Moon")
        //.addChild(subMoon)
      )

    const star = new Orbiter(Guid.newGuid(), "Sun", 50)
      .addChild(new Orbiter(Guid.newGuid(), "Mercury"))
      .addChild(new Orbiter(Guid.newGuid(), "Venus"))
      .addChild(earth)
      .addChild(new Orbiter(Guid.newGuid(), "Mars"))
      .addChild(new Orbiter(Guid.newGuid(), "Jupiter"))
    // .addChild(new Orbiter(Guid.newGuid(), "Saturn"))
    // .addChild(new Orbiter(Guid.newGuid(), "Uranus"))
    // .addChild(new Orbiter(Guid.newGuid(), "Neptune"))
    // .addChild(new Orbiter(Guid.newGuid(), "Pluto"))

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
