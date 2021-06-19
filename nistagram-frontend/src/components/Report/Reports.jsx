import React, { Component } from "react";
import { getReports } from "../../actions/actionsReport";
import { connect } from "react-redux";
import { Table } from "reactstrap";
import { Card } from "reactstrap";
import { withRouter } from "react-router-dom";
import { compose } from "redux";
import PostModal from "../Profile/PostModal";
import StoryReportModal from "./StoryReportModal";
import moment from "moment";

class Reports extends Component {
  state = {
    showPostModal: false,
    showStoryModal: false,
    postId: "",
    storyId: "",
    username: "",
  };

  componentDidMount() {
    debugger;
    this.props.getReports();
  }

  render() {
    debugger;
    if (this.props.reports === undefined) {
      return null;
    }
    const reports = this.props.reports;
    debugger;
    return (
      <div>
        {this.state.showPostModal ? (
          <PostModal
            show={this.state.showPostModal}
            postId={this.state.postId}
            personPhoto="/images/download.jfif"
            person={this.state.username}
            onShowChange={() => this.displayModalPost()}
          />
        ) : null}
        {this.state.showStoryModal ? (
          <StoryReportModal
            show={this.state.showStoryModal}
            storyId={this.state.storyId}
            onShowChange={() => this.displayModalStory()}
          />
        ) : null}
        <div className="wrap bg-white pt-3 pb-3" style={{ height: "100vh" }}>
          <div style={{ marginTop: "40px" }} id="appointmentTable">
            <Card
              className="mt-5"
              style={{
                shadowColor: "gray",
                boxShadow: "0 8px 6px -6px #999",
              }}
            >
              <Table className="table allPrescriptions mb-0" striped>
                <thead>
                  <tr>
                    <th style={{ textAlign: "center" }}>Time Stamp</th>
                    <th style={{ textAlign: "center" }}>Report Reason</th>
                    <th style={{ textAlign: "center" }}>Registered User</th>
                    <th style={{ textAlign: "center" }}>View</th>
                    <th style={{ textAlign: "center" }}>Remove Content</th>
                    <th style={{ textAlign: "center" }}>Remove User</th>
                  </tr>
                </thead>
                <tbody>
                  {reports.map((f) => (
                    <tr>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        {moment(f.timeStamp).format("DD/MM/YYYY HH:mm")}
                      </td>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        {f.reportReason}
                      </td>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        {f.registeredUser.username}
                      </td>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        <button
                          className="btn btn-primary mb-2"
                          onClick={() => {
                            this.view(f);
                          }}
                        >
                          View
                        </button>
                      </td>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        <button
                          className="btn btn-primary mb-2"
                          onClick={() => {
                            this.removeContent(f);
                          }}
                        >
                          Remove
                        </button>
                      </td>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        <button
                          className="btn btn-primary mb-2"
                          onClick={() => {
                            this.removeUser(f);
                          }}
                        >
                          Remove
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </Table>
            </Card>
          </div>
        </div>
      </div>
    );
  }

  view = (f) => {
    if (f != undefined) {
      if (f.type === "Post" || f.type === "post") {
        this.displayModalPost(f);
      } else {
        this.displayModalStory(f);
      }
    }
  };

  displayModalPost = (f) => {
    if (f != undefined) {
      this.setState({
        postId: f.content.id,
        username: f.registeredUser.username,
      });
    }
    this.setState({
      showPostModal: !this.state.showPostModal,
    });
  };

  displayModalStory = (f) => {
    if (f != undefined) {
      this.setState({
        storyId: f.content.id,
      });
    }
    this.setState({
      showStoryModal: !this.state.showStoryModal,
    });
  };

  async removeUser(f) {}

  async removeContent(f) {}
}

const mapStateToProps = (state) => ({ reports: state.reports });

export default compose(
  withRouter,
  connect(mapStateToProps, {
    getReports,
  })
)(Reports);
