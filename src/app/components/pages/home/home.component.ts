import { Component, OnInit } from '@angular/core';
import { ArticleMenuItem } from '../../../models/article-menu-item.model';

@Component({
  selector: 'nb-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor() { }

  public menuItems = new Array<ArticleMenuItem>();

  ngOnInit() {

    let item: ArticleMenuItem = new ArticleMenuItem({ ItemMenuId: 1, Label: "Test" });
    this.menuItems.push(item);

    console.log(this.menuItems);
  }

}
