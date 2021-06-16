import React, { Component } from "react";
import { connect } from "react-redux";
import { compose } from "redux";
import { withRouter } from "react-router-dom";
import { Table } from "reactstrap";
import { Card } from "reactstrap";
import {
  getFollowing,
  getFollowingWithoutMuted,
} from "../../actions/actionsUser";
import {
  getNotificationsForFollowing,
  getUserNotificationSettings,
} from "../../actions/actionsNotification";

class Notifications extends Component {
  state = {};
  async componentDidMount() {
    debugger;
    await this.props.getFollowingWithoutMuted();
    await this.props.getUserNotificationSettings();
    await this.props.getNotificationsForFollowing({
      LoggedUser: this.props.userNotificationSettings,
      RegisteredUsers: this.props.following,
    });
  }
  render() {
    if (this.props.following === undefined) {
      return null;
    }

    if (this.props.userNotificationSettings === undefined) {
      return null;
    }

    if (this.props.notificationsForFollowing === undefined) {
      return null;
    }

    return (
      <div>
        <div className="wrap bg-white pt-3 pb-3" style={{ height: "100vh" }}>
          <div style={{ marginTop: "40px" }} id="appointmentTable">
            <h2>Notifications</h2>

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
                    <th style={{ textAlign: "center" }}>Activity</th>
                  </tr>
                </thead>
                <tbody>
                  {this.props.notificationsForFollowing.map((f) => (
                    <tr>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        {f.registeredUser.username + " "}
                        {f.type === "Post"
                          ? "created new Post!"
                          : f.type === "Story"
                          ? "created new Story!"
                          : f.type === "Comment"
                          ? "has commented on post!"
                          : ""}
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
}

const mapStateToProps = (state) => ({
  following: state.following,
  userNotificationSettings: state.userNotificationSettings,
  notificationsForFollowing: state.notificationsForFollowing,
});

export default compose(
  withRouter,
  connect(mapStateToProps, {
    getFollowingWithoutMuted,
    getFollowing,
    getUserNotificationSettings,
    getNotificationsForFollowing,
  })
)(Notifications);
