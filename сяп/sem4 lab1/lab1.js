var array = [0, 2, 9, 1, 7, 7, 3, 4, 5, 6];
function createnumber(array) {
    var str = array.toString();
    var result = "";
    var strarray = str.split(',');
    result = '(' + strarray[0] + strarray[1] + strarray[2] + ') ' + strarray[3] + strarray[4] + strarray[5] + '-' + strarray[6] + strarray[7] + strarray[8] + strarray[9];
    return result;
}
console.log(createnumber(array));
var Chalenge = /** @class */ (function () {
    function Chalenge() {
    }
    Chalenge.getsum = function (max) {
        var result = 0;
        if (max > 0) {
            for (var i = 0; i < max; i++) {
                if (i % 3 == 0 || i % 5 == 0)
                    result += i;
            }
        }
        return result;
    };
    return Chalenge;
}());
console.log(Chalenge.getsum(10));
function reverse(array, k) {
    var result = [];
    var restart = 0;
    for (var i = 0; i < array.length; i++) {
        if (i >= array.length - k) {
            result[i] = array[restart];
            restart++;
        }
        else {
            result[i] = array[i + k];
        }
    }
    return result;
}
console.log(reverse(array, 5));
function mediana(array1, array2) {
    var result = 0;
    var bigarray = array1.concat(array2);
    bigarray.sort();
    if (bigarray.length % 2 == 0) {
        var num1 = bigarray[bigarray.length / 2];
        var num2 = bigarray[bigarray.length / 2 - 1];
        result = (num1 + num2) / 2;
    }
    else {
        result = bigarray[(bigarray.length - 1) / 2];
    }
    return result;
}
console.log(mediana([1, 3], [2]));
console.log(mediana([1, 3], [2, 4]));
