import { Orbiter } from './orbiter.model';

export abstract class Orb
{
    protected _size: number
    protected _depth: number

    private _id: string
    private _name: string
    private _children: Array<Orbiter>

    public get name(): string
    {
        return this._name
    }

    public get size(): number
    {
        return this._size
    }

    public get children(): Array<Orbiter>
    {
        return this._children
    }

    public get depth(): number
    {
        return this._depth
    }

    public newChild(id: string, name: string): Orbiter
    {
        const newChild = new Orbiter(id, name, this)
        this._children.push(newChild)
        return newChild
    }

    constructor(id: string, name: string)
    {
        this._id = id
        this._name = name
        this._children = new Array<Orbiter>()
    }
}