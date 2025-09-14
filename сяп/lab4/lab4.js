//task 1
let spisok=new Set();
spisok.add("Car");
spisok.add("Phone");
spisok.add("Computer");
spisok.add("cookies");
spisok.delete("cookies");
console.log(spisok);
console.log(spisok.has("Car"));
console.log(spisok.has("book"));
console.log(spisok.size);

//task 2
let students=new Set();

function add(set,student){
    if('name' in student&&'group' in student&& 'zachetka'in student){
        set.add(student);
    }
    return set;
}

function deleteStudent(set,groupN){
 set.forEach((value,valueAgain,set)=>{
 if(value.group==groupN){set.delete(value);}
 });
 return set;
}
 function showgroup(set,groupN){
    let newset=new Set();
    set.forEach((value,valueAgain,set)=>{
    if(value.group==groupN){newset.add(value);}
    });
    return newset;
}

function sort(set){
    const array=[...set]; 
    function compareByZachetka(a,b){
        if(a.zachetka>b.zachetka) return 1;
        if(a.zachetka==b.zachetka) return 0;
        if(a.zachetka<b.zachetka) return -1;
    }
    array.sort(compareByZachetka);
    let newSet=new Set(array);
    return newSet;
}

add(students,{name:"Alshevskaya Alina",group:6, zachetka:444});
add(students,{name:"Filipiuk Ilya",group:6, zachetka:123});
add(students,{name:"Kucheruk Nicolai",group:7, zachetka:765});
add(students,{name:"Kravchenko Sergey",group:10, zachetka:222});
add(students,{name:"Garmoza Maksim",group:4, zachetka:111});
deleteStudent(students,4);
console.log(students);
console.log(showgroup(students,6));
console.log(students);
console.log(sort(students));

//task 3
let products=new Map();
let obj1={id:1,name:"laptop",amount:4,cost:200};
let obj2={id:2,name:"headphones",amount:9,cost:150};
let obj3={id:3,name:"batery",amount:7,cost:100};
let obj4={id:4,name:"pabel",amount:20,cost:80};
let obj5={id:5,name:"table",amount:2,cost:2000};

function addTovar(obj){
    let key=obj.id;
    let Name=obj.name;
    let Amount=obj.amount;
    let Cost=obj.cost;
    let Value={Name, Amount,Cost}
    return products.set(key, Value);
}
function deleteTovar(id){
products.delete(id);
return products;
}
function ChangeAmount( id,newAmount){
    if(products.has(id)){
        let tmp=products.get(id);
        tmp.Amount=newAmount;
        products.set(id,tmp);
    }
    return products;
}

function deleteByName(dname){
    for(let [key,value] of products){
    if (value.Name==dname){products.delete(key);}
    };
    return products;
}
 
 function changePrice(id,price){
    if(products.has(id)){
        let tmp=products.get(id);
        tmp.Cost=price;
        products.set(id,tmp);
    }
    return products;
 }
 addTovar(obj1);
 addTovar(obj2);
 addTovar(obj3);
 addTovar(obj4);
 addTovar(obj5);
 
 deleteTovar(5);
 deleteByName("pabel");
 ChangeAmount(3,5);
 changePrice(3,150);
 console.log(products);
 let kolvo=products.size;
 let sum=0;
 for(let i=1; i<=kolvo;i++){
    tmp=products.get(i);
sum+=(tmp.Amount*tmp.Cost);
 }
 console.log(sum);
 //task 4
 let Cached = new WeakMap();
function forWeakMap(Obj){
    if(!Cached.has(Obj)){
        let result = Obj.name.length*3;
        Cached.set(Obj,result);
    }
    return Cached.get(Obj);
}
let weak1 = {name:"Shiman"};
let  weak2 = {name:"Kudlaskaya"};
console.log(forWeakMap(weak1));
console.log(forWeakMap(weak2));
weak1=null;
weak2-null;
console.log(Cached);
//console.log(forWeakMap(weak1)); //will be an error because obj1 is already deleted

