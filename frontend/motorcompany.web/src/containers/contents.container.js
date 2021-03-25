import { connect } from "react-redux";
import Contents from "../components/contents.component";
import onGetVehicles from "../actions/vehicles.action";

const mapToDispatch = dispatch => ({
  onGetVehicles: filter => dispatch(onGetVehicles(filter))
});

export default connect(null, mapToDispatch)(Contents);
