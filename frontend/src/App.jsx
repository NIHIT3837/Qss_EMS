import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Employees from "./components/Employees";
import AddEmployeeForm from "./components/AddEmployeeForm";
import Roles from "./components/Roles";
import Departments from "./components/Departments";
import EmployeesPage from "./pages/EmployeesPage";

function App() {

  const[flag, setFlag]=useState(true);
  return (
    <Router>
      <div className="flex h-screen">
        {/* Sidebar */}
        <Navbar flag={flag}/>
        
        {/* Main Content */}
        <div className="flex-1 p-6">
          <header className="flex items-center justify-between mb-6">
            <img src="logo.png" alt="Logo" className="h-10 mr-4" />
            <h1 className="text-2xl font-bold">EMS SYSTEM</h1>
          </header>

          <Routes>
            {/* Employees list */}
            <Route path="/" element={<Employees />} />
            <Route path="/employees" element={<Employees flag={flag}/>} />


            {/* Roles Route */}
            <Route path="/roles" element={<Roles />} />

            <Route path="/form" element={<EmployeesPage/>}/>

            {/* Departments Route */}
            <Route path="/departments" element={<Departments />} />
          </Routes>
        </div>
      </div>
    </Router>
  );
}

export default App;
