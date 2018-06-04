import { BaseMenuItem } from "./base/base-menu-item.model";

export class ArticleMenuItem extends BaseMenuItem {

    public constructor(init?: Partial<ArticleMenuItem>) {
        super();
        Object.assign(this, init);
    }

    public Path: string;
    public Source: string;
}