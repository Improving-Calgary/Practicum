import { connect } from "react-redux";
import Orders from "../components/orders.component";
import {
  onGetGivenOrder,
  onGetOrders,
  onGetNextOrder,
  onSetOrderState,
  onClearErrors
} from "../actions/orders.action";

const mapToProp = state => ({
  state
});

const mapToDispatch = dispatch => ({
  onGetGivenOrder: id => dispatch(onGetGivenOrder(id)),
  onGetOrders: state => dispatch(onGetOrders(state)),
  onGetNextOrder: () => dispatch(onGetNextOrder()),
  onSetOrderState: (id, state) => dispatch(onSetOrderState(id, state)),
  onClearErrors: () => dispatch(onClearErrors())
});

export default connect(mapToProp, mapToDispatch)(Orders);
