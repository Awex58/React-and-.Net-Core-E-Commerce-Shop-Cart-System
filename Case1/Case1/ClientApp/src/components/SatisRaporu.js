import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';


function SalesReport() {
  const [sales, setSales] = useState([]);
  const [monthlyRevenue, setMonthlyRevenue] = useState(0); // Aylık gelir için state ekledik
  const navigate = useNavigate();
  useEffect(() => {
    fetchSalesData();
  }, []);

  useEffect(() => {



    const accessToken = localStorage.getItem('accessToken');

        if(accessToken == "true") {
            calculateMonthlyRevenue();
        }
        else{
          navigate('/');
        }
     // Her satış güncellendiğinde aylık geliri yeniden hesaplar
  }, [sales]);

  const fetchSalesData = async () => {
    try {
      const response = await axios.get('salesproducts/salesall'); // API endpoint'i değiştirilebilir
      setSales(response.data);
    } catch (error) {
      console.error('Error fetching sales data:', error);
    }
  };

  const calculateMonthlyRevenue = () => {
    let totalRevenue = 0;
    const currentDate = new Date();
    const currentMonth = currentDate.getMonth() + 1; // JavaScript'te aylar 0'dan başlar, bu yüzden +1 ekliyoruz

    sales.forEach(sale => {
      const saleDate = new Date(sale.saleTime);
      const saleMonth = saleDate.getMonth() + 1; // Aynı sebepten dolayı +1 ekliyoruz

      if (saleMonth === currentMonth) { // Sadece bu ayın satışlarını hesapla
        totalRevenue += sale.salePrice * sale.saleAmount;
      }
    });

    setMonthlyRevenue(Math.round(totalRevenue)); // Yuvarlanmış geliri ayarla
  };

  return (
    <div>
      {/* Günlük gelir gösteren bileşen */}
      <div className="fixed top-0 right-0 m-4 p-3 bg-white shadow-md rounded-xl">
        <div className="flex items-center">
          <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6 mr-2 text-green-500" viewBox="0 0 20 20" fill="currentColor">
            <path fillRule="evenodd" d="M10 18a1 1 0 0 1-1-1v-1a1 1 0 0 1 2 0v1a1 1 0 0 1-1 1zm7.707-6.293l-8-8a1 1 0 0 0-1.414 0l-8 8a1 1 0 1 0 1.414 1.414L10 8.414l6.293 6.293a1 1 0 0 0 1.414-1.414zM10 12a1 1 0 0 1-1-1V4a1 1 0 1 1 2 0v7a1 1 0 0 1-1 1z" clipRule="evenodd" />
          </svg>
          <div>
            <span className="text-gray-600">Aylık Gelir: </span>
            <span className="text-lg text-green-600 font-bold">{Math.round(monthlyRevenue)} ₺</span>
          </div>
        </div>
      </div>

      {/* Satış raporu tablosu */}
      <div className="container mx-auto p-4 mt-16"> {/* mt-16 ile tablonun üst kısmını günlük gelir bileşeninden aşağı kaydırır */}
        <h1 className="text-2xl font-bold mb-4">Satış Raporu</h1>
        <table className="min-w-full">
          <thead>
            <tr>
              <th className="px-4 py-2">Ürün Adı</th>
              <th className="px-4 py-2">Fiyatı</th>
              <th className="px-4 py-2">Satılan Ürün Miktarı</th>
              <th className="px-4 py-2">Satış Zamanı</th>
              <th className="px-4 py-2">Kullanıcı ID</th>
              <th className="px-4 py-2">Adres</th>
            </tr>
          </thead>
          <tbody>
            {sales.map((sale, index) => (
              <tr key={index}>
                <td className="border px-4 py-2">{sale.saleProductName}</td>
                <td className="border px-4 py-2">{sale.salePrice} ₺</td>
                <td className="border px-4 py-2">{sale.saleAmount}</td>
                <td className="border px-4 py-2">{sale.saleTime}</td>
                <td className="border px-4 py-2">{sale.saleUserId}</td>
                <td className="border px-4 py-2">{sale.saleAddress}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default SalesReport;
