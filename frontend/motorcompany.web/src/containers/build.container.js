import { connect } from "react-redux";
import Build from "../components/build.component";
import onGetCustomer from "../actions/customer.action";
import {
  onBuildOrder,
  onOrderSubmitted,
  onClearErrors
} from "../actions/orders.action";

const mapToProp = state => ({
  state
});

const mapToDispatch = dispatch => ({
  onGetCustomer: filter => dispatch(onGetCustomer(filter)),
  onBuildOrder: (customerId, vehileId) =>
    dispatch(onBuildOrder(customerId, vehileId)),
  onOrderSubmitted: () => dispatch(onOrderSubmitted()),
  onClearErrors: () => dispatch(onClearErrors())
});

export default connect(mapToProp, mapToDispatch)(Build);
