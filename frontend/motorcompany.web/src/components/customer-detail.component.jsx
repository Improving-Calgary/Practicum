import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import TextField from "@material-ui/core/TextField";

const useStyles = makeStyles(theme => ({
  customerInfoDetail: {
    display: "flex",
    flexDirection: "column"
  },
  element: {
    margin: theme.spacing(1),
    marginLeft: "0.5em",
    marginRight: "0.5em"
  }
}));

const CustomerDetail = ({ customer }) => {
  const classes = useStyles();

  return (
    <div className={classes.customerInfoDetail}>
      <TextField
        className={classes.element}
        disabled
        label="First Name"
        defaultValue={customer.firstName}
        variant="outlined"
      />
      <TextField
        className={classes.element}
        disabled
        label="Last Name"
        defaultValue={customer.lastName}
        variant="outlined"
      />
      <TextField
        className={classes.element}
        disabled
        label="Address"
        defaultValue={customer.address}
        variant="outlined"
      />
      <TextField
        className={classes.element}
        disabled
        label="Phone"
        defaultValue={customer.phone}
        variant="outlined"
      />
    </div>
  );
};

export default CustomerDetail;
