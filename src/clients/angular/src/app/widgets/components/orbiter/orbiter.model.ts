import { TreeItem } from '../../shared/tree.model';

export class Orbiter extends TreeItem
{
    /**
     * It is better to use a builder instead of using the constructor directly
     * for readability purposes.
     * @param id 
     * @param name 
     * @param size 
     * @param childResizingRatePercent Ex: 0.7: The size of each child will be 70% the size of the parent.
     */
    constructor(id: string, name: string, children = new Array<Orbiter>(), size: number = 0, childResizingRatePercent = 1)
    {
        super()
        this.id = id
        this.name = name
        this._size = size
        this._childResizingRatePercent = childResizingRatePercent

        this.children = new Array<Orbiter>()
        this.addChildren(children)
    }




    private _position: number = 0
    // TODO: Protect this
    public get position(): number { return this._position }

    private _size: number
    public get size(): number { return this._size }

    private _pathRadius: number
    public get pathRadius(): number { return this._pathRadius }
    public get pathDiameter(): number { return this._pathRadius * 2 }
    public get pathPosition(): number { return -1 * (this._pathRadius - this._parent._size / 2) }

    private _childResizingRatePercent: number

    private _parent: Orbiter
    public get parent(): Orbiter { return this._parent }
    public get hasParent(): boolean { return this._parent !== undefined }
    public get isStar(): boolean { return !this.hasParent }

    private _previous: Orbiter
    private get hasPrevious(): boolean { return this._previous !== undefined }

    private get hasChildren(): boolean { return this.children.length > 0 }
    private get lastChild(): Orbiter { return <Orbiter>this.children[this.children.length - 1] }

    public addChild(child: Orbiter): Orbiter
    {
        child._parent = this
        child._position = this.children.length
        child._previous = this.lastChild

        child.updateMeasures()

        this.children.push(child)

        return this
    }

    public addChildren(children: Array<Orbiter>)
    {
        children.forEach(c => this.addChild(c))
    }

    private updateMeasures(): void
    {
        this.reflectChildResizingRatePercent()
        this.updateSize()
        this.updatePathRadius()
    }

    private reflectChildResizingRatePercent(): void
    {
        this._childResizingRatePercent = this.getChildResizingRatePercentFromLastParent()
        this.children.forEach(c => (<Orbiter>c).reflectChildResizingRatePercent())
    }

    private updateSize(): void
    {
        this._size = this.calculateSize()
        this.children.forEach(c => (<Orbiter>c).updateSize())
    }

    private updatePathRadius(): void
    {
        this._pathRadius = this.calculatePathRadius()
        this.children.forEach(c => (<Orbiter>c).updatePathRadius())
    }

    private getChildResizingRatePercentFromLastParent(): number
    {
        if (this.hasParent)
            return this._parent.getChildResizingRatePercentFromLastParent()

        return this._childResizingRatePercent
    }

    private calculateSize(): number
    {
        if (this.hasParent)
            return this._parent.calculateSize() * this._childResizingRatePercent

        return this._size
    }

    private calculatePathRadius()
    {
        const parentPortionInMySide = this.parent._size / 2

        if (this.hasPrevious)
        {
            return this._previous._pathRadius
                + (this._size)
                + this.calculateChildrenRadius()
                + this._previous.calculateChildrenRadius()
        }

        const multipliablePosition = this._position + 1
        return (multipliablePosition * this._size)
            + parentPortionInMySide
            + this.calculateChildrenRadius()
    }

    public calculateTopPosition()
    {
        if (this.isStar)
            return this.calculateLeftPosition()

        const first = this._size * this._position
        const second = (this.parent._size / 2) - this._size / 2
        const last = (first - second) * -1
        return last
    }

    public calculateLeftPosition()
    {
        const left = this._size / 2

        if (this.isStar)
            return left * -1

        return left
    }

    private calculateChildrenRadius()
    {
        if (this.hasChildren)
            return this.lastChild.calculatePathRadius()

        return 0
    }
}