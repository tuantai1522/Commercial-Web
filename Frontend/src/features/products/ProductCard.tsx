import {
  CardContent,
  Typography,
  Button,
  CardActions,
  CardMedia,
  Card,
  CardHeader,
  Avatar,
} from "@mui/material";
import Product from "../../models/class/product.ts";
import { formatCurrency } from "../../utils/helper.ts";
import { useUpSertCartItemMutation } from "../../services/apiCarts.ts";
import { getCookie, setCookie } from "typescript-cookie";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

// import { NavLink } from "react-router-dom";

// to define all properties or methods passed from father's component
interface Props {
  product: Product;
}

const ProductCard = ({ product }: Props) => {
  const navigate = useNavigate();
  const [upsertCartItem] = useUpSertCartItemMutation();

  const handleSubmit = async () => {
    const result: any = await upsertCartItem({
      productId: product.id,
      quantity: 1,
      customerName: getCookie("CustomerName"),
      isAdding: 1,
    });

    if (result && result.data && result.data.message) {
      toast.success(result.data.message);
    }

    if (result && result.data && result.data.customerName) {
      setCookie("CustomerName", result.data.customerName);
    }
  };
  return (
    <>
      <Card>
        <CardHeader
          avatar={
            <Avatar sx={{ bgcolor: "secondary.main" }}>
              {product.name.charAt(0).toUpperCase()}
            </Avatar>
          }
          title={product.name}
          titleTypographyProps={{
            sx: { fontWeight: "bold", color: "secondary.main" },
          }}
        />

        <CardMedia
          sx={{
            height: 280,
            backgroundSize: "cover",
            backgroundPosition: "center",
            bgcolor: "primary.light",
          }}
          image={product.imageUrl}
          title={product.name}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" color="secondary">
            {formatCurrency(product.price)}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            {product.categoryName}
          </Typography>
        </CardContent>
        <CardActions>
          <Button onClick={handleSubmit} size="small">
            Add to cart
          </Button>

          <Button
            size="small"
            onClick={() => navigate(`/product/${product.id}`)}
          >
            View
          </Button>
        </CardActions>
      </Card>
    </>
  );
};

export default ProductCard;
