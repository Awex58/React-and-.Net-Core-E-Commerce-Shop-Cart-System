import React, { createContext, useState } from 'react';

const NavigationContext = createContext();

const NavigationProvider = ({ children }) => {
  const [isUserLoggedIn, setIsUserLoggedIn] = useState(false);

  const loginUser = () => {
    setIsUserLoggedIn(true);
  };

  return (
    <NavigationContext.Provider value={{ isUserLoggedIn, loginUser }}>
      {children}
    </NavigationContext.Provider>
  );
};

export { NavigationProvider, NavigationContext };
