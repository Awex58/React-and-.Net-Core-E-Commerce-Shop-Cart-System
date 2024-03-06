import  Counter  from "./components/Counter";
import { FetchData } from "./components/FetchData";
import  Home  from "./components/Home";
import SatisRaporu from "./components/SatisRaporu";
import  ProductDetailPage from "./components/ProductDetailPage";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/salesproduct',
    element: <SatisRaporu />
  },
  {
    path: '/product/:id',
    element: <ProductDetailPage/>
  }
];

export default AppRoutes;