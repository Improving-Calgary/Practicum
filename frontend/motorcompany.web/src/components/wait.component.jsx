import React from "react";
import CircularProgress from "@material-ui/core/CircularProgress";
import { makeStyles } from "@material-ui/core/styles";

const useStyles = makeStyles(() => ({
  parent: {
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",
    height: "100%"
  }
}));

const Wait = () => {
  const classes = useStyles();

  return (
    <div className={classes.parent}>
      <CircularProgress />
    </div>
  );
};

export default Wait;
