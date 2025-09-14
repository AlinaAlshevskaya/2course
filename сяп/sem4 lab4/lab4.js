"use strict";
// import { rejects } from "assert";
// import { Console } from "console";
// import { resolve } from "path";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
//TASK 1
let prom = new Promise(function (resolve, reject) {
    setTimeout(() => resolve((Math.random() * 100).toFixed(0)), 1000);
});
//TASK 2
function previousWithDelay(delay) {
    return new Promise((resolve, rejects) => {
        setTimeout(() => resolve((Math.random() * 100).toFixed(0)), delay);
        console.groupEnd();
    });
}
//TASK 3
let pr = new Promise((resolve, reject) => {
    reject('ku');
});
//TASK 4
let prm = new Promise((resolve, reject) => {
    setTimeout(() => resolve(21), 1000);
});
console.group("Task 3");
pr.then(() => console.log(1)).catch(() => console.log(2)).catch(() => console.log(3)).then(() => console.log(4)).then(() => console.log(5));
console.groupEnd();
//TASK 5
function TwentyOnePrinter() {
    return __awaiter(this, void 0, void 0, function* () {
        const first_result = yield prm;
        console.group("Task 5");
        console.log(first_result);
        if (typeof (first_result) == 'number') {
            console.log(first_result * 2);
        }
        console.groupEnd();
    });
}
function Executer() {
    return __awaiter(this, void 0, void 0, function* () {
        const result1 = yield prom.then(result => {
            console.group("Task 1");
            console.log(result);
            console.groupEnd();
        });
        const result2 = yield Promise.all([previousWithDelay(2000), previousWithDelay(2500), previousWithDelay(3000)]).then(result => {
            console.group("Task2");
            console.log(result);
            console.groupEnd();
        });
        const result4 = yield prm.then(function (result) {
            console.group("Task 4");
            console.log(result);
            if (typeof (result) == 'number') {
                return new Promise((resolve, reject) => setTimeout(() => resolve(result * 2), 1000));
            }
        }).then(function (result) {
            console.groupEnd();
            console.log(result);
            console.groupEnd();
        });
        const result5 = yield TwentyOnePrinter();
    });
}
Executer();
