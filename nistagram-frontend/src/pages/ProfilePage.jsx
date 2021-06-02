import React, { Component } from "react";
import MyProfile from "../components/Profile/MyProfile";
import PublicProfile from "../components/Profile/PublicProfile";
import Layout from "../layouts/Layout";

class ProfilePage extends Component {
  render() {
    return (
      <Layout>
        <PublicProfile />
      </Layout>
    );
  }
}

export default ProfilePage;
