import { useState } from 'react'
import Table from './table'
import TodoList from './todolist'
import FavoriteColor from './color'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <TodoList/>
  )
}

export default App
