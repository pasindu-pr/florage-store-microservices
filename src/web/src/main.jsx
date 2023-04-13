import React from "react";
import ReactDOM from "react-dom/client";
import { RouterProvider } from "react-router-dom";

import "./index.css";
import router from "./routes";
import Footer from "./pages/footer";
import Navigation from "./pages/navigation";

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <Navigation/>
    <RouterProvider router={router} />
    <Footer/>
  </React.StrictMode>
);
