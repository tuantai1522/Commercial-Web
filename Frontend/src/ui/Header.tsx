import {
  AppBar,
  Grid,
  IconButton,
  Switch,
  Toolbar,
  Badge,
} from "@mui/material";
import MyNavLink from "./MyNavLink";
import { ShoppingCart } from "@mui/icons-material";
import { useGetAllCartItemsQuery } from "../services/apiCarts";
import { getCookie } from "typescript-cookie";
import CartItemState from "../models/other/cartState";
import { useAppSelector } from "../store/store";

import SignInMenu from "./SignInMenu";

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
  const { user } = useAppSelector((state) => state.account);

  const { data } = useGetAllCartItemsQuery(
    getCookie("CustomerName") || "CustomerName"
  );

  let carts: any = [];
  if (data && data.dt) {
    carts = data.dt;
  }

  const totalItems = carts.reduce(
    (accumulator: number, currentValue: CartItemState) => {
      return accumulator + currentValue.quantity;
    },
    0
  );

  return (
    <>
      <AppBar position="static">
        <Toolbar>
          <Grid container alignItems="center" justifyContent="space-between">
            <Grid item>
              <Grid container alignItems="center">
                <MyNavLink to="/" children="My store" />
                <Switch />
              </Grid>
            </Grid>
            <Grid item>
              <Grid container gap={2} alignItems="center">
                {midLinks.map((item) => (
                  <MyNavLink
                    key={item.to}
                    to={item.to}
                    children={item.children}
                  />
                ))}
              </Grid>
            </Grid>
            <Grid item>
              <Grid container gap={2} alignItems="center">
                <MyNavLink to="/cart">
                  <IconButton
                    href="/cart"
                    size="large"
                    edge="start"
                    color="inherit"
                  >
                    <Badge badgeContent={totalItems} color="secondary">
                      <ShoppingCart />
                    </Badge>
                  </IconButton>
                </MyNavLink>

                {user?.userName ? (
                  <SignInMenu user={user} />
                ) : (
                  <>
                    {rightLinks.map((item) => (
                      <MyNavLink key={item.to} to={item.to}>
                        {item.children}
                      </MyNavLink>
                    ))}
                  </>
                )}
              </Grid>
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>
    </>
  );
};

export default Header;
