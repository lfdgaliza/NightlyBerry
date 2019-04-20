import { Component, Input, OnInit } from '@angular/core';
import { Orb } from 'src/app/models/orb.model';

@Component({
  selector: 'nb-lv-orb',
  templateUrl: './orb.component.html',
  styleUrls: ['./orb.component.less']
})
export class OrbComponent implements OnInit
{

  constructor() { }

  @Input() orb: Orb

  ngOnInit()
  {
  }

}
