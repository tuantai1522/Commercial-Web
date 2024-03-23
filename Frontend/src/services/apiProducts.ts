// Need to use the React-specific entry point to import createApi
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { BACKEND_URL } from "../utils/config";
import { ProductParams } from "../models/other/productParams";
import ProductState from "../models/other/productState";

// Define a service using a base URL and expected endpoints
export const productApi = createApi({
  reducerPath: "products",
  baseQuery: fetchBaseQuery({ baseUrl: BACKEND_URL }),

  endpoints: (builder) => ({
    getAllProducts: builder.query<ProductState, ProductParams | void>({
      query: (args) => {
        if (!args) return "/api/Product";

        const { orderBy, keyWord, categoryTypes } = args;

        const type = categoryTypes.join("%2C");

        return `/api/Product?OrderBy=${orderBy}&KeyWord=${keyWord}&CategoryType=${type}`;
      },
    }),
  }),
});

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints
export const { useGetAllProductsQuery } = productApi;
