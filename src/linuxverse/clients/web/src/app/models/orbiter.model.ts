import { Orb } from './orb.model';
import { Star } from './star.model';

export class Orbiter extends Orb
{
    public static calculatePathRadius(orbiter: Orbiter)
    {
        let radius: number
        const distanceFactorToKeep = 1.1
        const parentPortionInMySide = orbiter.parent.calculateSize() / 2
        
        if (orbiter.position === 0)
        {
            const multipliablePosition = orbiter.position + 1
            radius = (multipliablePosition * orbiter.calculateSize() * distanceFactorToKeep) + parentPortionInMySide
        }
        else
        {
            const previousPathRadius = Orbiter.calculatePathRadius(orbiter._previous)
            radius = previousPathRadius + (orbiter.calculateSize() * distanceFactorToKeep)
        }

        if (orbiter.children.length > 0)
        {
            const childrenPathRadius = this.calculatePathRadius(orbiter.children[orbiter.children.length - 1]);
            return radius + childrenPathRadius;
        }

        return radius
    }

    public calculateSize(): number
    {
        const firstNode = this.getFirstNode()

        if (firstNode instanceof Star)
            return firstNode.calculateSize() / (1 + this.getDepth())

        throw new Error(`The orbiter ${this._name} needs to be associated with a star before calculating its size`)
    }

    public setParent(parent: Orb): void
    {
        this._parent = parent
    }

    public setPrevious(previous: Orbiter): void
    {
        this._previous = previous
    }
}