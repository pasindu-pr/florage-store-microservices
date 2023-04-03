import { createBrowserRouter } from "react-router-dom";
import { Homepage } from "./pages";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Homepage />,
  },
  {
    path: "/about",
    element: <>About</>,
  },
]);

export default router;
