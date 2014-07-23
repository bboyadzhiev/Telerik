/// <reference path="Animal.js" />
/// <reference path="libs/underscore.js" />
(function () {
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('libs/underscore.js');
    }

    var animals = [],
        leggedSpecies = { MAMMAL: 'Mammal', INSECT: 'Insect', REPTILE: 'Reptile', BIRD: 'Bird', DINOSAUR: 'Dinosaur' };

    animals = [
        new Animal('Parrot', leggedSpecies.BIRD, 2),
        new Animal('Fly', leggedSpecies.INSECT, 6),
        new Animal('Bug', leggedSpecies.INSECT, 6),
        new Animal('Elephant', leggedSpecies.MAMMAL, 4),
        new Animal('Tiger', leggedSpecies.MAMMAL, 4),
        new Animal('Stegosaurus', leggedSpecies.DINOSAUR, 4),
        new Animal('Tyrannosaurus', leggedSpecies.DINOSAUR, 2), // let's say it's two-legged
        new Animal('Lizard', leggedSpecies.REPTILE, 4),
        new Animal('Centipede', leggedSpecies.INSECT, 100),
        new Animal('Spider', leggedSpecies.INSECT, 8),
        new Animal('Dog', leggedSpecies.MAMMAL, 4)
    ];


    // Task 4
    function groupBySpeciesSortByLegs(animalsArray) {

        var groupedAnimals = _(animalsArray).chain()
            .sortBy(function (animal) {
                return animal.getLegsCount();
            })
            .groupBy(function (animal) {
                return animal.getSpecies();
            })
            .value();

        return groupedAnimals;
    };

    // Task 5
    function legsCount(animalsArray) {
        var counter = 0;
        _.each(animalsArray, function (animal) {
            counter = counter + animal.getLegsCount();
        });
        return counter;
    };

    console.log('--- The Animals list ---');
    console.dir(animals);
    console.log();

    console.log('--- Task 4 - a function that by a given array of animals, groups them by species and sorts them by number of legs --- ');
    console.dir(groupBySpeciesSortByLegs(animals));
    console.log();

    console.log('--- Task 5 - By a given array of animals, find the total number of legs --- ');
    console.log('Total number of legs: ' + legsCount(animals));
}());