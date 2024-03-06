import React, { useState, useEffect } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { useNavigate } from 'react-router-dom';


const NavMenu = () => {
  const [collapsed, setCollapsed] = useState(true);
  const [isUserLoggedIn, setIsUserLoggedIn] = useState(false); 
  const navigate = useNavigate();

  const toggleNavbar = () => {
    setCollapsed(!collapsed);
  };

  useEffect(() => {

    
    const accessToken = localStorage.getItem('accessToken');
    setIsUserLoggedIn(accessToken ? true : false);
    
  }, [localStorage.getItem('accessToken')]);



  const handleLogout = () => {
    // Kullanıcı oturumunu sonlandırma işlemleri
    setIsUserLoggedIn(false); // Kullanıcı oturumu sonlandırıldıktan sonra state'i güncelle
    navigate('/');
    window.location.reload(); // Sayfayı yenile
  };





  return (
    <header>
      <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
        <NavbarBrand tag={Link} >Case1</NavbarBrand>
        <NavbarToggler onClick={toggleNavbar} className="mr-2" />
        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
          <ul className="navbar-nav flex-grow">



          <NavItem>
  {isUserLoggedIn ? ( 
    <NavLink tag={Link} className="text-dark" to="/" onClick={handleLogout}>Çıkış Yap</NavLink>
    
   ) : (
    <NavLink tag={Link} className="text-dark" to="/">Giriş Yap</NavLink>
  )}
</NavItem>





            {isUserLoggedIn && (
              <>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/counter">Sepet</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/fetch-data">Ürünler</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/salesproduct">Satış Raporu</NavLink>
                </NavItem>
              </>
            )}
          </ul>
        </Collapse>
      </Navbar>
    </header>
  );
};

export default NavMenu;