import { Orbiter } from '../../orbiter.model';

export class StarBuilder
{
    private _id: string
    private _name: string
    private _size: number
    private _childResizingRatePercent: number
    private _children: Array<Orbiter>

    private constructor()
    {
        this._children = new Array<Orbiter>()
    }

    public static new(): StarBuilder
    {
        return new StarBuilder()
    }

    public withId(id: string): StarBuilder
    {
        this._id = id
        return this
    }

    public withName(name: string): StarBuilder
    {
        this._name = name
        return this
    }

    public withSize(size: number): StarBuilder
    {
        this._size = size
        return this
    }

    public withChild(child: Orbiter): StarBuilder
    {
        this._children.push(child)
        return this
    }

    /**
     * The children's resizing rate in decimal percent
     * @param childResizingRatePercent Ex: 0.7: The size of each child will be 70% the size of the parent.
     */
    public withChildResizingRatePercent(childResizingRatePercent: number): StarBuilder
    {
        this._childResizingRatePercent = childResizingRatePercent
        return this
    }

    public build(): Orbiter
    {
        this.validate();
        return this.doBuild()
    }

    private validate(): void
    {
        if (this._name === undefined)
            throw new Error("You must specify at least a name for this star.");
    }

    private doBuild(): Orbiter
    {
        return new Orbiter(
            this._id
            , this._name
            , this._children
            , this._size || 50
            , this._childResizingRatePercent || .7
        );
    }
}