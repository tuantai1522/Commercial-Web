// Need to use the React-specific entry point to import createApi
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { BACKEND_URL } from "../utils/config";
import { ProductParams } from "../models/other/productParams";
import Product from "../models/class/product";
import ApiResponseArray from "../models/other/apiResponseArray";
import ApiResponse from "../models/other/apiResponse";

// Define a service using a base URL and expected endpoints
export const productApi = createApi({
  reducerPath: "products",
  baseQuery: fetchBaseQuery({ baseUrl: BACKEND_URL }),

  endpoints: (builder) => ({
    getAllProducts: builder.query<
      ApiResponseArray<Product>,
      ProductParams | void
    >({
      query: (args) => {
        if (!args) return "/api/Product";

        const { orderBy, keyWord, categoryTypes, pageNumber } = args;

        const type = categoryTypes.join("%2C");

        return `/api/Product?OrderBy=${orderBy}&KeyWord=${keyWord}&CategoryType=${type}&PageNumber=${pageNumber}`;
      },
    }),
    getProduct: builder.query<ApiResponse<Product>, string>({
      query: (args) => `/api/Product/${args}/getProductById`,
    }),
  }),
});

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints
export const { useGetAllProductsQuery, useGetProductQuery } = productApi;
