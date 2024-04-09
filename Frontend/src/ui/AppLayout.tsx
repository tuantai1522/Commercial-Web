import { CircularProgress, Grid } from "@mui/material";
import { Outlet } from "react-router-dom";
import Header from "./Header";
import { useCallback, useEffect, useState } from "react";
import { useAppDispatch } from "../store/store";
import { fetchCurrentUser } from "../redux/AccountSlice";

const AppLayout = () => {
  const dispatch = useAppDispatch();
  const [loading, setLoading] = useState(true);

  const initApp = useCallback(async () => {
    try {
      await dispatch(fetchCurrentUser());
    } catch (error) {
      console.log(error);
    }
  }, [dispatch]);

  useEffect(() => {
    initApp().then(() => setLoading(false));
  }, [initApp]);

  if (loading) return <CircularProgress />;

  return (
    <>
      <Grid container spacing={2}>
        <Grid item xs={12} style={{ padding: 8 }}>
          <Header />
        </Grid>
        <Grid item xs={12} sx={{ mt: 5, mb: 5 }}>
          <Outlet />
        </Grid>
      </Grid>
    </>
  );
};

export default AppLayout;
