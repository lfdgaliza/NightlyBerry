export class Orbiter
{
    constructor(id: string, name: string, size: number = 0)
    {
        this._id = id
        this._name = name
        this._size = size

        this._children = new Array<Orbiter>()
    }

    private _id: string
    private _name: string
    private _position: number = 0

    private _depth: number = 0
    private _size: number = 0

    private _parent: Orbiter
    private _previous: Orbiter

    private _children: Array<Orbiter>

    public get name(): string { return this._name }
    // TODO: Protect this
    public get position(): number { return this._position }

    public get children(): Array<Orbiter> { return this._children }
    public get hasChildren(): boolean { return this._children.length > 0 }
    public get lastChild(): Orbiter { return this._children[this._children.length - 1] }

    public get parent(): Orbiter { return this._parent }
    public get hasParent(): boolean { return this._parent !== undefined }
    public get isStar(): boolean { return !this.hasParent }

    public get hasPrevious(): boolean { return this._previous !== undefined }

    public addChild(child: Orbiter): Orbiter
    {
        child._parent = this
        child._position = this._children.length

        if (this.hasChildren)
            child._previous = this.lastChild

        child.updateMeasures()
        this._children.push(child)

        return this
    }

    private updateMeasures(): void
    {
        this.updateDepth()
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
            return this._parent.calculateSize() / (this._depth + 1)

        return this._size
    }

    public calculatePathRadius()
    {
        const parentPortionInMySide = this.parent._size / 2

        if (this.hasPrevious)
        {
            const previousPathRadius = this._previous.calculatePathRadius()
            return previousPathRadius
                + (this.calculateSize())
                + this.calculateChildrenRadius()
                + this._previous.calculateChildrenRadius()
        }

        const multipliablePosition = this._position + 1
        return (multipliablePosition * this.calculateSize())
            + parentPortionInMySide
            + this.calculateChildrenRadius()
    }

    private calculateChildrenRadius()
    {
        if (this.hasChildren)
            return this.lastChild.calculatePathRadius()

        return 0
    }
}