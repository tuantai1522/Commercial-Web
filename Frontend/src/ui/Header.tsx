import { AppBar, Grid, Switch, Toolbar } from "@mui/material";
import NavBarItem from "./NavBarItem";

const midLinks = [
  {
    to: "/product",
    children: "Product",
  },
  {
    to: "/about",
    children: "About",
  },
  {
    to: "/contact",
    children: "Contact",
  },
];

const rightLinks = [
  {
    to: "/login",
    children: "Login",
  },
  {
    to: "/register",
    children: "Register",
  },
];
const Header = () => {
  return (
    <>
      <AppBar position="static">
        <Toolbar>
          <Grid container justifyContent="space-between">
            <Grid item>
              <Grid container alignItems="center">
                <NavBarItem to="/" children="My store" />
                <Switch />
              </Grid>
            </Grid>
            <Grid item>
              <Grid container gap={2} alignItems="center">
                {midLinks.map((item) => (
                  <NavBarItem to={item.to} children={item.children} />
                ))}
              </Grid>
            </Grid>
            <Grid item>
              <Grid container gap={2} alignItems="center">
                {rightLinks.map((item) => (
                  <NavBarItem to={item.to}>{item.children}</NavBarItem>
                ))}
              </Grid>
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>
    </>
  );
};

export default Header;
