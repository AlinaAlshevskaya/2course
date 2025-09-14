//task 1
function basicOperation(operation, value1, value2) {
    let result;
 if (operation=='*') {result= value1 * value2;}
 else if(operation=='+') {result= +value1 + value2;}
 else if (operation=='-') {result=value1 - value2;}
 else if( operation=='/') {result= Number(value1)/ Number(value2);}
 else {result='Такой операции нет';}
 return result;
}
let result1 = basicOperation('/', 10, 5); 
console.log(result1);


//task2
function SummaKubov(n){
    let sum=0;
    let i=0;
    for(  i=1;i<=n;i++){
     sum = sum+i*i*i;
    }
return sum;
}

let result2=SummaKubov(7);
console.log(result2);


//task3
function  ArithmeticMean(arr){
    let sum=0;
    for( let i=0;i<arr.length;i++){
        sum=sum+arr[i];
    }
    return sum/arr.length;
}
let array=[1,2,3,4,5,6,7,8,9,10]
let result3=ArithmeticMean(array);
console.log(result3);


//task4
function OnlyEnglishstr(str){
    let stroka="";
    for(let i=str.length-1; i>=0;i--){
        if( (str[i]>='A'&&str[i]<='Z')||(str[i]>='a'&&str[i]<='z')){
            stroka+=str[i];
        }
    }
return stroka;
}

let string="Я люблю[] Java Script";
console.log(OnlyEnglishstr(string));

//task 5
function MasivStrok(number, str){
let stroka="";
for(let i=0;i<number;i++){
    stroka+=str+' ';
}
return stroka;
}

console.log( MasivStrok(5,"JS"));

//task6
function Deletestr(arr1,arr2){
let arr3=[]
let fl=true;
for(let i=0;i<arr1.length;i++){
    let j=0;
    while(j<arr2.length&&fl){
        if (arr1[i]==arr2[j]){ fl=false}
        j++;
    }
    if (fl) {arr3.push(arr1[i]);}
    fl=true;
}
return arr3;
}
let array1=['apple','pineapple','яблоко','ананас'];
let array2=['pineapple','ананас'];
console.log(Deletestr(array1,array2));

let func7=function(n,arr){
    let stroka1=arr[n];
    let stroka='';
    for(let i=stroka1.length-1; i>=0;i--){
            stroka+=stroka1[i];
        }
        return stroka;
    }
    alert (func7(2,array1));