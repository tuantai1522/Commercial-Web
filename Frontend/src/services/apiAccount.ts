import { BACKEND_URL } from "../utils/config";
import axios from "../setup/axios";
import ApiResponse from "../models/other/apiResponse";
import User from "../models/class/user";
import LoginState from "../models/other/LoginState";
import RegisterState from "../models/other/RegisterState";

const loginUser = async (data: LoginState) => {
  try {
    const response = await axios.post<any>(
      `${BACKEND_URL}/api/Account/Login`,
      data
    );

    return response;
  } catch (error) {
    console.error("Error logging", error);
    throw error;
  }
};

const registerUser = async (data: RegisterState) => {
  try {
    const response = await axios.post<any>(
      `${BACKEND_URL}/api/Account/Register`,
      data
    );

    return response;
  } catch (error) {
    console.error("Error signing up", error);
    throw error;
  }
};

const getCurrentUser = async () => {
  try {
    const response = await axios.get<ApiResponse<User>>(
      `${BACKEND_URL}/api/Account`
    );

    return response;
  } catch (error) {
    console.error("Error fetching current user", error);
    throw error;
  }
};

export { loginUser, registerUser, getCurrentUser };
