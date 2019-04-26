import { Orb } from './orb.model';
import { Star } from './star.model';

export class Orbiter extends Orb
{
    public get lastChild(): Orbiter
    {
        return this.children[this.children.length - 1]
    }

    public static calculatePathRadius(orbiter: Orbiter)
    {
        const distanceFactorToKeep = 1.1
        const parentPortionInMySide = orbiter.parent.calculateSize() / 2

        if (orbiter.isFirstBorn)
        {
            const multipliablePosition = orbiter.position + 1
            return (multipliablePosition * orbiter.calculateSize(distanceFactorToKeep))
                + parentPortionInMySide
                + orbiter.calculateChildrenRadius()
        }

        const previousPathRadius = Orbiter.calculatePathRadius(orbiter._previous)
        return previousPathRadius
            + (orbiter.calculateSize(distanceFactorToKeep))
            + orbiter.calculateChildrenRadius()
            + orbiter._previous.calculateChildrenRadius()
    }

    public calculateChildrenRadius()
    {
        if (this.children.length > 0)
            return Orbiter.calculatePathRadius(this.lastChild)

        return 0
    }

    public calculateSize(marginFactor: number = 1): number
    {
        const firstNode = this.getFirstNode()

        const size = firstNode.calculateSize()
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