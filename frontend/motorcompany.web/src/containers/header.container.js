import { connect } from "react-redux";
import Header from "../components/header.component";
import onGetVehicles from "../actions/vehicles.action";

const mapToDispatch = dispatch => ({
  onGetVehicles: filter => dispatch(onGetVehicles(filter))
});

export default connect(null, mapToDispatch)(Header);
