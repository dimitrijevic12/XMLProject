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
import SendVerificationRequestPage from "./pages/SendVerificationRequestPage";

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
          <ProtectedRoute exact path="/post" component={CreatePostPage} />
          <ProtectedRoute exact path="/story" component={CreateStoryPage} />
          <ProtectedRoute
            exact
            path="/private"
            component={PrivateProfilePage}
          />
          <ProtectedRoute
            exact
            path="/someone"
            component={SomeoneProfilePage}
          />
          <ProtectedRoute exact path="/privacy" component={PrivacyPage} />
          <ProtectedRoute exact path="/edit" component={EditProfilePage} />
          <ProtectedRoute
            exact
            path="/verification"
            component={VerificationRequestPage}
          />
          <ProtectedRoute
            exact
            path="/approval"
            component={ApprovalAgentPage}
          />
          <ProtectedRoute
            exact
            path="/create-item"
            component={CreateItemPage}
          />
          <ProtectedRoute
            exact
            path="/review-item"
            component={ReviewItemPage}
          />
          <ProtectedRoute
            exact
            path="/collections"
            component={CollectionsMenuPage}
          />
          <ProtectedRoute
            exact
            path="/requests"
            component={FollowRequestPage}
          />
          <ProtectedRoute
            exact
            path="/sendVerificationRequest"
            component={SendVerificationRequestPage}
          />
          <Route exact path="/change-profile-picture">
            <ChangeProfilePicturePage />
          </Route>
          <Route path="/explore/:search">
            <Explore />
          </Route>
          <Route path="/profile/:username" component={ProfilePage}></Route>
          <ProtectedRoute
            path="/collection/:collectionId"
            component={PostsInCollectionPage}
          />
          <ProtectedRoute exact path="/" component={HomePage} />
        </Switch>
      </div>
    </Router>
  );
}

export default App;
