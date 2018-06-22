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
  articles: ArticleMenu[];

  public constructor(init?: Partial<ArticleMenu>) {
    Object.assign(this, init);

    if (this.children === undefined)
      this.children = new Array<ArticleMenu>();
  }
}

@Injectable({
  providedIn: 'root'
})
export class ArticleMenuService {
  getFullCategory(articleMenu: ArticleMenu): string {
    
    let actualParent = articleMenu.parent;
    let result = articleMenu.category;

    while(actualParent !== undefined) {
      result = `${actualParent.category}.${result}`;
      actualParent = actualParent.parent;
    }

    console.log("PARENT", articleMenu, result);
    return result;
  }
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
      this.getChildrenCategories(splittedCategories, ++currentDepth, currentItem, itemsResponse);
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

  getChildrenCategories(splittedCategories: string[], currentDepth: number, parentItem: ArticleMenu, itemsResponse: ArticleMenu[]): ArticleMenu[] {

    if (currentDepth === splittedCategories.length)
      return undefined;

    let currentItem = this.getCurrentItem(parentItem.children, splittedCategories, currentDepth);

    this.getChildrenCategories(splittedCategories, ++currentDepth, currentItem, itemsResponse);
    currentItem.parent = parentItem;
    if (currentItem.children.length < 1) {
      currentItem.articles = itemsResponse.filter(ir => ir.category === this.getFullCategory(currentItem))
    }

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
