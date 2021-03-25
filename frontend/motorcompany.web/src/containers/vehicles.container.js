import { connect } from "react-redux";
import Vehicles from "../components/vehicles.component";
import onGetVehicles from "../actions/vehicles.action";
import { onBuild } from "../actions/orders.action";

const mapToProp = state => ({
  state
});

const mapToDispatch = dispatch => ({
  onBuild: payload => dispatch(onBuild(payload)),
  onGetVehicles: filter => dispatch(onGetVehicles(filter))
});

export default connect(mapToProp, mapToDispatch)(Vehicles);
