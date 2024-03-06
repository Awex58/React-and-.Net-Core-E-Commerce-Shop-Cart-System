import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useNavigate } from 'react-router-dom';

function Counter() {
  const navigate = useNavigate();
  const [address, setAddress] = useState('');
  const [cart, setCart] = useState([]);
  const [totalPrice, setTotalPrice] = useState(0);

  const userid = localStorage.getItem('UserId');

  const fetchCartItems = async () => {
    try {
      const response = await axios.post('cart/cartuser', { userid });
      setCart(response.data);
      calculateTotalPrice(response.data);
    } catch (error) {
      console.error('Hata cartlar yüklenmedi:', error);
    }
  };

  useEffect(() => { 
    const accessToken = localStorage.getItem('accessToken');


    if(accessToken == "true") {
      fetchCartItems();
  }
  else{
    navigate('/');
  }

   

  }, []);

  const handleAddressChange = (event) => {
    setAddress(event.target.value);
  };

  const deleteCartItem = async (CartId) => {
    try {
      const response = await axios.post('cart/cartdelete', { CartId });
      toast.info("Ürün Çıkartıldı!");
      fetchCartItems(); // Yeniden sepeti al ve toplam fiyatı güncelle
    } catch (error) {
      console.error('Cart silinemedi : ', error);
    }
  };

  const isAddressEntered = address.trim() !== '';

  const calculateTotalPrice = (cartItems) => {
    let totalPrice = 0;
    cartItems.forEach(item => {
      totalPrice += item.productAmount * item.productPrice;
    });
    setTotalPrice(totalPrice);
  };

  const isCartEmpty = cart.length === 0;

  const handleBuyClick = async () => {
    if (isCartEmpty) {
      return; // Sepet boş ise işlemi gerçekleştirme
    }
  
    try {
      console.log(userid, address);
      await axios.post('salesproducts/salesadd', { UserId: userid, DeliveryAddress: address });
  
      // Sepeti yenile
      fetchCartItems();
  
      // Toast mesajı gönder
      toast.success("Satın alma işlemi başarıyla tamamlandı!");
    } catch (error) {
      console.error('Error :', error);
      toast.error("Satın alma işlemi sırasında bir hata oluştu!");
    }
  };
  return (
    <>
      {cart.map((cartItem, index) => (
        <div className="flex items-center justify-between border-b border-gray-200 py-4" key={index}>
          <div className="flex items-center">
            <img src={cartItem.productPicture} alt={cartItem.productName} className="h-16 w-16 object-cover rounded" />
            <div className="ml-6">
              <h2 className="text-gray-800 font-medium">{cartItem.productName}</h2>
              <p className="text-gray-600 mt-1 text-sm max-w-md">{cartItem.productDescription}</p>
            </div>
          </div>
          <div className="flex items-center">
            <p className="text-gray-700 font-semibold mr-4">{cartItem.productAmount} Adet</p>
            <p className="text-gray-700 font-semibold">{cartItem.productPrice} ₺</p>
            <div className="ml-4">
              <button className="text-red-600 px-2 py-1 bg-red-200 rounded" onClick={() => deleteCartItem(cartItem.cartId)}>
                <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
                  <path fillRule="evenodd" d="M14.707 5.293a1 1 0 0 0-1.414 0L10 8.586 6.707 5.293a1 1 0 1 0-1.414 1.414L8.586 10l-3.293 3.293a1 1 0 0 0 1.414 1.414L10 11.414l3.293 3.293a1 1 0 0 0 1.414-1.414L11.414 10l3.293-3.293a1 1 0 0 0 0-1.414z" clipRule="evenodd" />
                </svg>
              </button>
            </div>
          </div>
        </div>
      ))}

      <div className="mt-8">
        <h2 className="text-lg font-semibold mb-2">Adres Bilgisi</h2>
        <input 
          type="text" 
          className="border border-gray-300 rounded-md px-4 py-2 w-full" 
          placeholder="Adresinizi girin..." 
          value={address} 
          onChange={handleAddressChange} 
        />
      </div>

      <div className="mt-8 flex justify-between items-center">
        <p className="text-lg font-semibold">Toplam Fiyat: {totalPrice} ₺</p>
        <button 
          className={`bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded ${!isAddressEntered && 'opacity-50 cursor-not-allowed'}`} 
          disabled={!isAddressEntered}
          onClick={handleBuyClick}
        >
          Satın Al
        </button>
      </div>
      <ToastContainer />
    </>
  );
}

export default Counter;
