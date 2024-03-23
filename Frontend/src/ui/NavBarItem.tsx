import React from "react";
import { NavLink } from "react-router-dom";
import Typography from "@mui/material/Typography";

interface Props {
  to: string;
  children: React.ReactNode;
}

const style: React.CSSProperties = {
  textTransform: "uppercase",
  color: "inherit",
  textDecoration: "none",
};

const NavBarItem = ({ to, children }: Props) => {
  return (
    <NavLink to={to} style={style}>
      <Typography
        variant="h6"
        sx={{
          "&:hover": {
            color: "grey.500",
          },
          "&:actice": { color: "text.secondary" },
        }}
      >
        {children}
      </Typography>
    </NavLink>
  );
};

export default NavBarItem;
