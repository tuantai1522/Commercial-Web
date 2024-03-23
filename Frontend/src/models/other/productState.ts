import Product from "../class/product";
import { MetaData } from "./MetaData";
import { ProductParams } from "./productParams";

interface ProductState {
  productsLoaded: boolean;
  status: string;

  products: Product[];

  productParams: ProductParams;
  metaData: MetaData | null;
}

export default ProductState;
