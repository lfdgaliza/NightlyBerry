import { Component, OnInit, Input } from '@angular/core';
import { Orbiter } from 'src/app/services/models/orbiter';

@Component({
  selector: 'nb-lv-orbiter',
  templateUrl: './orbiter.component.html',
  styleUrls: ['./orbiter.component.scss']
})
export class OrbiterComponent implements OnInit {

  @Input() orbiter: Orbiter
  constructor() { }

  ngOnInit() {
  }

}
