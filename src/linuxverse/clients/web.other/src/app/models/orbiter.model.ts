import { Orb } from './orb.model';
import { Star } from './star.model';

export class Orbiter extends Orb
{
    constructor(id: string, name: string)
    {
        super(id, name)
    }

    public parent: Orb

    public defineSizeIncludingAllChildren()
    {
        this.requireStar(this.defineDepthIncludingAllChildren.name)

        this._size = this.star.size / (this._depth + 1)
        this.children.forEach(child => child.defineSizeIncludingAllChildren())
    }

    public defineDepthIncludingAllChildren()
    {
        this.requireStar(this.defineDepthIncludingAllChildren.name)

        this._depth = this.parent.depth + 1
    }

    private requireStar(actionName: string): void
    {
        if (this.star === undefined)
            throw new Error(`The orbiter must be attached to a star before executing ${actionName}.`)
    }

    private get star(): Orb
    {
        let orb: Orb = this.parent;
        while (orb && !(orb instanceof Star))
        {
            orb = (<Orbiter>orb).parent;
        }
        return orb;
    }
}