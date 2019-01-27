interface Number {
    toPxString(this: number): String
}

Number.prototype.toPxString = function (this: number): String {
    return `${this}px`;
}