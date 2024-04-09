import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
} from "@mui/material";
import { formatCurrency } from "../../utils/helper";
import CartItemState from "../../models/other/cartState";

interface Props {
  carts: CartItemState[];
}
export const CartSummary = ({ carts }: Props) => {
  const subtotal =
    carts.reduce(
      (accumulator, item) => accumulator + item.quantity * item.price,
      0
    ) ?? 0;
  const deliveryFee = subtotal > 100 ? 0 : 5;
  const total = subtotal + deliveryFee;

  return (
    <>
      <TableContainer component={Paper} variant={"outlined"}>
        <Table>
          <TableBody>
            <TableRow>
              <TableCell colSpan={2}>Subtotal</TableCell>
              <TableCell align="right">{formatCurrency(subtotal)}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell colSpan={2}>Delivery fee*</TableCell>
              <TableCell align="right">{formatCurrency(deliveryFee)}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell colSpan={2}>Total</TableCell>
              <TableCell align="right">{formatCurrency(total)}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell>
                <span style={{ fontStyle: "italic" }}>
                  *Orders over $100 qualify for free delivery
                </span>
              </TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    </>
  );
};
