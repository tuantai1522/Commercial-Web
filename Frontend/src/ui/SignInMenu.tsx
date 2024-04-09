import Button from "@mui/material/Button";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import { MouseEvent, useState } from "react";
import User from "../models/class/user";
import { logOut } from "../redux/AccountSlice";
import { useAppDispatch } from "../store/store";
interface Props {
  user: User;
}

const style: React.CSSProperties = {
  textTransform: "uppercase",
  color: "inherit",
  textDecoration: "none",
};

export default function SignInMenu({ user }: Props) {
  const dispatch = useAppDispatch();

  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);
  const handleClick = (event: MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleLogout = () => {
    dispatch(logOut());
  };
  return (
    <>
      <Button style={style} onClick={handleClick}>
        {user.userName}
      </Button>
      <Menu anchorEl={anchorEl} open={open} onClose={handleClose}>
        <MenuItem onClick={handleClose}>Profile</MenuItem>
        <MenuItem onClick={handleClose}>My order</MenuItem>
        <MenuItem onClick={handleLogout}>Logout</MenuItem>
      </Menu>
    </>
  );
}
