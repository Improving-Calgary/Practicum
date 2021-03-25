import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";
import Button from "@material-ui/core/Button";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import InputLabel from "@material-ui/core/InputLabel";
import FormControl from "@material-ui/core/FormControl";
import VehicleDetail from "./vehicle-detail.component";
import CustomerDetail from "./customer-detail.component";

const useStyles = makeStyles(theme => ({
  dialogContentRoot: {
    display: "flex",
    flexDirection: "row"
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 220,
    marginTop: "1em",
    marginLeft: "0.5em",
    marginRight: "0.5em"
  },
  detailSection: {
    displau: "flex",
    flexDirection: "column"
  }
}));

const DetailSection = ({ customer, orderState, onSetOrderState }) => {
  const classes = useStyles();

  return (
    <div className={classes.detailSection}>
      <CustomerDetail customer={customer} />
      <FormControl variant="outlined" className={classes.formControl}>
        <InputLabel>State </InputLabel>
        <Select
          value={orderState}
          onChange={e => {
            onSetOrderState(e.target.value);
          }}
          labelWidth={45}
        >
          <MenuItem value={0}>New</MenuItem>
          <MenuItem value={1}>Start</MenuItem>
          <MenuItem value={2}>Complete</MenuItem>
          <MenuItem value={3}>Cancel</MenuItem>
          <MenuItem value={4}>Pause</MenuItem>
        </Select>
      </FormControl>
    </div>
  );
};

const OrderDetail = ({ order, setOpen, onSetState }) => {
  const classes = useStyles();
  const [orderState, setOrderState] = React.useState(order.state);
  const saveCloseHandler = () => {
    onSetState(order.id, orderState);
    setOpen(false);
  };

  return (
    <div>
      <Dialog open aria-labelledby="form-dialog-title">
        <DialogTitle id="form-dialog-title">
          Order Detail (#
          {order.id})
        </DialogTitle>
        <DialogContent className={classes.dialogContentRoot}>
          <VehicleDetail item={order.vehicle} />
          <DetailSection
            customer={order.customer}
            orderState={orderState}
            onSetOrderState={setOrderState}
          />
        </DialogContent>
        <DialogActions>
          {orderState !== order.state ? (
            <Button
              onClick={() => {
                saveCloseHandler();
              }}
              color="primary"
            >
              Save & Close
            </Button>
          ) : (
            <Button onClick={() => setOpen(false)} color="primary">
              Close
            </Button>
          )}
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default OrderDetail;
