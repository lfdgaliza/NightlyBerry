import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'dg-distro-detail',
  templateUrl: './distro-detail.component.html',
  styleUrls: ['./distro-detail.component.scss']
})
export class DistroDetailComponent implements OnInit
{

  id: string;

  constructor(private route: ActivatedRoute) { }

  ngOnInit()
  {
    this.route.params.subscribe(params =>
    {
      this.id = params['id'];

      // Dispatch action to load the details here.
    });
  }

}
