import React from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import ItemsTablePage from "./pages/ItemsTablePage";

function App() {
  return (
    <Router>
      <div>
        <Switch>
          <Route exact path="/">
            <ItemsTablePage />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
