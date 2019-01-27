import { Component } from '@angular/core'

import { Orbiter } from './services/models/orbiter'

@Component({
  selector: "nb-lv-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent {
  rootOrbiter: Orbiter = new Orbiter(Guid.newGuid(), "sun", [
    new Orbiter(Guid.newGuid(), "Mercury"),
    new Orbiter(Guid.newGuid(), "Venus"),
    new Orbiter(Guid.newGuid(), "Earth", [
      new Orbiter(Guid.newGuid(), "Satellite"),
      new Orbiter(Guid.newGuid(), "Moon")
    ]),
    new Orbiter(Guid.newGuid(), "Mars")
  ]);
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
