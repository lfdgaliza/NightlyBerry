import { Orbiter } from './orbiter.model';

export abstract class Orb
{
    protected _id: string
    protected _name: string
    protected _parent: Orb
    protected _previous: Orbiter
    protected _position: number
    protected _children: Array<Orbiter>

    public get parent(): Orb
    {
        return this._parent
    }

    public get position(): number
    {
        return this._position
    }

    public get children(): Array<Orbiter>
    {
        return this._children
    }

    public get name(): string
    {
        return this._name
    }

    public abstract calculateSize(): number;

    public getFirstNode(): Orb
    {
        if (this._parent)
            return this._parent.getFirstNode()

        return this
    }

    public getDepth(depth: number = 0): number
    {
        if (this._parent)
            return this._parent.getDepth(++depth)

        return depth
    }

    public addChild(child: Orbiter): Orb
    {
        child.setParent(this)
        
        child._position = this._children.length
        
        if (this.children.length > 0)
            child._previous = this.children[this.children.length - 1]
        
        this._children.push(child)

        return this
    }

    constructor(id: string, name: string)
    {
        this._id = id
        this._name = name
        this._children = new Array<Orbiter>()
    }
}