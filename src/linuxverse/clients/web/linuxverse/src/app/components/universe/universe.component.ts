import { Component, OnInit, Input } from '@angular/core';
import { Orbiter } from 'src/app/services/models/orbiter';

@Component({
  selector: 'nb-lv-universe',
  templateUrl: './universe.component.html',
  styleUrls: ['./universe.component.scss']
})
export class UniverseComponent implements OnInit {

  @Input() rootOrbiter: Orbiter
  
  constructor() { }

  ngOnInit() {
  }

}
