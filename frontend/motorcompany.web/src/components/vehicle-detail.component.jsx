import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardMedia from "@material-ui/core/CardMedia";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import BuildIcon from "@material-ui/icons/Build";
import { Link } from "react-router-dom";
import { formatCurrency } from "../util/util";

const useStyles = makeStyles(theme => ({
  root: {
    margin: theme.spacing(1),
    maxWidth: 345,
    borderStyle: "solid",
    borderWidth: "thin",
    alignContent: "space-around"
  },
  media: {
    width: "300px",
    paddingTop: "50%"
  },
  link: {
    color: "inherit"
  },
  cardHeader: {
    backgroundColor: theme.palette.primary.light
  },
  contents: {
    overflow: "hidden",
    resize: "vertical",
    height: "164px",
    textOverflow: "ellipsis",
    textAlign: "justify"
  },
  price: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    fontWeight: "bold"
  }
}));

const VehicleDetail = ({ onBuild, item }) => {
  const classes = useStyles();

  return (
    <Card className={classes.root}>
      <CardHeader
        className={classes.cardHeader}
        action={
          onBuild ? (
            <Link
              className={classes.link}
              to="/Build"
              onClick={() => onBuild(item)}
            >
              <BuildIcon />
            </Link>
          ) : null
        }
        title={`${item.make}-${item.model}`}
      />
      <CardMedia className={classes.media} image={item.img} />
      <CardContent>
        <Typography
          className={classes.contents}
          variant="body2"
          color="textSecondary"
          component="p"
        >
          {item.description}
        </Typography>
        <Typography className={classes.price}>
          Price: {formatCurrency(item.price)}
        </Typography>
      </CardContent>
    </Card>
  );
};

export default VehicleDetail;
