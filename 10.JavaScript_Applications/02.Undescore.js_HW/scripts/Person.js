var Person = (function () {

    function Person(fname, lname, age) {
        this._fname = fname;
        this._lname = lname;
        if (age<0 || age> 120) {
            throw "Invalid age";
        }
        this._age = age;
    }

    Person.prototype = {
        getFullName: function () {
            var fullName = this._fname + ' ' + this._lname;
            return fullName;
        },
        getFName: function () {
            return this._fname;
        },
        getLName: function () {
            return this._lname;
        },
        getAge: function () {
            var age = this._age;
            return age;
        }
    };
    return Person;
}());