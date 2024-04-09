import { Grid, Pagination, Stack } from "@mui/material";
import ProductType from "./ProductType";
import ProductSort from "./ProductSort";
import { useGetAllProductsQuery } from "../../services/apiProducts";
import { PAGE_NUMBER, PAGE_SIZE } from "../../utils/config";
import { ProductParams } from "../../models/other/productParams";
import ProductSearch from "./ProductSearch";
import ProductCardSkeleton from "./ProductCardSkeleton";
import { useState } from "react";
import ListCard from "./ListCard";
import Prod from "../../models/class/product";
import ProductCard from "./ProductCard";

const initialState: ProductParams = {
  orderBy: "name",
  keyWord: "",
  categoryTypes: [],
  pageNumber: PAGE_NUMBER,
  pageSize: PAGE_SIZE,
};

const Product = () => {
  const [page, setPage] = useState(1);
  const [params, setParams] = useState<ProductParams>(initialState);
  const { data, isFetching } = useGetAllProductsQuery(params);

  const { dt: rawData }: any = !isFetching && data;

  const { totalPages, products } = !isFetching && rawData;

  return (
    <>
      <Grid container spacing={4}>
        <Grid item xs={3}>
          <ProductSearch
            textValue={params.keyWord}
            onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
              setParams({
                ...params,
                keyWord: event.target.value,
                pageNumber: 1,
              });
              setPage(1);
            }}
          />
          <ProductSort
            item={params.orderBy}
            onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
              setParams({
                ...params,
                orderBy: event.target.value,
                pageNumber: 1,
              });
              setPage(1);
            }}
          />
          <ProductType
            checked={params.categoryTypes}
            onChange={(checkedItems: string[]) => {
              setParams({
                ...params,
                categoryTypes: checkedItems,
                pageNumber: 1,
              });
              setPage(1);
            }}
          />
        </Grid>
        <Grid item xs={9}>
          <Grid container alignItems="center" justifyContent="center" gap={4}>
            <Grid item xs={12}>
              {isFetching ? (
                <ListCard<Number>>
                  {Array.from({ length: 6 }, (_, idx) => (
                    <Grid item xs={4} key={idx}>
                      <ProductCardSkeleton />
                    </Grid>
                  ))}
                </ListCard>
              ) : (
                <ListCard<Prod>>
                  {products.map((product: Prod, idx: number) => (
                    <Grid item xs={4} key={idx}>
                      <ProductCard product={product} />
                    </Grid>
                  ))}
                </ListCard>
              )}
            </Grid>
            {!isFetching && (
              <Grid item>
                <Stack spacing={2}>
                  <Pagination
                    onChange={(_, page) => {
                      setParams({ ...params, pageNumber: page });
                      setPage(page);
                    }}
                    count={totalPages}
                    color="secondary"
                    page={page}
                  />
                </Stack>
              </Grid>
            )}
          </Grid>
        </Grid>
      </Grid>
    </>
  );
};

export default Product;
