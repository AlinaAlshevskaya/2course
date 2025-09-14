//task 1
let arr=[1,[1,2,[3,4]],[2,4]]
function flattenArray(InputArray){
  return InputArray.reduce((Acc,Curr)=>{
    if(Array.isArray(Curr)){
      return Acc.concat(flattenArray(Curr));
    }
    else{
      return Acc.concat([Curr]);
    }
  },[]);
}
  const result = flattenArray(arr);
  console.log(result); 

//task 2
  const arr2 = [1,2,[2,5,3,[32,5],3],7,4];

  function SumElements(InputArray){
    if(Array.isArray(InputArray)){
      return InputArray.reduce((Acc,Curr)=>Acc+SumElements(Curr),0);
    }
    else{
      return InputArray;
    }
  }
  console.log(SumElements(arr2)); 

//task 3
let students=[
  {name:"Pete",age: 18, groupID:6,},
  {name:"Pete",age: 18, groupID:9,},
  {name:"Pete",age: 19, groupID:9,},
  {name:"Pete",age: 16, groupID:9,}
]

function sortStudents(InputArray){
  let Result = {};
  InputArray.forEach(student=> {
      if(student.age>17){
          if(!Result[student.groupID]){
              Result[student.groupID] = [];
          }
          Result[student.groupID].push(student);
      }
  });
  return Result;
}
let Above17 = sortStudents(students);

console.group("Sort students");
console.log(Above17);
console.groupEnd();

//task 4
console.group("Character's codes");
let SomeLine = "ABCDEFG";
let SrcStrofCodes = "";
for(let char of SomeLine){
  SrcStrofCodes +=char.charCodeAt(0);
}
console.log(`SrcStrofCodes: ${SrcStrofCodes}`);
let NewStrofCodes = ""
for(let char of SrcStrofCodes){
  if(char=="7"){
      NewStrofCodes+="1";
  }
  else{
      NewStrofCodes+=char;
  }
}
console.log(`NewstrofCodes: ${NewStrofCodes}`);

let LinesSubstraction = SrcStrofCodes-NewStrofCodes;
console.log(`Result: ${LinesSubstraction}`);
console.groupEnd();

//task 5
function formObject(){
  let ObjectToReturn = {};
  for(let object of arguments){
      Object.assign(ObjectToReturn,object);
  }
  return ObjectToReturn;
}
console.group("From a new object from many");
console.log(formObject({name:"Alex",age:"18"},{sex:"Male",CanDrive:true},{Married:false,HasKids:true}));
console.groupEnd();

//task 6
function drawPiramid(floors){
  let pyramid = "";
  for(let row=1;row<=floors;row++){
      let stars = '*'.repeat((row*2)-1);
      let spaces = ' '.repeat(floors-row);
      pyramid+=`${spaces}${stars}\n`; 
  }
  return pyramid;
}
console.group("Pyramid");
console.log(drawPiramid(7));
console.log(drawPiramid(3));
console.groupEnd();

let ob={
  name:"masha",
  age:15,
  sex:"f"
};
ob.height=170;
delete ob.sex;
for (key in ob){
  alert(ob[key]);
}
 

console.log(ob)
