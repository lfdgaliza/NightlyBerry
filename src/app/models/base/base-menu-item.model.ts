export class BaseMenuItem
{
    public ItemMenuId: number;
    public ParentItemMenuId: number;
    public Label: string;
    public Children: BaseMenuItem[];

    constructor() {
        this.Children = new Array<BaseMenuItem>();
    }
}