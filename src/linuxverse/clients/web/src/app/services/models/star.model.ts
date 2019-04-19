import { Orb } from './orb.model';
import { Orbiter } from './orbiter.model';

export class Star extends Orb
{
    constructor(id: string, name: string, size: number)
    {
        super(id, name)
        this._size = size
        this._depth = 0
    }

    public addChild(newChild: Orbiter): void
    {
        newChild.parent = this
        newChild.refreshSize()
        this.children.push(newChild)
    }
}