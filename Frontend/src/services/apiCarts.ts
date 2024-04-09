// Need to use the React-specific entry point to import createApi
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { BACKEND_URL } from "../utils/config";
import CartItemState from "../models/other/cartState";
import { CartItemParams } from "../models/other/cartParam";
import ApiResponse from "../models/other/apiResponseArray";

// Define a service using a base URL and expected endpoints
export const cartApi = createApi({
  reducerPath: "carts",
  tagTypes: ["Carts"],
  baseQuery: fetchBaseQuery({ baseUrl: BACKEND_URL }),

  endpoints: (builder) => ({
    getAllCartItems: builder.query<ApiResponse<CartItemState>, string>({
      query: (args) => `/api/CartItem/${args}`,
      providesTags(result) {
        if (result?.dt) {
          const final = [
            ...result.dt.map(({ id }: any) => ({
              type: "Carts" as const,
              id,
            })),
            { type: "Carts" as const, id: "LIST" },
          ];
          return final;
        }

        const final = [{ type: "Carts" as const, id: "LIST" }];

        return final;
      },
    }),
    upSertCartItem: builder.mutation<CartItemState, CartItemParams>({
      query: (args) => {
        return {
          url: "/api/CartItem",
          method: "POST",
          body: args,
        };
      },
      invalidatesTags: () => [{ type: "Carts", id: "LIST" }],
    }),
    deleteCartItem: builder.mutation<ApiResponse<CartItemState>, number>({
      query: (id) => {
        return {
          url: `/api/CartItem/${id}`,
          method: "DELETE",
        };
      },

      //this will fetch API again
      invalidatesTags: (result, error, id) => [{ type: "Carts", id }],
    }),
  }),
});

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints
export const {
  useGetAllCartItemsQuery,
  useUpSertCartItemMutation,
  useDeleteCartItemMutation,
} = cartApi;
