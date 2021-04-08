import React, { Component } from "react";
import Profiles from "../components/Profiles";
import Layout from "../layouts/Layout";

class ProfilePage extends Component {
  render() {
    return (
      <Layout>
        <Profiles />
      </Layout>
    );
  }
}

export default ProfilePage;
