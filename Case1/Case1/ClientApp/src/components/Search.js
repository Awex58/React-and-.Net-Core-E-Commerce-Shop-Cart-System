import React from 'react';

const Search = ({ handleSearch }) => {
  return (
    <div className="my-4" style={{ position: "relative" }}>
  <input
    type="text"
    placeholder="Ürün ara..."
    className="py-2 px-4 border rounded btn_search"
    onChange={(e) => handleSearch(e.target.value)}
    style={{ paddingRight: "40px" }} // Sağ tarafta SVG için alan bırak
  />
  <svg
    xmlns="http://www.w3.org/2000/svg"
    width="25"
    height="25"
    fill="currentColor"
    className="bi bi-search"
    viewBox="0 0 16 16"
    style={{
      position: "absolute",
      top: "50%",
      right: "10px", // Sağ tarafa göre ayarlayın
      transform: "translateY(-50%)",
      cursor: "pointer"
    }}
  >
    <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
  </svg>
</div>
  );
};

export default Search;
