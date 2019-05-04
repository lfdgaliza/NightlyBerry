import { Component, OnInit } from '@angular/core';

import { PlanetBuilder } from './widgets/orbiter/builder/concrete/planet.builder';
import { StarBuilder } from './widgets/orbiter/builder/concrete/star.builder';
import { Orbiter } from './widgets/orbiter/orbiter.model';

@Component({
  selector: 'dg-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit
{
  public star: Orbiter

  ngOnInit(): void
  {
    const earth = PlanetBuilder.new()
      .withId(Guid.newGuid())
      .withName("Earth")

      .withChild(PlanetBuilder.new().withId(Guid.newGuid()).withName("Moon").build())

      .build()

    const star = StarBuilder.new()
      .withId(Guid.newGuid())
      .withName("Earth")
      .withSize(50)
      .withChildResizingRatePercent(.5)

      .withChild(PlanetBuilder.new().withId(Guid.newGuid()).withName("Mercury").build())
      .withChild(PlanetBuilder.new().withId(Guid.newGuid()).withName("Venus").build())
      .withChild(earth)
      .withChild(PlanetBuilder.new().withId(Guid.newGuid()).withName("Mars").build())
      .withChild(PlanetBuilder.new().withId(Guid.newGuid()).withName("Jupiter").build())
      .withChild(PlanetBuilder.new().withId(Guid.newGuid()).withName("Saturn").build())
      .withChild(PlanetBuilder.new().withId(Guid.newGuid()).withName("Uranus").build())
      .withChild(PlanetBuilder.new().withId(Guid.newGuid()).withName("Neptune").build())
      .withChild(PlanetBuilder.new().withId(Guid.newGuid()).withName("Pluto").build())

      .build()

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