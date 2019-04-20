import { Orb } from './orb.model';

export class Star extends Orb
{
    constructor(id: string, name: string, size: number)
    {
        super(id, name)
        this._size = size
        this._depth = 0
    }
}