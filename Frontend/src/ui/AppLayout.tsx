import { Grid } from "@mui/material";
import { Outlet } from "react-router-dom";
import Header from "./Header";

const AppLayout = () => {
  return (
    <>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <Header />
        </Grid>
        <Grid item xs={12} spacing={2}>
          <Outlet />
        </Grid>
      </Grid>
    </>
  );
};

export default AppLayout;
