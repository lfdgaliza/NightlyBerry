import { Orb } from './orb.model';
import { Star } from './star.model';

export class Orbiter extends Orb
{
    public getSize(): number
    {
        const firstNode = this.getFirstNode()

        if (firstNode instanceof Star)
            return firstNode.getSize() / (1 + this.getDepth())

        throw new Error(`The orbiter ${this._name} needs to be associated with a star before calculating its size`)
    }

    public calculatePathRadius(position: number, orbiter: Orbiter)
    {
        const orbiterSize = orbiter.getSize()
        const parentOrbiterSize = orbiter.parent.getSize()

        const radius = ((position + 1) * orbiterSize * 1.2) + parentOrbiterSize / 2

        return radius
    }

    public setParent(parent: Orb): void
    {
        this._parent = parent
    }
}