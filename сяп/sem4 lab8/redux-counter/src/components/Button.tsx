import React from "react";
interface IButtonComponent{
    className:string;
    content:string;
    callback:()=>void;
}


const ButtonComponent:React.FC<IButtonComponent> = ({content,callback})=>{
    return(
        <button onClick={callback}>{content}</button>
    )
}

export default ButtonComponent;