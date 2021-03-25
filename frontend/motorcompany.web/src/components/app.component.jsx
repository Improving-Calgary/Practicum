import React from "react";
import { ThemeProvider } from "@material-ui/core/styles";
import { BrowserRouter as Router } from "react-router-dom";
import createMuiTheme from "@material-ui/core/styles/createMuiTheme";
import { Provider } from "react-redux";
import Contents from "../containers/contents.container";
import Header from "../containers/header.container";
import { store } from "../store";

const theme = createMuiTheme({
  palette: {
    primary: {
      light: "#4597D3",
      main: "#135596"
    }
  }
});

const App = () => (
  <Provider store={store}>
    <ThemeProvider theme={theme}>
      <Router on>
        <Header />
        <Contents />
      </Router>
    </ThemeProvider>
  </Provider>
);

export default App;
