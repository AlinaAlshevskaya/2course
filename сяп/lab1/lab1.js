//task 1
let  a=5; 
console.log(typeof(a)) ;       
let name="Name";   
let i=0;           
let double=0.23    
let result=1/0;    
let answer=true;   
let no = null;     

//task2

let B=5*5;
let A=45*21;
let Counter =0;
while (A>B) 
    {
    Counter++;
    B+=B;
    }
alert(`Количесво квадратов ${Counter}`);


//task 3
let i3=2;
let a3= ++i3;
let b3= i3++;
alert(a3);
alert(b3);

//task4
"Котик"<"котик";
"Котик"> "китик";
"Кот" <"Котик";
"Привет">"Пока";
73 >"53";
false <0,54;
true > 0,54;
123 >false;
true <"3";
3 <"5мм";
8 >"-2";
34 ==="34";
null ==undefined;

//task5
let UserName = prompt("Введите имя: ");
let AdminName = "Шиман Дмитрий Васильевич";
let buff_user = UserName.toLowerCase();
let buff_Admin = AdminName.toLowerCase();
if(buff_user===buff_Admin||buff_Admin.includes(buff_user)){
    alert("Доступ есть!");
}
else{
    alert("Доступа нет!");
    self.close();
}

//task 6
let russian=confirm("Ты сдал эказмен по русскому? (OK=да)");
let math=confirm("Ты сдал эказмен по математике ? (OK=да)");
let english=confirm("Ты сдал эказмен по английскому? (OK=да)");
if(russian+math+english==3){alert("Ты переведен на следующий курс");}
if((russian+math+english<3)&&(russian+math+english>0)){alert("Ты тебя ждет пересдача(и)");}
if(russian+math+english==0){alert("Ты отчислен");}

//task 7
console.log(true + true);
console.log(0 + "5");
console.log(5 + "mm");
console.log(8 / Infinity);
console.log(9 * "\n9");
console.log(null - 1);
console.log("5" - 2);
console.log("5px" - 3);
console.log(true - 3);
console.log(7 || "jr");

//task 8
let num=1;
let stroka=' '
while (num<=10){
if(num%2==0){
    num=num+2;
stroka=stroka+num+', ';
    num=num-1;
}
else {
    stroka= stroka+num+'mm, ';
    num++;
}
}
alert (stroka);

//task 9
var weekDays=[' ','Понедельник','Вторник','Среда','Четверг','Пятница','Суббота','Воскресенье'];
let userDay=prompt("Введите номер нужного дня недели", 1);
if ((userDay<=7)&&(userDay>=1)){
    alert(weekDays[userDay]);
}
else {
    alert("Такого дня нету");
}

// task 10
function form_stroka( first='2024', second, third){
    return third+'.'+second+'.'+first;
};
let day=prompt("Какой сегодня день(1-31)? ", 1);
while (day>31||day<1){
    day=prompt("Такого дня быть не может.Какой сегодня день(1-31)? ", 1);
}
let month='09';
if (!confirm("Еще сентябрь?")){
    let month=10;
};
alert(form_stroka(undefined,month,day));

//task 11
function params(side1,side2){ 
    if(side1<=0||sid2<=0){
        return "Такого квадрата или прямоугольника не существует";
    }
    else if (side1==side2){
        return "P= "+side1*4;
    }
    else{
        return "S= "+side1*side2;
    }
}
let otvet= function (side1,side2){ 
    if(side1<=0||side2<=0){
        return "Такого квадрата или прямоугольника не существует";
    }
    else if (side1==side2){
        return  "P= "+side1*4;
    }
    else{
        return "S= "+side1*side2;
    }
};
 let otvet2=(side1,side2)=>{
    if(side1<=0||side2<=0){
        return "Такого квадрата или прямоугольника не существует";
    }
    else if (side1==side2){
        return  "P= "+side1*4;
    }
    else{
        return  "S= "+side1*side2;
    }
 }
 let side1=prompt("Первая сторона = ",1);
 let side2=prompt("вторая сторона = ",1);
 alert(otvet2(side1,side2));




