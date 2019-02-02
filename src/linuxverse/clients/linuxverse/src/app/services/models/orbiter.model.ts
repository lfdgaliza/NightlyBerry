export class Orbiter {
    id: string
    name: string
    children: Array<Orbiter>

    constructor(id: string, name: string, children: Array<Orbiter> = new Array<Orbiter>()) {
        this.id = id
        this.name = name
        this.children = children
    }
}