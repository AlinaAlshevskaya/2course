import React, { useState } from 'react';
type Todo = {
  id: number;
  text: string;
};

const initialTodos: Todo[] = [
  { id: 1, text: 'Купить хлеб' },
  { id: 2, text: 'Прочитать статью про Redux Toolkit' },
  { id: 3, text: 'Выучить философию техники' }
];

const TodoList: React.FC = () => {
  const [todos, setTodos] = useState(initialTodos);

  const deleteTodo = (id: number) => {
    setTodos(todos.filter(todo => todo.id !== id));
  };

  return (
    <ul>
      {todos.map(todo => (
        <li key={todo.id} style={{ marginBottom: '10px' }}>
          {todo.text}
          <button onClick={() => deleteTodo(todo.id)} style={{ marginLeft: '10px' }}>
            Удалить
          </button>
        </li>
      ))}
    </ul>
  );
};

export default TodoList;