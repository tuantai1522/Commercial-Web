import Category from "./category";

interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
  categoryId: number;
  quantityInStock: number;
  category: Category;
}

export default Product;
