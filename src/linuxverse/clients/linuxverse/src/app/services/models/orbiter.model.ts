export class Orbiter {
    private _name: String
    private _position: number
    private _children: Array<Orbiter>
    private _parent: Orbiter

    get name(): String {
        return this._name
    }

    get position(): number {
        return this._position
    }

    get children(): Array<Orbiter> {
        return this._children
    }

    get neighbors(): Array<Orbiter> {
        return this._parent === undefined
            ? undefined
            : this._parent.children
    }

    get isStar(): boolean {
        return this._parent === undefined
    }

    get parent() {
        return this._parent
    }

    public getSize(startSize: number, factor: number): number {
        if (this._parent === undefined)
            return startSize

        return this._parent.getSize(startSize, factor) * factor
    }

    private getBiggestChildRadius(startSize: number, factor: number): number {
        if (this.children.length > 0) {
            const lastPosition = Math.max(...this.children.map(m => m.position))
            const childWithBiggestPosition = this.children.filter(f => f.position == lastPosition)[0]
            const childRadius = childWithBiggestPosition.getOrbitRadius(startSize, factor)
            return childRadius
        }

        return 0
    }

    getOrbitRadius(startSize: number, factor: number): number {
        if (this._parent === undefined) return 0

        const mySize = this.getSize(startSize, factor)
        const parentSize = this._parent.getSize(startSize, factor)

        // 1.2 = 120%
        let radius = (this.position * mySize * 1.2) + parentSize

        if (this.position > 1) {
            const previousOrbiter = this.neighbors.filter(f => f.position == this.position - 1)[0]
            const normalGrowth = (previousOrbiter.getOrbitRadius(startSize, factor) + mySize * 1.2)
            radius = normalGrowth + previousOrbiter.getBiggestChildRadius(startSize, factor)
        }

        radius += this.getBiggestChildRadius(startSize, factor)

        return radius
    }

    public add(child: Orbiter) {
        child._parent = this
        child._position = this.children.length + 1
        this._children.push(child)
    }

    constructor(name: String) {
        this._name = name
        this._position = 1
        this._children = new Array<Orbiter>()
    }
}