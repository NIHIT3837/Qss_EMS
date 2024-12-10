import React, { useState, useEffect } from 'react';

function AddEmployeeForm({ mode, employee, onSave, onClose }) {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    role: '',
    dateOfJoining: '',
    manager: '',
  });

  // Pre-fill form data if in edit mode
  useEffect(() => {
    if (mode === 'edit' && employee) {
      setFormData({
        firstName: employee.firstName || '',
        lastName: employee.lastName || '',
        role: employee.role || '',
        dateOfJoining: employee.dateOfJoining || '',
        manager: employee.manager || '',
      });
    }
  }, [mode, employee]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSave(formData);
  };

  return (
    <div className="p-4 border rounded bg-white">
      <h2 className="text-lg font-semibold mb-4">{mode === 'add' ? 'Add Employee' : 'Edit Employee'}</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label className="block text-sm font-medium">First Name</label>
          <input
            type="text"
            name="firstName"
            value={formData.firstName}
            onChange={handleChange}
            className="border px-4 py-2 w-full"
            required
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Last Name</label>
          <input
            type="text"
            name="lastName"
            value={formData.lastName}
            onChange={handleChange}
            className="border px-4 py-2 w-full"
            required
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Role</label>
          <input
            type="text"
            name="role"
            value={formData.role}
            onChange={handleChange}
            className="border px-4 py-2 w-full"
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Date of Joining</label>
          <input
            type="date"
            name="dateOfJoining"
            value={formData.dateOfJoining}
            onChange={handleChange}
            className="border px-4 py-2 w-full"
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Manager</label>
          <input
            type="text"
            name="manager"
            value={formData.manager}
            onChange={handleChange}
            className="border px-4 py-2 w-full"
          />
        </div>
        <div className="flex justify-end gap-2">
          <button type="button" onClick={onClose} className="bg-gray-300 px-4 py-2 rounded">
            Cancel
          </button>
          <button type="submit" className="bg-blue-600 text-white px-4 py-2 rounded">
            Save
          </button>
        </div>
      </form>
    </div>
  );
}

export default AddEmployeeForm;
