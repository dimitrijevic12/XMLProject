import React from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import ProfilePage from "./pages/ProfilePage";
import PrivateProfilePage from "./pages/PrivateProfilePage";
import SomeoneProfilePage from "./pages/SomeoneProfilePage";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import CreatePostPage from "./pages/CreatePostPage";
import EditProfilePage from "./pages/EditProfilePage";
import VerificationRequestPage from "./pages/VerificationRequestPage";
import PrivacyPage from "./pages/PrivacyPage";
import RegistrationPage from "./pages/RegistrationPage";
import ApprovalAgentPage from "./pages/ApprovalAgentPage";
import CreateItemPage from "./pages/CreateItemPage";
import ReviewItemPage from "./pages/ReviewItemPage";
import Explore from "./pages/Explore";
import ProtectedRoute from "./routes/ProtectedRoute";
import PublicProfile from "./components/Profile/PublicProfile";
import CollectionsMenuPage from "./pages/CollectionsMenuPage";
import PostsInCollectionPage from "./pages/PostsInCollectionPage";
import FollowRequestPage from "./pages/FollowRequestsPage";
import CreateStoryPage from "./pages/CreateStoryPage";
import ChangeProfilePicturePage from "./pages/ChangeProfilePicturePage";

function App() {
  return (
    <Router>
      <div>
        <Switch>
          <Route exact path="/registration">
            <RegistrationPage />
          </Route>
          <Route exact path="/login">
            <LoginPage />
          </Route>
          <Route exact path="/post">
            <CreatePostPage />
          </Route>
          <Route exact path="/story">
            <CreateStoryPage />
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
          <Route exact path="/approval">
            <ApprovalAgentPage />
          </Route>
          <Route exact path="/create-item">
            <CreateItemPage />
          </Route>
          <Route exact path="/review-item">
            <ReviewItemPage />
          </Route>
          <Route exact path="/collections">
            <CollectionsMenuPage />
          </Route>
          <Route exact path="/requests">
            <FollowRequestPage />
          </Route>
          <Route exact path="/change-profile-picture">
            <ChangeProfilePicturePage />
          </Route>
          <Route path="/explore/:search">
            <Explore />
          </Route>
          <Route path="/profile/:username" component={ProfilePage}></Route>
          <Route
            path="/collection/:collectionId"
            component={PostsInCollectionPage}
          ></Route>
          <ProtectedRoute exact path="/" component={HomePage} />
        </Switch>
      </div>
    </Router>
  );
}

export default App;
