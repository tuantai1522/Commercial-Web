import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import User from "../models/class/user";
import {
  getCurrentUser,
  loginUser,
  registerUser,
} from "../services/apiAccount";
import { toast } from "react-toastify";
import LoginState from "../models/other/LoginState";
import RegisterState from "../models/other/RegisterState";

interface AccountState {
  user: User | null;
}
const initialState: AccountState = {
  user: null,
};

export const signInUser = createAsyncThunk<User, LoginState>(
  "account/signInUser",
  async (data: LoginState, thunkAPI: any) => {
    try {
      const dataUser: any = await loginUser(data);

      if (dataUser && dataUser.status == 1) {
        toast.success(dataUser.message);
        localStorage.setItem("user", JSON.stringify(dataUser.dt));
      } else {
        toast.error(dataUser.message);
      }

      return dataUser.dt;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.data });
    }
  }
);

export const signUpUser = createAsyncThunk<User, RegisterState>(
  "account/signUpUser",
  async (data: RegisterState, thunkAPI: any) => {
    try {
      const dataUser: any = await registerUser(data);

      return dataUser;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.data });
    }
  }
);
export const fetchCurrentUser = createAsyncThunk<User>(
  "account/fetchCurrentUser",
  async (_, thunkAPI) => {
    thunkAPI.dispatch(setUser(JSON.parse(localStorage.getItem("user")!)));

    try {
      const data: any = await getCurrentUser();

      if (data && data.status == 1) {
        toast.success(data.message);
        localStorage.setItem("user", JSON.stringify(data.dt));
      } else {
        toast.error(data.message);
      }

      return data.dt;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.data });
    }
  },

  //if I don't have user in localStorage => don't call api
  {
    condition: () => {
      if (!localStorage.getItem("user")) return false;
    },
  }
);

export const accountSlice = createSlice({
  name: "accounts",
  initialState,
  reducers: {
    logOut: (state) => {
      state.user = null;
      localStorage.removeItem("user");
    },
    setUser: (state, action) => {
      state.user = action.payload;
    },
  },

  extraReducers: (builder) => {
    //fetchCurrentUser
    builder.addCase(fetchCurrentUser.rejected, (state) => {
      state.user = null;
      localStorage.removeItem("user");
      toast.error("Please log in again");
    });

    //login user
    builder.addMatcher(
      isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled),
      (state, action) => {
        state.user = action.payload;
      }
    );
    builder.addMatcher(isAnyOf(signInUser.rejected), (_state, action) => {
      throw action.payload;
    });

    //register user
  },
});

export const { logOut, setUser } = accountSlice.actions;
