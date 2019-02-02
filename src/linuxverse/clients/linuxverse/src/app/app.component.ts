import { Component } from '@angular/core'

import { Orbiter } from './services/models/orbiter.model'

@Component({
  selector: "nb-lv-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent {
  star: Orbiter

  constructor() {
    const mercury = new Orbiter("Mercury")
    const venus = new Orbiter("Venus")

    const satellite1 = new Orbiter("Satellite 1")
    const satellite2 = new Orbiter("Satellite 2")
    const earth = new Orbiter("Earth")
    earth.add(satellite1)
    earth.add(satellite2)

    const mars = new Orbiter("Mars")
    const jupiter = new Orbiter("Jupiter")

    const sun = new Orbiter("Sun")
    sun.add(mercury)
    sun.add(venus)
    sun.add(earth)
    sun.add(mars)
    sun.add(jupiter)
  }
}

class Guid {
  static newGuid() {
    return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c) {
      var r = (Math.random() * 16) | 0,
        v = c == "x" ? r : (r & 0x3) | 0x8;
      return v.toString(16);
    });
  }
}
