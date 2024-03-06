import React, { useState, useEffect } from 'react';
import Pagination from './Pagination';
import Search from './Search';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';

export function FetchData() {
  const [data, setData] = useState([]);
  const [categories, setCategories] = useState([]);
  const navigate = useNavigate();
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState('');
  const [isLoading, setIsLoading] = useState(true);
  const itemsPerPage = 10;

  useEffect(() => {
    const fetchData = async () => {
      try {
        const accessToken = localStorage.getItem('accessToken');

        if(accessToken == "true") {
          
          const response = await axios.get('product/productall');

        const response2 = await axios.get('category/categoryall');

        if (response.status === 200 && response2.status===200 ) {
          setData(response.data);
          setCategories(response2.data);
          setIsLoading(false); 
        } else {
          console.error('Hata durumu:', response.statusText);
        }
        
        

        }
        else{
          navigate('/');
        }

        
      } catch (error) {
        console.error('Token Hatası eski token silindi, yeniden giriş yap:', error);
        navigate('/');
      }
    };

    fetchData();
  }, [navigate]);

  const handleSearch = (term) => {
    if (term.trim() === '') {
      setCurrentPage(1);
    }
    setSearchTerm(term);
  };

  const filteredItems = searchTerm
    ? data.filter(item =>
        ['productName', 'productPrice'].some(prop =>
          typeof item[prop] === 'string' &&
          item[prop].toLocaleLowerCase().includes(searchTerm.toLocaleLowerCase())
        )
      )
    : data;

  const totalItems = filteredItems.length;
  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = filteredItems.slice(indexOfFirstItem, indexOfLastItem);



  const paginate = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

 
  return (
    <div>
      {isLoading ? (
        <div className="fixed inset-0 flex items-center justify-center z-50">
          <div className="animate-spin rounded-full h-16 w-16 border-t-4 border-blue-500"></div>
        </div> 
      ) : (
        <div>
        <div className="flex justify-center mb-4 ">
    {categories.map((category, index) => (
      <div key={index} className="relative mx-2 px-3 py-1 bg-gray-200 rounded-md cursor-pointer hover:bg-blue-300 transition duration-300 ease-in-out text-sm shadow-md">
        <span>{category.categoryName}</span>
        <span className="absolute inset-0 flex items-center justify-center opacity-0 hover:opacity-100 transition duration-300 ease-in-out">
          {category.categoryName}
        </span>
      </div>
    ))}
  
         
       </div>
       <div className="flex justify-between items-center mb-4 ">
        <Search handleSearch={handleSearch} />
       
        <div className="container mx-auto mt-8 text-center">
    <hr className="mb-4" />
    </div>
      

          
    </div>

          <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-4">
            {currentItems.map((item, index) => (
              <Link to={`/product/${item.productId}`} key={index} className="flex flex-col items-center m-4 p-4 border rounded-lg shadow-md w-full sm:w-64 transition-transform duration-300 transform hover:scale-110 cursor-pointer">
                <img src={item.productPicture} alt={item.productName} className="w-full h-48 object-cover rounded-t-lg" /> 
                <div className="flex flex-col justify-between flex-1">  
                  <div className="text-center mt-4"> 
                    <h2 className="text-lg font-bold">{item.productName}</h2> 
                  </div> 
                  <div className="text-center"> 
                    <p className="text-gray-700">{item.productPrice} ₺</p>  
                  </div>
                </div>
              </Link>
            ))}
          </div>

          {/* Alt çubuk */}
          <div className="w-full h-10 bg-gray-200 fixed bottom-0 left-0 flex items-center justify-center opacity-50">
          <Pagination totalItems={totalItems} itemsPerPage={itemsPerPage} paginate={paginate} />
          </div>

         
        </div>
      )}
    </div>
  );
}
