import React from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import ItemsTablePage from "./pages/ItemsTablePage";
import CreateItemPage from "./pages/CreateItemPage";
import ReviewItemPage from "./pages/ReviewItemPage";
import EditItemPage from "./pages/EditItemPage";

function App() {
  return (
    <Router>
      <div>
        <Switch>
          <Route exact path="/">
            <ItemsTablePage />
          </Route>
          <Route exact path="/create">
            <CreateItemPage />
          </Route>
          <Route path="/items/:itemId" component={ReviewItemPage} />
          <Route path="/edit-item" component={EditItemPage} />
        </Switch>
      </div>
    </Router>
  );
}

export default App;
