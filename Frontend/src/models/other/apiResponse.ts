interface ApiResponse<T> {
  message: string;
  status: number;
  dt: T;
}

export default ApiResponse;
