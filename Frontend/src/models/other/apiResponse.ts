interface ApiResponse<T> {
  message: string;
  status: number;
  DT: Array<T>;
}

export default ApiResponse;
