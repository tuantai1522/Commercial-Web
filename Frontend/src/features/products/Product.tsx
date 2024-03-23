import { CircularProgress, Grid } from "@mui/material";
import ProductType from "./ProductType";
import ProductSort from "./ProductSort";
import ProductList from "./ProductList";
import { useGetAllProductsQuery } from "../../services/apiProducts";
import { PAGE_NUMBER, PAGE_SIZE } from "../../utils/config";
import { useState } from "react";
import { ProductParams } from "../../models/other/productParams";
import ProductSearch from "./ProductSearch";

const initialState: ProductParams = {
  orderBy: "name",
  keyWord: "",
  categoryTypes: [],
  pageNumber: PAGE_NUMBER,
  pageSize: PAGE_SIZE,
};

const Product = () => {
  const [params, setParams] = useState<ProductParams>(initialState);
  const { data, isFetching } = useGetAllProductsQuery(params);

  if (isFetching) return <CircularProgress />;

  const { dt: rawData }: any = data;

  const { totalCount, totalPages, products } = rawData;

  return (
    <>
      <Grid container spacing={4}>
        <Grid item xs={3}>
          <ProductSearch
            textValue={params.keyWord}
            onChange={(event: React.ChangeEvent<HTMLInputElement>) =>
              setParams({ ...params, keyWord: event.target.value })
            }
          />
          <ProductSort
            item={params.orderBy}
            onChange={(event: React.ChangeEvent<HTMLInputElement>) =>
              setParams({ ...params, orderBy: event.target.value })
            }
          />
          <ProductType
            checked={params.categoryTypes}
            onChange={(checkedItems: string[]) =>
              setParams({ ...params, categoryTypes: checkedItems })
            }
          />
        </Grid>
        <Grid item xs={9}>
          <ProductList products={products} />
        </Grid>
      </Grid>
    </>
  );
};

export default Product;
