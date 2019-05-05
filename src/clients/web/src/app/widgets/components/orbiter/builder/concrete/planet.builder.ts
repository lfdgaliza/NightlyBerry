import { Orbiter } from '../../orbiter.model';

export class PlanetBuilder
{
    private _id: string
    private _name: string
    private _children: Array<Orbiter>

    private constructor()
    {
        this._children = new Array<Orbiter>()
    }

    public static new(): PlanetBuilder
    {
        return new PlanetBuilder()
    }

    public withId(id: string): PlanetBuilder
    {
        this._id = id
        return this
    }

    public withName(name: string): PlanetBuilder
    {
        this._name = name
        return this
    }

    public withChild(child: Orbiter): PlanetBuilder
    {
        this._children.push(child)
        return this
    }

    public build(): Orbiter
    {
        if (this._name === undefined)
            throw new Error("You must specify at least a name for this planet.")

        return new Orbiter(this._id, this._name, this._children)
    }
}