interface CartItemState {
  id: number;
  cartId: number;
  productId: number;
  quantity: number;
  productName: string;
  description: string;
  price: number;
  imageUrl: string;
  categoryName: string;
}

export default CartItemState;
