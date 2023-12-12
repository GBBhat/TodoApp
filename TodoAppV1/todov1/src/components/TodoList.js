import { useState } from "react";
import { Trash3 } from "react-bootstrap-icons";

export default function TodoList({
  todos,
  onDeleteTodo,
  onToggleTodo,
  onEditTodo,
}) {
  const [sortBy, setSortBy] = useState("All");
  let sortedTodos = {};
  let pendingTodo = todos.slice().filter((t) => t.completed === false);
  if (sortBy === "All") {
    sortedTodos = todos;
  }
  if (sortBy === "Active") {
    sortedTodos = pendingTodo;
  }
  if (sortBy === "Completed") {
    sortedTodos = todos.slice().filter((t) => t.completed === true);
  }
  return (
    <div className="col-sm-9 col-md-6 col-lg-8 listcontainer">
      <div className="row statuscontainer">
        <div className="col-sm-4 status">
          <button
            type="button"
            className={sortBy === "All" ? "btn active" : "btn"}
            value="All"
            onClick={(e) => setSortBy(e.target.value)}
          >
            All
          </button>
        </div>

        <div className="col-sm-4 status">
          <button
            type="button"
            className={sortBy === "Active" ? "btn active" : "btn"}
            value="Active"
            onClick={(e) => setSortBy(e.target.value)}
          >
            Active
          </button>
        </div>
        <div className="col-sm-4 status">
          <button
            type="button"
            className={sortBy === "Completed" ? "btn active" : "btn"}
            value="Completed"
            onClick={(e) => setSortBy(e.target.value)}
          >
            Completed
          </button>
        </div>
      </div>
      <div className="container mt-3">
        {sortedTodos.length <= 0 ? (
          <p className="message">
            No todos found. Please start Adding Todos...
          </p>
        ) : (
          <div>
            <p className="note">
              <em>*{pendingTodo.length} todos are in active</em>
            </p>
            <table className="table table-striped">
              <thead>
                <tr>
                  <th>Completed?</th>
                  <th>Name</th>
                  <th>Due Date</th>
                  <th>Action</th>
                </tr>
              </thead>
              <tbody>
                {sortedTodos.map((item) => (
                  <Item
                    item={item}
                    key={item.id}
                    onDeleteTodo={onDeleteTodo}
                    onToggleTodo={onToggleTodo}
                    onEditTodo={onEditTodo}
                  />
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>
    </div>
  );
}

function Item({ item, onDeleteTodo, onToggleTodo, onEditTodo }) {
  const givenDate = new Date(item.dueDate);
  givenDate.setHours(23, 59, 59, 999);
  const currentDate = new Date();

  const overDue = givenDate < currentDate ? true : false;
  return (
    <tr className={overDue && !item.completed ? "overdue" : ""}>
      <td>
        <input
          type="checkbox"
          checked={item.completed}
          onChange={() => onToggleTodo(item.id)}
        />
      </td>
      <td>{item.name}</td>
      <td>{givenDate.toLocaleDateString("en-GB")}</td>
      <td>
        <Trash3 color="red" onClick={() => onDeleteTodo(item.id)} />
      </td>
    </tr>
  );
}
