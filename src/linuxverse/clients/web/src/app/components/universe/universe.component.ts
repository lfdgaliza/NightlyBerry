import { Component, Input, OnInit } from '@angular/core';
import { Star } from 'src/app/services/models/star.model';

@Component({
  selector: 'nb-lv-universe',
  templateUrl: './universe.component.html',
  styleUrls: ['./universe.component.scss']
})
export class UniverseComponent implements OnInit
{

  @Input() star: Star

  constructor() { }

  ngOnInit()
  {
  }

}
