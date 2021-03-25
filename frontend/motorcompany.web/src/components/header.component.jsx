import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemText from "@material-ui/core/ListItemText";
import { Link } from "react-router-dom";

const useStyles = makeStyles(theme => ({
  menuBackground: {
    backgroundColor: theme.palette.primary.main
  },
  logo: {
    maxWidth: 160,
    filter: "invert(100%)"
  },
  list: {
    display: "flex",
    flexDirection: "row",
    right: "1em"
  },
  link: {
    color: "#fff",
    textTransform: "uppercase"
  }
}));

const Header = ({ onGetVehicles }) => {
  const classes = useStyles();

  function ListItemLink(props) {
    return <ListItem button component={Link} {...props} />;
  }

  return (
    <div>
      <AppBar position="static" className={classes.menuBackground}>
        <Toolbar variant="dense">
          <ListItemLink to="/">
            <img
              src="img/improvingText.png"
              alt="logo"
              className={classes.logo}
            />
          </ListItemLink>

          <List className={classes.list}>
            <ListItemLink
              className={classes.link}
              to="/Vehicles"
              onClick={() => onGetVehicles("")}
            >
              <ListItemText primary="Vehicles" />
            </ListItemLink>
            <ListItemLink className={classes.link} to="/Orders">
              <ListItemText primary="Orders" />
            </ListItemLink>
          </List>
        </Toolbar>
      </AppBar>
    </div>
  );
};

export default Header;
