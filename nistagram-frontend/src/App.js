import React from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import ProfilePage from "./pages/ProfilePage";
import PrivateProfilePage from "./pages/PrivateProfilePage";
import SomeoneProfilePage from "./pages/SomeoneProfilePage";
import HomePage from "./pages/HomePage";
import CreatePostPage from "./pages/CreatePostPage";
import EditProfilePage from "./pages/EditProfilePage";
import VerificationRequestPage from "./pages/VerificationRequestPage";
import PrivacyPage from "./pages/PrivacyPage";

function App() {
  return (
    <Router>
      <div>
        <Switch>
          <Route exact path="/post">
            <CreatePostPage />
          </Route>
          <Route exact path="/private">
            <PrivateProfilePage />
          </Route>
          <Route exact path="/someone">
            <SomeoneProfilePage />
          </Route>
          <Route exact path="/privacy">
            <PrivacyPage />
          </Route>
          <Route exact path="/edit">
            <EditProfilePage />
          </Route>
          <Route exact path="/verification">
            <VerificationRequestPage />
          </Route>
          <Route path="/:username">
            <ProfilePage />
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
