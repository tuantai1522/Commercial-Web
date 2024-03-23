import { AxiosResponse } from "axios";
import axios from "../setup/axios";

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
  get: (url: string, params?: URLSearchParams) =>
    axios.get(url, { params }).then(responseBody),
};

const Product = {
  list: (params: URLSearchParams) => requests.get("products", params),
};

const agent = {
  Product,
};

export default agent;
