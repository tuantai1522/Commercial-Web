import "./App.css";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";

import AppLayout from "./ui/AppLayout";
import Home from "./pages/Home";

import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";

import About from "./features/about/about";
import ProductPage from "./pages/ProductPage";
import ProductDetailsPage from "./pages/ProductDetailsPage";
import PageNotFound from "./pages/PageNotFound";
import CartPage from "./pages/CartPage";
import CheckoutPage from "./pages/CheckoutPage";
import Login from "./pages/Login";
import Register from "./pages/Register";

import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import PrivateRoutes from "./ProtectedRoutes";

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      // the amount of time that the data in the cache will stay fresh (not fresh new data in server)
      staleTime: 0,
    },
  },
});

function App() {
  return (
    <>
      <QueryClientProvider client={queryClient}>
        <ReactQueryDevtools initialIsOpen={false} />

        <BrowserRouter>
          <Routes>
            <Route element={<AppLayout />}>
              <Route element={<PrivateRoutes />}>
                <Route path="checkout" element={<CheckoutPage />} />
              </Route>

              <Route index element={<Navigate replace to="home" />} />
              <Route path="home" element={<Home />} />
              <Route path="product" element={<ProductPage />} />
              <Route path="product/:id" element={<ProductDetailsPage />} />
              <Route path="about" element={<About />} />
              <Route path="cart" element={<CartPage />} />
              <Route path="login" element={<Login />} />
              <Route path="register" element={<Register />} />
              <Route path="*" element={<PageNotFound />} />
            </Route>
          </Routes>
        </BrowserRouter>
      </QueryClientProvider>
      {/* Display toast */}
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="light"
      />
    </>
  );
}

export default App;
