import { Orb } from './orb.model';
import { Star } from './star.model';

export class Orbiter extends Orb
{
    private _parent: Orb

    public get parent(): Orb
    {
        return this._parent
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

    private calculateDepth()
    {
        this._depth = this.parent.depth + 1
    }

    private calculateSize()
    {
        this._size = this.star.size / (this._depth + 1)
    }

    public constructor(id: string, name: string, parent: Orb)
    {
        super(id, name)
        this._parent = parent
        this.calculateDepth()
        this.calculateSize()
    }
}