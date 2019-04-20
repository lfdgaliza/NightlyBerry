import { Component, Input, OnInit } from '@angular/core';
import { Star } from 'src/app/models/star.model';

@Component({
  selector: 'nb-lv-universe',
  templateUrl: './universe.component.html',
  styleUrls: ['./universe.component.less']
})
export class UniverseComponent implements OnInit
{

  constructor() { }

  @Input() star: Star

  ngOnInit()
  {
  }

}
