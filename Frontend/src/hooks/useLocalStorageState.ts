import { useState, useEffect } from "react";

const useLocalStorageState = (initialValue: object, keyName: string) => {
  const [value, setValue] = useState(function () {
    const storedValue = localStorage.getItem(keyName);

    //mếu tìm thấy storedValue thì parse không thì return giá trị ban đầu
    return storedValue ? JSON.parse(storedValue) : initialValue;
  });

  //to store on local storage
  useEffect(
    function () {
      localStorage.setItem(keyName, JSON.stringify(value));
    },
    [value, keyName]
  );

  return [value, setValue];
};

export default useLocalStorageState;
