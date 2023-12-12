import { useEffect, useState } from "react";
import axios from "axios";
import TodoList from "./components/TodoList";
import TodoForm from "./components/TodoForm";

function App() {
  const [todos, setTodos] = useState([]);
  //API URL for services
  const apiUrl = "https://localhost:7205/api/Todos";

  useEffect(() => {
    (async () => await fetchTodos())();
  }, []);

  async function fetchTodos() {
    try {
      const res = await axios.get(apiUrl);
      setTodos(res.data);
    } catch (err) {
      console.log(err.message);
    }
  }

  async function handleAddTodos(todo) {
    try {
      const res = await axios.post(apiUrl, todo);
      if (res.data) {
        fetchTodos();
      }
    } catch (err) {
      console.log(err.message);
    }
  }

  async function handleDeteleTodo(id) {
    try {
      var confirmed = window.confirm("Are you sure you want to delete");
      if (confirmed) {
        await axios.delete(apiUrl + "/" + id);
        fetchTodos();
      }
    } catch (err) {
      console.log(err);
    }
  }

  async function handleToggleTodo(id) {
    try {
      const todo = todos.find((t) => t.id === id);
      await axios.put(apiUrl + "/" + id, {
        Id: id,
        Name: todo.name,
        DueDate: todo.dueDate,
        Completed: !todo.completed,
      });
      fetchTodos();
    } catch (err) {
      console.log(err.message);
    }
  }

  return (
    <div className="container-fluid app">
      <h1>TODOs</h1>
      <div className="row todo">
        <TodoForm onAddTodo={handleAddTodos} />
        <TodoList
          todos={todos}
          onDeleteTodo={handleDeteleTodo}
          onToggleTodo={handleToggleTodo}
        />
      </div>
    </div>
  );
}

export default App;
