import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.prod';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

class ArticleMenu {
  name: string;
  category: string;
  parent: ArticleMenu;
  children: ArticleMenu[];

  public constructor(init?: Partial<ArticleMenu>) {
    Object.assign(this, init);
  }
}

@Injectable({
  providedIn: 'root'
})
export class ArticleService {


  constructor(private http: HttpClient) { }

  public getCategoriesMenu(): Observable<ArticleMenu[]> {
    return this.http
      .get(environment.articlesMenuApiUrl, { responseType: 'json' })
      .pipe(map(response => this.mapResponse((<any>response).items)))
  }

  mapResponse(itemsResponse: ArticleMenu[]): ArticleMenu[] {
    let items = new Array<ArticleMenu>();

    itemsResponse.forEach(itemResponse => {

      let splittedCategories = itemResponse.category.split(itemResponse.category[0]);
      let currentDepth = 1;

      let currentItem = this.getCurrentItem(items, splittedCategories, currentDepth);
      currentItem.children = this.getChildren(splittedCategories, currentDepth, currentItem);
    });

    return items;
  }

  getChildren(splittedCategories: string[], currentDepth: number, parentItem: ArticleMenu): ArticleMenu[] {
    if (++currentDepth === splittedCategories.length)
      return undefined;

    if (parentItem.children === undefined)
      parentItem.children = new Array<ArticleMenu>();

    let currentItem = this.getCurrentItem(parentItem.children, splittedCategories, currentDepth);
    currentItem.children = this.getChildren(splittedCategories, currentDepth, currentItem);
    currentItem.parent = parentItem;

    return parentItem.children;
  }

  private getCurrentItem(items: ArticleMenu[], splittedCategories: string[], currentDepth: number) {
    let currentItem = undefined;
    for (let i = 0; i < items.length && !currentItem; i++) {
      if (items[i].category === splittedCategories[currentDepth])
        currentItem = items[i];
    }
    if (!currentItem) {
      currentItem = new ArticleMenu({ category: splittedCategories[currentDepth] });
      items.push(currentItem);
    }
    return currentItem;
  }
}
