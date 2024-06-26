import { TextField } from "@mui/material";

interface Props {
  title: string;
  textValue: string;
  onChange: (event: any) => void;
}
const SearcBox = ({ title, textValue, onChange }: Props) => {
  return (
    <>
      <TextField
        fullWidth
        label={title}
        onChange={onChange}
        value={textValue}
      />
    </>
  );
};

export default SearcBox;
