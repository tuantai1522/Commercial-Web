import {
  Checkbox,
  FormControlLabel,
  FormGroup,
  FormLabel,
  Paper,
} from "@mui/material";
import { useReadCategory } from "../customHooks/useCategory/useReadCategory";
import Category from "../models/class/category";
import { useState } from "react";

interface Props {
  title: string;
  checked: string[];
  onChange: (event: any) => void;
}

const CheckBoxGroup = ({ title, checked, onChange }: Props) => {
  const [checkedItems, setCheckedItems] = useState(checked || []);

  const handleChecked = (value: string) => {
    const currentIndex = checkedItems.findIndex((item) => item === value);
    let newChecked: string[] = [];

    //chưa được chọn trước đó => thêm vào danh sách được chọn
    if (currentIndex === -1) newChecked = [...checkedItems, value];
    //đã chọn trước đó => bỏ chọn
    else newChecked = checkedItems.filter((i) => i !== value);

    setCheckedItems(newChecked);
    onChange(newChecked);
  };

  const { data }: any = useReadCategory();

  let categories: any = [];
  if (data && data.dt) {
    categories = data.dt;
  }

  return (
    <>
      <Paper sx={{ mb: 2, p: 2 }}>
        <FormLabel component="legend">{title}</FormLabel>

        <FormGroup>
          {categories.map((category: Category) => (
            <FormControlLabel
              key={category.id}
              value={category.id}
              control={
                <Checkbox
                  checked={checkedItems.indexOf(category.id) !== -1}
                  onClick={() => handleChecked(category.id)}
                />
              }
              label={category.name}
            />
          ))}
        </FormGroup>
      </Paper>
    </>
  );
};

export default CheckBoxGroup;
