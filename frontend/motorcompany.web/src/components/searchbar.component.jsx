import React from "react";
import { fade, makeStyles } from "@material-ui/core/styles";
import SearchIcon from "@material-ui/icons/Search";
import InputBase from "@material-ui/core/InputBase";

const useStyles = makeStyles(theme => ({
  search: {
    position: "relative",
    borderRadius: theme.shape.borderRadius,
    backgroundColor: fade(theme.palette.common.black, 0.15),
    "&:hover": {
      backgroundColor: fade(theme.palette.common.black, 0.25)
    },
    width: "100%"
  },
  searchIcon: {
    width: theme.spacing(7),
    height: "100%",
    position: "absolute",
    display: "flex",
    alignItems: "center",
    justifyContent: "center"
  },
  inputInput: {
    padding: theme.spacing(1, 1, 1, 7),
    width: "100%"
  }
}));

const SearchBar = ({ label, onGet }) => {
  const classes = useStyles();

  return (
    <div className={classes.search}>
      <div className={classes.searchIcon}>
        <SearchIcon />
      </div>
      <InputBase
        className={classes.inputInput}
        placeholder={label}
        inputProps={{ "aria-label": "search" }}
        onKeyDown={e => {
          if (e.keyCode === 13) {
            const filter = e.target.value;
            e.target.value = "";
            onGet(filter);
          }
        }}
      />
    </div>
  );
};

export default SearchBar;
