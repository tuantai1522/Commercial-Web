interface ApiResponseArray<T> {
  message: string;
  status: number;
  dt: Array<T>;
}

export default ApiResponseArray;
