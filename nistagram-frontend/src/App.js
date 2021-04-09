import React from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import ProfilePage from "./pages/ProfilePage";
import PrivateProfilePage from "./pages/PrivateProfilePage";
import SomeoneProfilePage from "./pages/SomeoneProfilePage";
import HomePage from "./pages/HomePage";

function App() {
  return (
    <Router>
      <div>
        <Switch>
          <Route path="/:username">
            <ProfilePage />
          </Route>
          <Route path="/private">
            <PrivateProfilePage />
          </Route>
          <Route exact path="/someone">
            <SomeoneProfilePage />
          </Route>
          <Route path="/">
            <HomePage />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
