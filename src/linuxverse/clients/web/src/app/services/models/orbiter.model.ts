import { Orb } from './orb.model';
import { Star } from './star.model';

export class Orbiter extends Orb
{
    public parent: Orb

    public refreshSize()
    {
        if (this.star === undefined)
        {
            console.warn("The orbiter must be attached to a star before refreshing its size.")
            return
        }

        this._size = this.star.size / (this._depth + 1)
        this.children.forEach(child => child.refreshSize())
    }

    private get star()
    {
        let orb: Orb = this.parent;
        while (orb && !(orb instanceof Star))
        {
            orb = (<Orbiter>orb).parent;
        }
        return orb;
    }
}