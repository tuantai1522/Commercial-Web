import {
  Button,
  CardMedia,
  CircularProgress,
  Divider,
  Grid,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
  TextField,
  Typography,
} from "@mui/material";
import { useParams } from "react-router-dom";
import { useGetProductQuery } from "../../services/apiProducts";
import PageNotFound from "../../pages/PageNotFound";
import { formatCurrency } from "../../utils/helper";
import {
  useDeleteCartItemMutation,
  useGetAllCartItemsQuery,
  useUpSertCartItemMutation,
} from "../../services/apiCarts";
import { getCookie, setCookie } from "typescript-cookie";
import { ChangeEvent, useState } from "react";
import CartItemState from "../../models/other/cartState";
import { toast } from "react-toastify";

const ProductDetails = () => {
  const [quantity, setQuantity] = useState(1);

  const { id } = useParams();
  if (!id) return <PageNotFound />;

  const { data: dataProduct, isFetching: isFetching1 } = useGetProductQuery(id);
  const { data: dataCart, isFetching: isFetching2 } = useGetAllCartItemsQuery(
    getCookie("CustomerName") || "CustomerName"
  );
  const [addCartItem] = useUpSertCartItemMutation();
  const [deleteCartItem] = useDeleteCartItemMutation();

  if (isFetching1 || isFetching2) return <CircularProgress />;

  const curItem: CartItemState = (dataCart?.dt != null &&
    dataCart?.dt.find((c) => c.productId == dataProduct?.dt.id)) || {
    cartId: -1,
    categoryName: "",
    description: "",
    id: -1,
    imageUrl: "",
    price: -1,
    productId: -1,
    productName: "",
    quantity: -1,
  };

  const handleInputItem = (event: ChangeEvent<HTMLInputElement>) => {
    const quantity = +event.target.value;
    if (quantity >= 1) setQuantity(quantity);
  };

  const handleUpsert = async () => {
    const result: any = await addCartItem({
      productId: dataProduct?.dt.id || -1,
      quantity: quantity,
      customerName: getCookie("CustomerName"),
      isAdding: curItem ? 0 : 1,
    });

    setQuantity(1);

    if (result && result.data && result.data.message) {
      toast.success(result.data.message);
    }

    if (result && result.data && result.data.customerName) {
      setCookie("CustomerName", result.data.customerName);
    }
  };

  const handleDelete = async () => {
    const result: any = await deleteCartItem(curItem.id);

    if (result && result.data && result.data.message) {
      toast.success(result.data.message);
    }
  };

  return (
    <Grid container gap={2} alignItems="center" justifyContent="space-between">
      <Grid item xs={5}>
        <CardMedia
          sx={{
            height: 280,
            backgroundSize: "cover",
            backgroundPosition: "center",
            bgcolor: "primary.light",
          }}
          image={dataProduct?.dt.imageUrl}
          title={dataProduct?.dt.name}
        />
      </Grid>
      <Grid item xs={6}>
        <Typography variant="h3">{}</Typography>
        <Divider sx={{ mb: 2 }} />
        <Typography variant="h4" color="secondary">
          {formatCurrency(dataProduct?.dt.price || -1)}
        </Typography>
        <TableContainer>
          <Table>
            <TableBody sx={{ fontSize: "1.1em" }}>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>{dataProduct?.dt.name}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Description</TableCell>
                <TableCell>{dataProduct?.dt.description}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Type</TableCell>
                <TableCell>{dataProduct?.dt.categoryName}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Quantity in stock</TableCell>
                <TableCell>{dataProduct?.dt.quantityInStock}</TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
        <Grid sx={{ mt: 3 }} container spacing={2}>
          <Grid item xs={4}>
            <TextField
              type="number"
              label="Quantity in cart"
              fullWidth
              value={quantity}
              onChange={handleInputItem}
            />
          </Grid>
          <Grid item xs={4}>
            <Button
              sx={{ height: "55px" }}
              color="primary"
              size="large"
              variant="contained"
              fullWidth
              onClick={handleUpsert}
            >
              {curItem.id != -1 ? "Update cart" : "Add to cart"}
            </Button>
          </Grid>
          {curItem.id != -1 && (
            <Grid item xs={4}>
              <Button
                sx={{ height: "55px" }}
                color="warning"
                size="large"
                variant="contained"
                fullWidth
                onClick={handleDelete}
              >
                Remove
              </Button>
            </Grid>
          )}
        </Grid>
      </Grid>
    </Grid>
  );
};

export default ProductDetails;
