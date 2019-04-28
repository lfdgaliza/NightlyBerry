export class Orbiter
{
    constructor(id: string, name: string, size: number = 0, childResizingRatePercent = 1)
    {
        this._id = id
        this._name = name
        this._size = size
        this._childResizingRatePercent = childResizingRatePercent

        this._children = new Array<Orbiter>()
    }

    private _id: string

    private _name: string
    public get name(): string
    {

        return this._name
    }

    private _position: number = 0
    // TODO: Protect this
    public get position(): number { return this._position }

    private _depth: number = 0
    public get depth(): number { return this._depth }

    private _size: number
    private _childResizingRatePercent: number

    private _parent: Orbiter
    public get parent(): Orbiter { return this._parent }
    public get hasParent(): boolean { return this._parent !== undefined }
    public get isStar(): boolean { return !this.hasParent }

    private _previous: Orbiter
    public get hasPrevious(): boolean { return this._previous !== undefined }

    private _children: Array<Orbiter>
    public get children(): Array<Orbiter> { return this._children }
    public get hasChildren(): boolean { return this._children.length > 0 }
    public get lastChild(): Orbiter { return this._children[this._children.length - 1] }

    public addChild(child: Orbiter): Orbiter
    {
        child._parent = this
        child._position = this._children.length
        child._previous = this.lastChild

        child.updateMeasures()

        this._children.push(child)

        return this
    }

    private updateMeasures(): void
    {
        this.updateDepth()
        this.reflectChildResizingRatePercent()
        this.updateSize()
    }

    private updateDepth(): void
    {
        this._depth = this.calculateDepth()
        this._children.forEach(c => c.updateDepth())
    }

    private updateSize()
    {
        this._size = this.calculateSize()
        this._children.forEach(c => c.updateSize())
    }

    private reflectChildResizingRatePercent()
    {
        this._childResizingRatePercent = this.getChildResizingRatePercentFromLastParent()
        this._children.forEach(c => c.reflectChildResizingRatePercent())
    }

    private calculateDepth(depth: number = 0): number
    {
        if (this.hasParent)
            return this._parent.calculateDepth(++depth)

        return depth
    }

    // TODO: Protect this
    public calculateSize(): number
    {
        if (this.hasParent)
            return this._parent.calculateSize() * this._childResizingRatePercent

        return this._size
    }

    private getChildResizingRatePercentFromLastParent(): number
    {
        if (this.hasParent)
            return this._parent.getChildResizingRatePercentFromLastParent()

        return this._childResizingRatePercent
    }

    public calculatePathRadius()
    {
        const parentPortionInMySide = this.parent._size / 2

        if (this.hasPrevious)
        {
            const previousPathRadius = this._previous.calculatePathRadius()
            return previousPathRadius
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
        const first = this._size * this._position
        const second = (this.parent._size / 2) - this._size / 2
        const last = (first - second) * -1
        return last
    }

    public calculateLeftPosition()
    {
        return this._size / 2
    }

    private calculateChildrenRadius()
    {
        if (this.hasChildren)
            return this.lastChild.calculatePathRadius()

        return 0
    }
}