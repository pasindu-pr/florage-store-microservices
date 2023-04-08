import { createBrowserRouter } from "react-router-dom";
import { Account, Homepage , Login , Product , Profile , Register , Checkout , Shop} from "./pages";


const router = createBrowserRouter([
  {
    path: "/",
    element: <Homepage />,
  },
  {
    path: "/about",
    element: <>About us</>,
  },
  {
    path: "/account",
    element: <Account/>,
  },
  {
    path: "/login",
    element: <Login/>,
  },

  {
    path: "/product",
    element: <Product/>,
  },

  {
    path: "/profile",
    element: <Profile/>,
  },

  {
    path: "/register",
    element: <Register/>,
  },

  {
    path: "/checkout",
    element: <Checkout/>,
  },

  {
    path: "/shop",
    element: <Shop/>,
  },
]);

export default router;
