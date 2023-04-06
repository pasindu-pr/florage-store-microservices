import { createBrowserRouter } from "react-router-dom";
import { Account, Homepage , Login , Product , Profile, Register} from "./pages";


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
]);

export default router;
