import React, { useEffect } from "react";
import { Route } from "react-router-dom";
import { makeStyles } from "@material-ui/core/styles";
import Vehicles from "../containers/vehicles.container";
import Build from "../containers/build.container";
import Orders from "../containers/orders.container";

const useStyles = makeStyles(() => ({
  containter: {
    display: "flex",
    height: "100%",
    flexDirection: "column",
    padding: 0
  }
}));

const Contents = ({ onGetVehicles }) => {
  const classes = useStyles();

  useEffect(() => {
    onGetVehicles("");
  });

  return (
    <div className={classes.containter}>
      <Route exact path="/" component={Vehicles} />
      <Route exact path="/Vehicles" component={Vehicles} />
      <Route exact path="/Orders" component={Orders} />
      <Route exact path="/Build" component={Build} />
    </div>
  );
};

export default Contents;
