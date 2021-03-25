import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import VehicleDetail from "./vehicle-detail.component";
import Wait from "./wait.component";
import SearchBar from "./searchbar.component";

const useStyles = makeStyles(theme => ({
  root: {
    display: "flex",
    flexDirection: "column",
    height: "100%",
    margin: theme.spacing(1)
  },
  catalog: {
    overflow: "auto",
    display: "flex",
    flexWrap: "wrap",
    justifyContent: "center"
  }
}));

const ProductsList = ({ state, onBuild }) => {
  const classes = useStyles();

  const itemList = state.vehicles.items.map(item => (
    <VehicleDetail onBuild={onBuild} item={item} key={item.id} />
  ));

  return <div className={classes.catalog}>{itemList}</div>;
};

const Vehicles = ({ state, onGetVehicles, onBuild }) => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <SearchBar label="Search Vehicle..." onGet={onGetVehicles} />
      {state.vehicles.isBusy ? (
        <Wait />
      ) : (
        <ProductsList onBuild={onBuild} state={state} />
      )}
    </div>
  );
};

export default Vehicles;
