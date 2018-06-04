import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BaseMenuItem } from '../../models/base/base-menu-item.model';

@Component({
  selector: 'nb-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.scss']
})
export class SideMenuComponent implements OnInit {

  @Input() items: BaseMenuItem[];
  @Output() itemSelected = new EventEmitter<BaseMenuItem>();

  constructor() {}

  getIdCollapsibleMenu(item: BaseMenuItem) {
    return "item-collapsible-menu-" + item.ItemMenuId;
  }

  showArticle(item: BaseMenuItem) {
    this.itemSelected.emit(item);
  }

  ngOnInit() {

  }

}
