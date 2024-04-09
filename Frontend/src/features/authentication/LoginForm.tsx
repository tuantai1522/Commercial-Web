import { ThemeProvider } from "@mui/material/styles";
import { Box } from "@mui/material";
import createTheme from "@mui/material/styles/createTheme";

import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";

import CssBaseline from "@mui/material/CssBaseline";
import { Container } from "@mui/material";

import { useLocation, useNavigate } from "react-router-dom";

import { FieldValues, useForm } from "react-hook-form";

import { useAppDispatch } from "../../store/store";
import { signInUser } from "../../redux/AccountSlice";
import MyNavLink from "../../ui/MyNavLink";
import CopyRight from "../../ui/CopyRight";

// TODO remove, this demo shouldn't need to reset the theme.

const defaultTheme = createTheme();

function LoginForm() {
  const {
    register,
    handleSubmit,
    formState: { errors, isValid },
  } = useForm({
    mode: "onTouched",
  });

  const navigate = useNavigate();
  const location = useLocation();

  const dispatch = useAppDispatch();

  const submitForm = async (data: FieldValues) => {
    try {
      const dataUser: any = await dispatch(
        signInUser({
          LoginDTO: {
            userName: data.userName,
            password: data.password,
          },
        })
      );

      if (dataUser && dataUser.payload)
        navigate(location.state?.from || "/product");
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign in
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit(submitForm)}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              required
              fullWidth
              label="User name"
              defaultValue="test"
              {...register("userName", { required: "User name is required" })}
              autoFocus
              error={!!errors.userName}
              helperText={errors.userName?.message as string}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              label="Password"
              type="password"
              defaultValue="P@ssw0rd"
              {...register("password", { required: "Password is required" })}
              error={!!errors.password}
              helperText={errors.password?.message as string}
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              disabled={!isValid}
            >
              Sign In
            </Button>
            <Grid container>
              <Grid item xs>
                <MyNavLink
                  isHeader={false}
                  customStyles={{
                    textTransform: "none",
                  }}
                  to={"/register"}
                >
                  Forgot password?
                </MyNavLink>
              </Grid>
              <Grid item>
                <MyNavLink
                  isHeader={false}
                  customStyles={{
                    textTransform: "none",
                  }}
                  to={"/register"}
                >
                  Don't have an account? Sign Up
                </MyNavLink>
              </Grid>
            </Grid>
          </Box>
        </Box>
        <CopyRight />
      </Container>
    </ThemeProvider>
  );
}

export default LoginForm;
