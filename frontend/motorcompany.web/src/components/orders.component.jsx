import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";
import Button from "@material-ui/core/Button";
import FormControl from "@material-ui/core/FormControl";
import Searchbar from "./searchbar.component";
import OrderDetail from "./order-detail.component";
import InfoDialog from "./info-dialog.component";
import { formatDate } from "../util/util";

const useStyles = makeStyles(theme => ({
  table: {
    minWidth: 650
  },
  filterSection: {
    margin: theme.spacing(1),
    display: "flex",
    flexDirection: "row"
  },
  stateSelector: {
    minWidth: 150
  }
}));

const OrdersFilter = ({
  state,
  onGetOrders,
  onGetGivenOrder,
  onGetNextOrder
}) => {
  const classes = useStyles();

  return (
    <div className={classes.filterSection}>
      <FormControl variant="filled" className={classes.stateSelector}>
        <Select
          value={
            state.orders.items && state.orders.items.length
              ? state.orders.items[0].state
              : -1
          }
          className={classes.selectEmpty}
          onChange={e => onGetOrders(e.target.value)}
        >
          <MenuItem value={-1} disabled>
            <em>Select State</em>
          </MenuItem>
          <MenuItem value={0}>New</MenuItem>
          <MenuItem value={1}>Started</MenuItem>
          <MenuItem value={2}>Completed</MenuItem>
          <MenuItem value={3}>Canceled</MenuItem>
          <MenuItem value={4}>Paused</MenuItem>
        </Select>
      </FormControl>
      <Searchbar label="Search Order (#)..." onGet={onGetGivenOrder} />
      <Button
        size="small"
        variant="outlined"
        color="primary"
        onClick={() => onGetNextOrder()}
      >
        Next Open Order
      </Button>
    </div>
  );
};

const OrdersTable = ({ state, handleOrderDetail }) => {
  const classes = useStyles();

  const Header = () => (
    <TableHead>
      <TableRow>
        <TableCell>Order #</TableCell>
        <TableCell align="right">Customer</TableCell>
        <TableCell align="right">Vehicle</TableCell>
        <TableCell align="right">Date</TableCell>
      </TableRow>
    </TableHead>
  );

  const Row = ({ item: order }) => (
    <TableRow hover onClick={() => handleOrderDetail(order)}>
      <TableCell>{order.id}</TableCell>
      <TableCell align="right">{`${order.customer.lastName}, ${order.customer.firstName}`}</TableCell>
      <TableCell align="right">{`${order.vehicle.make}-${order.vehicle.model}`}</TableCell>
      <TableCell align="right">{formatDate(order.date)}</TableCell>
    </TableRow>
  );

  return state.orders.items && state.orders.items.length > 0 ? (
    <TableContainer component={Paper}>
      <Table className={classes.table} size="small" stickyHeader>
        <Header />
        <TableBody>
          {state.orders.items.map(order => (
            <Row item={order} key={order.id} />
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  ) : null;
};

const Orders = ({
  state,
  onGetGivenOrder,
  onGetOrders,
  onGetNextOrder,
  onSetOrderState,
  onClearErrors
}) => {
  const [isDetail, setOpen] = React.useState(false);
  const [order, setOrder] = React.useState({});

  const handleOrderDetail = sOrder => {
    setOrder(sOrder);
    setOpen(true);
  };

  return (
    <div>
      <OrdersFilter
        state={state}
        onGetGivenOrder={onGetGivenOrder}
        onGetOrders={onGetOrders}
        onGetNextOrder={onGetNextOrder}
      />
      <OrdersTable state={state} handleOrderDetail={handleOrderDetail} />
      {isDetail ? (
        <OrderDetail
          state={state}
          order={order}
          setOpen={setOpen}
          onSetState={onSetOrderState}
        />
      ) : null}
      {state.orders.errors.length > 0 ? (
        <InfoDialog
          isOpen
          title="Sorry! ¯\_(ツ)_/¯"
          message={state.orders.errors[0].detail}
          onClose={() => onClearErrors()}
        />
      ) : null}
    </div>
  );
};

export default Orders;
