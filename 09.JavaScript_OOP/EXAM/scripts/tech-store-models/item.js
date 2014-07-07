define(function () {
    var itemTypes = {
        accessory: 'accessory',
        smartphone: 'smart-phone',
        notebook: 'notebook',
        pc: 'pc',
        tablet: 'tablet'
    };

    function string_of_enum(en, value) {
        for (var k in en) if (en[k] == value) return k;
        return null;
    };

    var Item;
    Item = (function () {
        function Item(type, name, price) {
            if (!string_of_enum(itemTypes, type)) {
                throw {
                    message: "Unknown item type!"
                };
            };
            if (name.length < 6
                 || name.length > 40
                || !(typeof name == 'string')
                ) {
                throw {
                    message: "Item's name is out of range [6, 40]"
                }
            };

            this.type = type;
            this.name = name;
            this.price = price;
        };

        return Item;
    }());

    return Item;
})