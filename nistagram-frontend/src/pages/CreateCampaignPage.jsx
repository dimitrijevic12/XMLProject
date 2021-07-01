import React, { Component } from "react";
import CreateCampaign from "../components/Campaign/CreateCampaign";
import CreatePost from "../components/Post/CreatePost";
import Layout from "../layouts/Layout";

class CreateCampaignPage extends Component {
  render() {
    return (
      <Layout>
        <CreateCampaign />
      </Layout>
    );
  }
}

export default CreateCampaignPage;
