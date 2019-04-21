import { Component, OnInit } from '@angular/core';

import { Orbiter } from './services/models/orbiter.model';
import { Star } from './services/models/star.model';

@Component({
  selector: "nb-lv-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit
{
  public star: Star

  ngOnInit(): void
  {
    const star = new Star(Guid.newGuid(), "Sun", 50)
    star.newChild(Guid.newGuid(), "Mercury")
    star.newChild(Guid.newGuid(), "Venus")
    
    const earth = star.newChild(Guid.newGuid(), "Earth")
    earth.newChild(Guid.newGuid(), "Satellite")
    earth.newChild(Guid.newGuid(), "Moon")
    
    star.newChild(Guid.newGuid(), "Mars")

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
