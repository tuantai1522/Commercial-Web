import { useQuery } from "@tanstack/react-query";

import { fetchAllCategories } from "../../services/apiCategories";

export const useReadCategory = () => {
  const {
    isLoading: isFetching,
    data,
    error,
  } = useQuery({
    //Nếu các queryKey thay đổi, sẽ fetch lại data
    queryKey: ["categories"],
    queryFn: () => fetchAllCategories(),
  });

  return { isFetching, data, error };
};
