import React, { Component } from "react";
import { connect } from "react-redux";
import { Table } from "reactstrap";
import { Card } from "reactstrap";
import { withRouter } from "react-router-dom";
import { compose } from "redux";
import {
    getCampaignsForAgent,
} from "../../actions/actionsCampaign";
import moment from "moment";
import NotLoggedPostModal from "../Profile/NotLoggedPostModal";
import StoryAlbumReportModal from "../Report/StoryAlbumReportModal";
import { savePost, getPost } from "../../actions/actions";
import { createNotification } from "../../actions/actionsNotification";
import {
  getStoryById,
  saveStory,
  getUserForStory,
} from "../../actions/actionsStory";

class EditCampaign extends Component {
  state = {
    showPostModal: false,
    showStoryModal: false,
    postId: "",
    storyId: "",
    storyIds: [],
    username: "",
    storyOwner: {},
  };

  async componentDidMount() {
    debugger;
    await this.props.getCampaignsForAgent();
    //await this.props.getUserForStory();
    this.setState({
      storyOwner: this.props.storyOwner,
    });
  }

  render() {
    if (this.props.campaignsForAgent === undefined) {
      return null;
    }
    debugger;
    return (
      <div>
        {this.state.showPostModal ? (
          <NotLoggedPostModal
            show={this.state.showPostModal}
            postId={this.state.postId}
            personPhoto="/images/download.jfif"
            person={this.state.username}
            onShowChange={() => this.displayModalPost()}
          />
        ) : null}
        {this.state.showStoryModal ? (
          <StoryAlbumReportModal
            show={this.state.showStoryModal}
            storyIds={this.state.storyIds}
            onShowChange={() => this.displayModalStory()}
          />
        ) : null}
        <h3 className="mt-4" style={{ textAlign: "center" }}>
          Campaign Requests
        </h3>
        <hr />
        <div className="wrap bg-white pt-3">
          <div style={{ marginTop: "40px" }} id="appointmentTable">
            <Card
              className="mt-5"
              style={{
                shadowColor: "gray",
                boxShadow: "0 8px 6px -6px #999",
              }}
            >
              <div
                style={{
                  maxHeight: "440px",
                  overflowY: "auto",
                }}
              >
                <Table className="table allPrescriptions mb-0" striped>
                  <thead>
                    <tr>
                      <th style={{ textAlign: "center" }}>Campaign</th>
                      <th style={{ textAlign: "center" }}>Type</th>
                      <th style={{ textAlign: "center" }}>Gender</th>
                      <th style={{ textAlign: "center" }}>Min Age</th>
                      <th style={{ textAlign: "center" }}>Max Age</th>
                      <th style={{ textAlign: "center" }}></th>
                    </tr>
                  </thead>
                  <tbody>
                    {this.props.campaignsForAgent.map((f) => (
                      <tr>
                        <td style={{ textAlign: "center" }}>{f.id}</td>
                        <td style={{ textAlign: "center" }}>
                        {f.type}
                        </td>
                        <td style={{ textAlign: "center" }}>
                          {f.targetAudience.gender}
                        </td>
                        <td style={{ textAlign: "center" }}>
                          {moment(f.targetAudience.minDateOfBirth).format("DD/MM/YYYY")}
                        </td>
                        <td style={{ textAlign: "center" }}>
                          {moment(f.targetAudience.maxDateOfBirth).format("DD/MM/YYYY")}
                        </td>
                        <td style={{ textAlign: "center" }}>
                        <button
                                
                                className="btn btn-primary"
                                // onClick={() => {
                                // this.addPostToCollection();
                                // }}
                                >
                                Edit
                        </button>
                        </td>
                        
                      </tr>
                    ))}
                  </tbody>
                </Table>
              </div>
            </Card>
          </div>
        </div>
      </div>
    );
  }

  async accept(f) {
    await this.props.updateCampaignRequest({
      Id: f.id,
      IsApproved: true,
      Campaign: f.campaign,
      VerifiedUser: f.verifiedUser,
      CampaignRequestAction: "accepted",
    });
    if (
      f.campaign.type === "OneTimePostCampaign" ||
      f.campaign.type === "RecurringPostCampaign"
    ) {
      await this.createPost(f.campaign.ads[0]);
    } else {
      for (var j = 0; j < f.campaign.ads.length; j++) {
        await this.createStory(f.campaign.ads[j]);
      }
    }
  }

  async createPost(ad) {
    await this.props.getPost(ad.contentId);
    debugger;
    var contentPaths = [];
    if (this.props.post.contentPaths === undefined) {
      contentPaths.push(this.props.post.contentPath);
    } else {
      contentPaths = this.props.post.contentPaths;
    }

    await this.props.savePost({
      Description: this.props.post.description,
      RegisteredUser: { id: sessionStorage.getItem("userId") },
      Location: this.props.post.location,
      ContentPaths: contentPaths,
      HashTags: this.props.post.hashTags,
      Taggedusers: this.props.post.taggedUsers,
    });
    await this.props.createNotification({
      Type: "Post",
      ContentId: this.props.post.id,
      RegisteredUser: { id: sessionStorage.getItem("userId") },
    });
  }

  async createStory(ad) {
    await this.props.getStoryById(ad.contentId);
    debugger;

    debugger;
    this.props.saveStory({
      Description: this.props.storyById.description,
      RegisteredUser: this.state.storyOwner,
      Location: this.props.storyById.location,
      ContentPath: this.props.storyById.contentPath,
      HashTags: this.props.storyById.hashTags,
      TaggedUsers: this.props.storyById.taggedUsers,
      SeenByUsers: [],
      Duration: this.props.storyById.duration,
      Type: "Story",
      IsBanned: false,
    });

    await this.props.createNotification({
      Type: "Story",
      ContentId: "12345678-1234-1234-1234-123456789123",
      RegisteredUser: { id: sessionStorage.getItem("userId") },
    });
  }

  async reject(f) {
    await this.props.updateCampaignRequest({
      Id: f.id,
      IsApproved: false,
      Campaign: f.campaign,
      VerifiedUser: f.verifiedUser,
      CampaignRequestAction: "rejected",
    });
  }

  view = (f) => {
    debugger;
    if (f != undefined) {
      if (
        f.campaign.type === "OneTimePostCampaign" ||
        f.campaign.type === "RecurringPostCampaign"
      ) {
        this.displayModalPost(f);
      } else {
        this.displayModalStory(f);
      }
    }
  };

  displayModalPost = (f) => {
    if (f != undefined) {
      this.setState({
        postId: f.campaign.ads[0].contentId,
        username: f.campaign.agent.username,
      });
    }
    this.setState({
      showPostModal: !this.state.showPostModal,
    });
  };

  displayModalStory = (f) => {
    var storyIds = [];
    if (f != undefined) {
      for (var i = 0; i < f.campaign.ads.length; i++) {
        storyIds.push(f.campaign.ads[i].contentId);
      }
      this.setState({
        storyIds: storyIds,
      });
    }
    this.setState({
      showStoryModal: !this.state.showStoryModal,
    });
  };
}

const mapStateToProps = (state) => ({
  campaignsForAgent: state.campaignsForAgent,
  post: state.post,
  storyById: state.storyById,
  story: state.story,
  storyOwner: state.registeredUser,
});

export default compose(
  withRouter,
  connect(mapStateToProps, {
    getCampaignsForAgent,
    savePost,
    createNotification,
    getPost,
    saveStory,
    getStoryById,
    getUserForStory,
  })
)(EditCampaign);
