import { Orb } from './orb.model';
import { Star } from './star.model';

export class Orbiter extends Orb
{
    private _parent: Orb

    constructor(id: string, name: string)
    {
        super(id, name)
    }

    public setParent(parent: Orb): void
    {
        if (this._parent !== undefined)
            throw new Error(`You cannot set the parent Orb twice. Orb name: ${this.name}`)

        this._parent = parent
    }

    public get parent(): Orb
    {
        return this._parent
    }

    public calculateSizeRecursively()
    {
        this.requireStar('The orbiter must be attached to a star before definig its size')

        this._size = this.star.size / (this._depth + 1)
        this.children.forEach(child => child.calculateSizeRecursively())
    }

    public calculateDepthRecursively()
    {
        this.requireStar('The orbiter must be attached to a star before definig its depth')

        this._depth = this.parent.depth + 1
        this.children.forEach(child => child.calculateDepthRecursively())
    }

    private requireStar(errorMessage: string): void
    {
        if (this.star === undefined)
            throw new Error(errorMessage)
    }

    public get star(): Orb
    {
        let orb: Orb = this.parent;
        while (orb && !(orb instanceof Star))
        {
            orb = (<Orbiter>orb).parent;
        }
        return orb;
    }
}