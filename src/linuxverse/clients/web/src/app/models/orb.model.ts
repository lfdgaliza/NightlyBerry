import { Orbiter } from './orbiter.model';

export abstract class Orb
{
    protected _id: string
    protected _name: string
    protected _parent: Orb
    protected _children: Array<Orbiter>

    public get parent(): Orb
    {
        return this._parent
    }

    public get children(): Array<Orbiter>
    {
        return this._children
    }

    public get name(): string
    {
        return this._name
    }

    public abstract getSize(): number;

    public addChild(child: Orbiter): Orb
    {
        child.setParent(this)
        this._children.push(child)
        return this
    }

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

    constructor(id: string, name: string)
    {
        this._id = id
        this._name = name
        this._children = new Array<Orbiter>()
    }
}