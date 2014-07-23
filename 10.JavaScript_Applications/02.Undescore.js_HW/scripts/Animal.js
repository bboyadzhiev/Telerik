var Animal = (function myfunction() {
    function Animal(name, species, legsCount) {
        if (legsCount % 2 !== 0
            || (legsCount > 8 && legsCount !== 100)
            || legsCount < 2) {
            throw "Invalid legs count!";
        }
        this._legsCount = legsCount;
        this._species = species;
        this._name = name;
    };

    Animal.prototype = {
        getLegsCount: function () {
            return this._legsCount;
        },
        getSpecies: function () {
            return this._species;
        },
        getName: function () {
            return this._name;
        }
    };

    return Animal;
}());