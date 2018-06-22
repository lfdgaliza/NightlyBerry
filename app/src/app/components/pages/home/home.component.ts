import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'nb-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public articleId: string;
  constructor(private router: Router) { }

  ngOnInit() {
  }

  showArticle() {
    this.router.navigate(['/home', {outlets: {'article': [this.articleId]}}]);
  }

}
