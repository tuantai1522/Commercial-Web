import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";

import MyNavLink from "../../ui/MyNavLink";
import CopyRight from "../../ui/CopyRight";
import { FieldValues, useForm } from "react-hook-form";
import { useAppDispatch } from "../../store/store";
import { signUpUser } from "../../redux/AccountSlice";
import { toast } from "react-toastify";

// TODO remove, this demo shouldn't need to reset the theme.
const defaultTheme = createTheme();

export default function Register() {
  const {
    register,
    handleSubmit,
    formState: { errors, isValid },
    getValues,
    reset,
  } = useForm({
    mode: "onTouched",
  });

  const dispatch = useAppDispatch();
  const submitForm = async (data: FieldValues) => {
    try {
      const dataUser: any = await dispatch(
        signUpUser({
          RegisterDTO: {
            userName: data.userName,
            email: data.email,
            password: data.password,
          },
        })
      );

      if (dataUser && dataUser.payload && dataUser.payload.status == 1) {
        toast.success(dataUser.payload.message);
        reset();
      } else {
        toast.error(dataUser.payload.message);
      }
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
            Sign up
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit(submitForm)}
            noValidate
            sx={{ mt: 3 }}
          >
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  label="User Name"
                  {...register("userName", {
                    required: "User Name is required",
                  })}
                  autoFocus
                  error={!!errors.userName}
                  helperText={errors.userName?.message as string}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  label="Email Address"
                  {...register("email", {
                    required: "Email is required",
                  })}
                  error={!!errors.email}
                  helperText={errors.email?.message as string}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  label="Password"
                  type="password"
                  {...register("password", {
                    required: "Password is required",
                    minLength: 6,
                    pattern: {
                      value:
                        /^(?=.*[0-9])(?=.*[a-z])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,}$/,
                      message:
                        "Password must contain at least one special character, one number, and one lowercase letter",
                    },
                  })}
                  error={!!errors.password}
                  helperText={errors.password?.message as string}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  label="Confirm password"
                  type="password"
                  {...register("confirmPassword", {
                    required: "Confirm password is required",
                    validate: (value) =>
                      value === getValues().password ||
                      "Password should be the same",
                  })}
                  error={!!errors.confirmPassword}
                  helperText={errors.confirmPassword?.message as string}
                />
              </Grid>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              disabled={!isValid}
            >
              Sign Up
            </Button>
            <Grid container justifyContent="flex-end">
              <Grid item>
                <MyNavLink
                  isHeader={false}
                  customStyles={{
                    textTransform: "none",
                  }}
                  to={"/login"}
                >
                  Already have an account. Log in
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
