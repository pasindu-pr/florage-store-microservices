import { createBrowserRouter } from "react-router-dom";
import { Account, Homepage , Login , Product} from "./pages";


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
]);

export default router;
