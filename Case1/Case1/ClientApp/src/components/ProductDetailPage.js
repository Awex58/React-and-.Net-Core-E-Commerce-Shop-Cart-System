import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useNavigate } from 'react-router-dom';

const ProductDetailPage = () => {
  const navigate = useNavigate();
  const [product, setProduct] = useState(null);
  const { id } = useParams();

  useEffect(() => {
    const accessToken = localStorage.getItem('accessToken');

    if (accessToken !== "true") {
      navigate('/');
    } else {
      fetchProduct();
    }
  }, [id, navigate]);

  const fetchProduct = async () => {
    try {
      const response = await axios.post('product/productid', { id });
      setProduct(response.data);
      console.error('başarılı:', response.data);
    } catch (error) {
      console.error('Error fetching product:', error);
    }
  };

  const addToCart = async () => {
    try {
      const userId = localStorage.getItem('UserId');
      const response = await axios.post('cart/cartadd', { userId, ProductId:id });
      console.log('Ürün sepete eklendi:', response.data);
      toast.success("Ürün Başarıyla Sepete Eklendi!");
    } catch (error) {
      console.error('Sepete ekleme hatası:', error);
      toast.error("Ürün Sepete Eklenemedi!");
    }
  };

  return (
    <div className="container mx-auto p-8">
      {product ? (
        <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
          <div className="max-w-md mx-auto bg-white rounded-xl shadow-md overflow-hidden md:max-w-2xl">
            <img className="h-full w-full object-cover" src={product.productPicture} alt="Ürün Resmi" />
          </div>
          <div className="p-8">
            <div className="uppercase tracking-wide text-sm text-indigo-500 font-semibold">Ürün Detayları</div>
            <h2 className="mt-4 text-3xl leading-tight font-medium text-black hover:underline">{product.productName}</h2>
            <p className="mt-2 text-gray-500">Ürün ID: {product.productId}</p>
            <p className="mt-2 text-gray-500">Tükeniyor : Son {product.productAmount} Adet</p>
            <p className="mt-2 text-gray-500">Fiyat: {product.productPrice} ₺</p>
            <p className="mt-2 text-gray-500">Açıklama: {product.productDescription}</p>
            <div className="mt-8">
              <button onClick={addToCart} className="inline-block px-6 py-3 text-base font-medium leading-6 text-center text-white uppercase transition bg-indigo-500 rounded-full shadow ripple hover:shadow-lg hover:bg-indigo-600 focus:outline-none">
                Sepete Ekle
              </button>
              <ToastContainer />
            </div>
          </div>
        </div>
      ) : (
        <div>Loading... {id}</div>
      )}
    </div>
  );
};

export default ProductDetailPage;
