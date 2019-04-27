interface Number {
    asPx(this: number): String
}

Number.prototype.asPx = function (this: number): String {
    return `${this}px`;
}