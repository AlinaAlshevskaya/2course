import styles from '../styles/style.module.css'
import { increment,decrement,reset } from '../redux/actions';
import { useDispatch, useSelector } from 'react-redux';
import { type counterState } from '../redux/counterReducer';
import ButtonComponent from './Button';


const Counter:React.FC = ()=>{
    const count = useSelector((state:counterState)=>state.count);
    const dispatch = useDispatch();
    return(
        <div className={styles.container}>
            <div className={styles.counter}>
                <span>{count}</span>
                <ButtonComponent  className={styles.button} content='+' callback={()=>dispatch(increment())}/>
                <ButtonComponent   className={styles.button} content='-' callback={()=>dispatch(decrement())}/>
                <ButtonComponent   className={styles.button} content='Reset' callback={()=>dispatch(reset())}/>
            </div>
        </div>
    )
}

export default Counter;