import { Orb } from './orb.model';

export class Star extends Orb
{
    private _size: number

    public calculateSize(): number
    {
        return this._size
    }

    constructor(id: string, name: string, size: number)
    {
        super(id, name)
        this._size = size
        this._position = 0
    }
}