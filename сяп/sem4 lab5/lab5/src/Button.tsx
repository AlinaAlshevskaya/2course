interface buttonProperty{
    name:string;
    callback:()=>void;
    dis?:boolean;
}

function ButtonComponent(props:buttonProperty){
    return(
        <button onClick={props.callback} id="but-comp" disabled={props.dis}>{props.name}</button>
    )
}

export default ButtonComponent;