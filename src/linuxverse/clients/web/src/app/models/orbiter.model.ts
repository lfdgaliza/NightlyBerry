import { Orb } from './orb.model';
import { Star } from './star.model';

export class Orbiter extends Orb
{
    public get lastChild(): Orbiter
    {
        return this.children[this.children.length - 1]
    }

    public static calculatePathRadius(orbiter: Orbiter, marginFactor: number)
    {
        const parentPortionInMySide = orbiter.parent.calculateSize(marginFactor) / 2

        if (orbiter.isFirstBorn)
        {
            const multipliablePosition = orbiter.position + 1
            return (multipliablePosition * orbiter.calculateSize(marginFactor))
                + parentPortionInMySide
                + orbiter.calculateChildrenRadius(marginFactor)
        }

        const previousPathRadius = Orbiter.calculatePathRadius(orbiter._previous, marginFactor)
        return previousPathRadius
            + (orbiter.calculateSize(marginFactor))
            + orbiter.calculateChildrenRadius(marginFactor)
            + orbiter._previous.calculateChildrenRadius(marginFactor)
    }

    public calculateChildrenRadius(marginFactor: number)
    {
        if (this.children.length > 0)
            return Orbiter.calculatePathRadius(this.lastChild, marginFactor)

        return 0
    }

    public calculateSize(marginFactor: number): number
    {
        const firstNode = this.getFirstNode()

        const size = firstNode.calculateSize(marginFactor)
        const depthStartingWithOne = 1 + this.getDepth()

        if (firstNode instanceof Star)
            return (size / depthStartingWithOne) * marginFactor

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