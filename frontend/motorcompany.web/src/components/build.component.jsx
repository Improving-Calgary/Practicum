import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import { Redirect } from "react-router-dom";
import VehicleDetail from "./vehicle-detail.component";
import Searchbar from "./searchbar.component";
import InfoDialog from "./info-dialog.component";
import CustomerDetail from "./customer-detail.component";

const useStyles = makeStyles(theme => ({
  root: {
    display: "flex",
    flexDirection: "row"
  },
  customerInfoCard: {
    margin: theme.spacing(1),
    marginLeft: "0.5em",
    borderStyle: "solid",
    borderWidth: "thin",
    borderRadius: "5px",
    flexGrow: 1
  },
  element: {
    margin: theme.spacing(1),
    marginLeft: "0.5em",
    marginRight: "0.5em"
  },
  orderAction: {
    display: "flex",
    justifyContent: "center"
  }
}));

const Build = ({
  state,
  onGetCustomer,
  onBuildOrder,
  onOrderSubmitted,
  onClearErrors
}) => {
  const classes = useStyles();

  return state.orders.build.vehicle ? (
    <div className={classes.root}>
      <VehicleDetail item={state.orders.build.vehicle} />
      <div className={classes.customerInfoCard}>
        <Searchbar label="Search Customer..." onGet={onGetCustomer} />
        {state.orders.build.customer ? (
          <CustomerDetail
            customer={state.orders.build.customer}
            key={state.orders.build.customer.id}
          />
        ) : null}
        <div className={classes.orderAction}>
          <Button
            className={classes.element}
            variant="contained"
            color="primary"
            disabled={!state.orders.build.customer}
            onClick={() =>
              onBuildOrder(
                state.orders.build.customer,
                state.orders.build.vehicle
              )
            }
          >
            {" "}
            Submit Build Order
          </Button>
        </div>
      </div>
      {state.orders.build.isOrdered ? (
        <InfoDialog
          isOpen
          title="Order submitted!"
          message="You will be informed when vehicle is ready to be picked up."
          onClose={() => onOrderSubmitted()}
        />
      ) : null}
      {state.orders.errors.length > 0 ? (
        <InfoDialog
          isOpen
          title="Error submitting order!"
          message={state.orders.errors[0].detail}
          onClose={onClearErrors}
        />
      ) : null}
    </div>
  ) : (
    <Redirect to="/" />
  );
};

export default Build;
