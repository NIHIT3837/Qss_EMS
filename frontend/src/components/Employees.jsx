import React, { useEffect, useState } from 'react';
import AddEmployeeForm from './AddEmployeeForm';


import { useNavigate } from 'react-router-dom';

function Employees() {

  const navigate = useNavigate();
  const [showForm, setShowForm] = useState(false);
  const [employees, setEmployees] = useState([]);
  const [currentEmployee, setCurrentEmployee] = useState(null); // Store current employee for editing
  const [formMode, setFormMode] = useState('add'); // Tracks whether it's 'add' or 'edit'

  // Fetch existing employees from the backend on component mount
  useEffect(() => {
    fetch("http://localhost:5198/api/employees")
      .then((res) => res.json())
      .then((res) => {
        setEmployees(res);
      })
      .catch((err) => console.error("Error fetching employees:", err));
  }, []);

  const handleAddClick = () => {
    
 
    setFormMode('add'); // Switch to add mode
    setCurrentEmployee(null); // Reset current employee
    setShowForm(true);  // Show the form
  };

  const handleEditClick = (id) => {
    const employeeToEdit = employees.find(emp => emp.id === id);
    setCurrentEmployee(employeeToEdit); // Set current employee for editing
    setFormMode('edit'); // Switch to edit mode
    setShowForm(true);   // Show the form with pre-filled data
  };

  const handleCloseForm = () => {
    setShowForm(false);  // Close the form
    setCurrentEmployee(null); // Reset current employee data
  };

  // Handle saving a new employee to the backend
  const handleSaveEmployee = async (newEmployee) => {
    const payload = {
      FirstName: newEmployee.firstName,
      LastName: newEmployee.lastName,
      Role: newEmployee.role || null,
      DateOfJoining: newEmployee.dateOfJoining || null,
      Manager: newEmployee.manager || null,
    };

    try {
      const response = await fetch("http://localhost:5198/api/employees", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(payload),
      });

      if (!response.ok) {
        throw new Error("Failed to save employee");
      }

      const savedEmployee = await response.json();
      setEmployees([...employees, savedEmployee]);
    } catch (error) {
      console.error("Error saving employee:", error.message);
    }

    setShowForm(false);
  };

  // Handle updating an employee
  const handleUpdateEmployee = async (updatedEmployee) => {
    const payload = {
      
      FirstName: updatedEmployee.firstName,
      LastName: updatedEmployee.lastName,
      Role: updatedEmployee.role || null,
      DateOfJoining: updatedEmployee.dateOfJoining || null,
      Manager: updatedEmployee.manager || null,
    };

    try {
      const response = await fetch(`http://localhost:5198/api/employees/${currentEmployee.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(payload),
      });

      if (!response.ok) {
        throw new Error("Failed to update employee");
      }

      const updatedEmp = await response.json();
      setEmployees(employees.map((emp) => (emp.id === updatedEmp.id ? updatedEmp : emp)));
      setShowForm(false);
      setCurrentEmployee(null);
    } catch (error) {
      console.error("Error updating employee:", error.message);
    }
  };

  const handleDelete = async (id) => {
    try {
      const response = await fetch(`http://localhost:5198/api/employees/${id}`, {
        method: "DELETE",
      });

      if (!response.ok) {
        throw new Error("Failed to delete employee");
      }

      setEmployees(employees.filter((emp) => emp.id !== id));
    } catch (error) {
      console.error("Error deleting employee:", error.message);
    }
  };

  return (
    <div>
      <div className="flex justify-between items-center mb-4">
        <input
          type="text"
          placeholder="Search"
          className="border px-4 py-2 w-1/2"
        />
        <button
          onClick={handleAddClick}
          className="bg-blue-600 text-white px-4 py-2 rounded"
        >
          Add Employee
        </button>
      </div>

      {showForm ? (
        
        <AddEmployeeForm
          mode={formMode} // Pass the mode ('add' or 'edit')
          employee={currentEmployee} // Pass current employee data for editing
          onSave={formMode === 'add' ? handleSaveEmployee : handleUpdateEmployee} // Call appropriate function based on mode
          onClose={handleCloseForm}
        />
      ) : (
        <div className="overflow-x-auto">
          <div className="grid grid-cols-8 gap-4 bg-gray-100 p-4 font-semibold text-sm">
            <div>ID</div>
            <div>First Name</div>
            <div>Last Name</div>
            <div>Role</div>
            <div>Date of Joining</div>
            <div>Manager</div>
            <div>Action</div>
          </div>

          {employees.map((employee) => (
            <div key={employee.id} className="grid grid-cols-8 gap-4 p-2 border-t border-gray-200">
              <div>{employee.id}</div>
              <div>{employee.firstName}</div>
              <div>{employee.lastName}</div>
              <div>{employee.role || "N/A"}</div>
              <div>{employee.dateOfJoining || "N/A"}</div>
              <div>{employee.manager || "N/A"}</div>

              <div className="flex gap-2">
                <button
                  onClick={() => handleEditClick(employee.id)}
                  className="bg-yellow-500 text-white px-3 py-1 rounded"
                >
                  Edit
                </button>
                <button
                  onClick={() => handleDelete(employee.id)}
                  className="bg-red-500 text-white px-3 py-1 rounded"
                >
                  Delete
                </button>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default Employees;
