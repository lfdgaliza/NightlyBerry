import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DistroDetailService } from 'src/app/services/distro-detail.service';

@Component({
  selector: 'dg-distro-detail',
  templateUrl: './distro-detail.component.html',
  styleUrls: ['./distro-detail.component.scss']
})
export class DistroDetailComponent implements OnInit
{
  id: string;
  summary: string;

  constructor(
    private route: ActivatedRoute,
    private distroDetailService: DistroDetailService) { }

  ngOnInit()
  {
    this.route.params.subscribe(params =>
    {
      this.id = params['id'];

      // Dispatch action to load the details here.
    });

    this.distroDetailService.getSummary().subscribe(s =>
    {
      this.summary = s
    })
  }

}
