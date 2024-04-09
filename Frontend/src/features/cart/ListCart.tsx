import { getCookie } from "typescript-cookie";
import {
  useDeleteCartItemMutation,
  useGetAllCartItemsQuery,
  useUpSertCartItemMutation,
} from "../../services/apiCarts";
import {
  Box,
  Button,
  CircularProgress,
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import { formatCurrency } from "../../utils/helper";
import { Add, Delete, Remove } from "@mui/icons-material";
import { NavLink } from "react-router-dom";
import CartItemState from "../../models/other/cartState";
import { toast } from "react-toastify";
import { CartItemParams } from "../../models/other/cartParam";
import { CartSummary } from "./CartSummary";

const ListCart = () => {
  const { data, isFetching } = useGetAllCartItemsQuery(
    getCookie("CustomerName") || "CustomerName"
  );

  const [upsertCartItem] = useUpSertCartItemMutation();
  const [deleteCartItem] = useDeleteCartItemMutation();

  if (isFetching) return <CircularProgress />;

  let carts: any = [];
  if (data && data.dt) {
    carts = data.dt;
  }

  const handleItem = async (params: CartItemParams) => {
    const result: any = await upsertCartItem({
      productId: params.productId,
      quantity: params.quantity,
      customerName: params.customerName,
      isAdding: params.isAdding,
    });

    if (result && result.data && result.data.message) {
      toast.success(result.data.message);
    }
  };

  const handleDelete = async (productId: number) => {
    const result: any = await deleteCartItem(productId);

    if (result && result.data && result.data.message) {
      toast.success(result.data.message);
    }
  };

  if (!carts || carts.length == 0)
    return (
      <>
        <Typography variant="h2">Your cart is empty</Typography>
      </>
    );

  return (
    <>
      <Grid container>
        <Grid item xs={2}></Grid>
        <Grid item xs={8}>
          <Typography variant="h2">Cart Page</Typography>
          <>
            <TableContainer component={Paper}>
              <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell>Product</TableCell>
                    <TableCell align="right">Price</TableCell>
                    <TableCell align="center">Quantity</TableCell>
                    <TableCell align="right">Subtotal</TableCell>
                    <TableCell align="right">Actions</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {carts.map((item: CartItemState) => (
                    <TableRow
                      key={item.productId}
                      sx={{
                        "&:last-child td, &:last-child th": { border: 0 },
                      }}
                    >
                      <TableCell component="th" scope="row">
                        <Box display="flex" alignItems="center">
                          <img
                            style={{
                              height: 50,
                              marginRight: 20,
                              width: 50,
                            }}
                            src={item.imageUrl}
                            alt={item.productName}
                          />
                          <span>{item.productName}</span>
                        </Box>
                      </TableCell>
                      <TableCell align="right">
                        {formatCurrency(item.price)}
                      </TableCell>
                      <TableCell align="center">
                        <Button
                          onClick={() => {
                            handleItem({
                              productId: item.productId,
                              quantity: -1,
                              customerName: getCookie("CustomerName"),
                              isAdding: 1,
                            });
                          }}
                          color="error"
                        >
                          <Remove />
                        </Button>
                        {item.quantity}
                        <Button
                          onClick={() => {
                            handleItem({
                              productId: item.productId,
                              quantity: 1,
                              customerName: getCookie("CustomerName"),
                              isAdding: 1,
                            });
                          }}
                          color="secondary"
                        >
                          <Add />
                        </Button>
                      </TableCell>
                      <TableCell align="right">
                        ${(item.price * item.quantity).toFixed(2)}
                      </TableCell>
                      <TableCell align="right">
                        <Button
                          onClick={() => handleDelete(item.id)}
                          color="error"
                        >
                          <Delete />
                        </Button>
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
            <Grid container>
              <Grid item xs={6} />
              <Grid item xs={6} sx={{ mt: 3 }}>
                <CartSummary carts={carts} />
                <Button
                  component={NavLink}
                  to="/checkout"
                  variant="contained"
                  size="large"
                  fullWidth
                  sx={{ mt: 3 }}
                >
                  Checkout
                </Button>
              </Grid>
            </Grid>
          </>
        </Grid>
        <Grid item xs={2}></Grid>
      </Grid>
    </>
  );
};

export default ListCart;
