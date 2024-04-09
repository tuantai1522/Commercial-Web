import { Grid } from "@mui/material";
import { ReactElement } from "react";

interface Props<T> {
  children?: ReactElement<{ item: T }> | ReactElement<{ item: T }>[];
}

const ListCard = <T,>({ children }: Props<T>) => {
  return (
    <Grid container spacing={4}>
      {children}
    </Grid>
  );
};

export default ListCard;
