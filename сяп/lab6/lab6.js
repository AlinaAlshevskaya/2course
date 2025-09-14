let numbers = [1,2,3,4,5,6];
const[y] = numbers;

console.group("Array destructuring:");
console.log(y);
console.groupEnd();

//TASK 2
let user = {name:"Valera",age:43};
let Admin = {admin:true,...user};
console.group("Spread operator with objects");
console.log(user);
console.log(Admin);
console.groupEnd();

//TASK 3
let store ={
    state: {  //1 уровень
            profilePage:{  //2 уровень
                        posts:[  //3 уровень
                            {id: 1, massage: 'Hi', likesCount: 12},
                            {id: 2, message: 'By', likesCount: 1},
                              ],
                        newPostText: 'About me',
                        },
            dialogsPage: {
                        dialogs: [
                            {id: 1, name: 'Valera'},
                            {id: 2, name: 'Andrey'},
                            {id: 3, name: 'Sasha'},
                            {id: 4, name: 'Viktor'},
                                 ],
                        messages:[
                            {id: 1, message: 'hi'},
                            {id: 2, message: 'hi hi'},
                            {id: 3, message: 'hi hi hi'},
                                 ],
                        },
            sidebar:[],
        },
}

let {state: {
    profilePage : 
        {posts}, 
    dialogsPage : 
        {dialogs, messages} 
    } 
} = store;    
console.log("Counting likes ");
posts.forEach(posts => {
    console.log(posts.id, "Likes:", posts.likesCount);
});

let filteredDialogs = [];
dialogs.forEach((person) => {
    if(person.id % 2 == 0) {
        filteredDialogs.push(person.name);
    }
})
console.log(filteredDialogs);

messages = messages.map(message => ({
    message: "Hello user", 
    ...message
}));

//TASK 4
let tasks = [
    {id:1,title:"HTML&CSS",isDone:true},
    {id:2,title:"JS",isDone:true},
    {id:3,title:"ReactJS",isDone:false},
    {id:4,title:"Rest API",isDone:false},
    {id:5,title:"GraphQL",isDone:false},
];

let NewTask = {id:6,title:"Make a final build",isDone:false};
tasks = [...tasks,NewTask];
console.group("Add to an array using spread operator");
console.log(tasks);
console.groupEnd();

//TASK 5
let arrTOfunc = [1,2,3];
function sumValues(x,y,z){
    return x+y+z;
}
console.group("Parametres transmition using spread operator");
console.log(sumValues(...arrTOfunc))
console.groupEnd();
let tasks2 = [
    {id:1,title:"HTML&CSS",isDone:true},
    {id:2,title:"JS",isDone:true},
    {id:3,title:"ReactJS",isDone:false},
    {id:4,title:"Rest API",isDone:false},
    {id:5,title:"GraphQL",isDone:false},
];
let alltasks=[...tasks,...tasks2];
