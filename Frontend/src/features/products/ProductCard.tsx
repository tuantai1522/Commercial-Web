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
// import { NavLink } from "react-router-dom";

// to define all properties or methods passed from father's component
interface Props {
  product: Product;
}

const ProductCard = ({ product }: Props) => {
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
            {product.category.name}
          </Typography>
        </CardContent>
        <CardActions>
          <Button size="small">Add to cart</Button>

          <Button size="small">
            {/* <NavLink to={`/catalog/${product.id}`}> */}
            View
            {/* </NavLink> */}
          </Button>
        </CardActions>
      </Card>
    </>
  );
};

export default ProductCard;
