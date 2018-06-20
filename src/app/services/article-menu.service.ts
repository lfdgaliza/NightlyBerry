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
export class ArticleMenuService {
  constructor(private http: HttpClient) { }

  public getCategoriesMenu(): Observable<ArticleMenu[]> {
    return this.http
      .get(environment.articlesMenuApiUrl, { responseType: 'json' })
      .pipe(map(response => this.mapResponse((<any>response).items)))
  }

  mapResponse(itemsResponse: ArticleMenu[]): ArticleMenu[] {
    let items = new Array<ArticleMenu>();

    itemsResponse.forEach(itemResponse => {

      let splittedCategories = this.getSplittedCategories(itemResponse.category);

      let currentDepth = 0;

      let currentItem = this.getCurrentItem(items, splittedCategories, currentDepth);
      currentItem.children = this.getChildren(splittedCategories, ++currentDepth, currentItem);
    });

    return items;
  }

  private getSplittedCategories(categoryInput: string) {
    categoryInput = categoryInput.replace(/\\\./g, "${{{SEP__}");
    let splittedCategories = categoryInput.split(".");

    for (let index = 0; index < splittedCategories.length; index++)
      splittedCategories[index] = splittedCategories[index].replace(/\$\{\{\{SEP__\}/g, ".");

    return splittedCategories.filter(c => c);
  }

  getChildren(splittedCategories: string[], currentDepth: number, parentItem: ArticleMenu): ArticleMenu[] {

    if (parentItem.children === undefined)
      parentItem.children = new Array<ArticleMenu>();

    let currentItem = this.getCurrentItem(parentItem.children, splittedCategories, currentDepth);

    if (currentDepth === splittedCategories.length) {
      return undefined;
    }

    currentItem.children = this.getChildren(splittedCategories, ++currentDepth, currentItem);
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
