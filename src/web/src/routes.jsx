import { createBrowserRouter } from "react-router-dom";
import { Account, Homepage , Login } from "./pages";


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
]);

export default router;
