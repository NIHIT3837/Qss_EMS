import React from 'react';
import { Link } from 'react-router-dom';

function Navbar() {
  return (
    <div className="w-1/5 bg-gray-800 text-white h-full p-4">
      <ul>
        <li className="p-4 hover:bg-gray-700 cursor-pointer">
          <Link to="/employees">EMPLOYEES</Link>
        </li>
        <li className="p-4 hover:bg-gray-700 cursor-pointer">
          <Link to="/roles">ROLES</Link>
        </li>
        <li className="p-4 hover:bg-gray-700 cursor-pointer">
          <Link to="/departments">DEPARTMENTS</Link>
        </li>
      </ul>
    </div>
  );
}

export default Navbar;
