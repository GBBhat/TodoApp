import { useState } from "react";

export default function TodoForm({ onAddTodo }) {
  const [name, setName] = useState("");
  const [dueDate, setDueDate] = useState("");
  const [errors, setErrors] = useState("");

  function handleSubmit(e) {
    e.preventDefault();
    const validationErrors = {};
    if (!name.trim()) {
      validationErrors.name = "Name is required";
    } else if (!(name.length > 10 && name.length <= 50)) {
      validationErrors.name = "Should be greater than 10";
    }

    if (!dueDate.trim()) {
      validationErrors.dueDate = "Due date is required";
    }
    setErrors(validationErrors);

    if (Object.keys(validationErrors).length === 0) {
      const newTodo = {
        Name: name,
        DueDate: dueDate,
      };
      onAddTodo(newTodo);
      setName("");
      setDueDate("");
    }
  }
  function handleChangeName(e) {
    if (e.target.value.length > 50) return;
    setName(e.target.value);
  }
  return (
    <div className="col-sm-3 col-md-6 col-lg-4 todoform">
      <form onSubmit={handleSubmit} className="formcontainer">
        <div className="form-group">
          <label> What needs to be done?:</label>
          <input
            type="text"
            className="form-control"
            value={name}
            onChange={handleChangeName}
          />
          {errors.name && <p className="error">{errors.name}</p>}
        </div>
        <div className="form-group">
          <label>Due Date:</label>
          <input
            type="date"
            className="form-control"
            value={dueDate}
            onChange={(e) => setDueDate(e.target.value)}
          />
          {errors.dueDate && <p className="error">{errors.dueDate}</p>}
        </div>
        <button type="submit" className="btn btn-primary">
          Add
        </button>
      </form>
    </div>
  );
}
