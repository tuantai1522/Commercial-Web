import axios from "../setup/axios";

import { BACKEND_URL } from "../utils/config";
import ApiResponse from "../models/other/apiResponse";
import Category from "../models/class/category";

const fetchAllCategories = async () => {
  try {
    const response = await axios.get<ApiResponse<Category>>(
      `${BACKEND_URL}/api/category`
    );

    return response;
  } catch (error) {
    console.error("Error fetching categories:", error);
    throw error;
  }
};

export { fetchAllCategories };
