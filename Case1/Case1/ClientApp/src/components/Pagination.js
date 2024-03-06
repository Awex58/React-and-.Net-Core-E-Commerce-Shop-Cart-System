import React from 'react';
import "./tailwind.css"


const Pagination = ({ totalItems, itemsPerPage, paginate }) => {
  const totalPages = Math.ceil(totalItems / itemsPerPage);

  const pageNumbers = [];
  for (let i = 1; i <= totalPages; i++) {
    pageNumbers.push(i);
  }

  return (
    <nav>
      <ul className="flex justify-center my-4">
        {pageNumbers.map(number => (
          <li key={number} className="mx-2">
            <button
              onClick={() => paginate(number)}
              className="py-1.5 px-3 bg-blue-500 text-white rounded hover:bg-blue-700 focus:outline-none focus:shadow-outline-blue active:bg-blue-800"
            >
              {number}
            </button>
          </li>
        ))}
      </ul>
    </nav>
  );
};

export default Pagination;