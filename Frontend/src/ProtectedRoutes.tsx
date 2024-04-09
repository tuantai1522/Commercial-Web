import { Outlet, useNavigate } from "react-router-dom";
import { useAppSelector } from "./store/store";
import { useEffect } from "react";

const PrivateRoutes = () => {
  const { user } = useAppSelector((state) => state.account);

  const navigate = useNavigate();

  useEffect(
    function () {
      if (!user) navigate("/login");
    },
    [user, navigate]
  );

  if (user) return <Outlet />;
};

export default PrivateRoutes;
