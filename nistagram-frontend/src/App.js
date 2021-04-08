import React from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import ProfilePage from "./pages/ProfilePage";

function App() {
  return (
    <Router>
      <div>
        <Switch>
          <Route path="/">
            <ProfilePage />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
