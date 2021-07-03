import React, { Component } from "react";
import { connect } from "react-redux";
import { Table } from "reactstrap";
import { Card } from "reactstrap";
import { withRouter } from "react-router-dom";
import { compose } from "redux";
import {
  getCampaignRequests,
  updateCampaignRequest,
} from "../../actions/actionsCampaign";
import moment from "moment";

class CampaignRequests extends Component {
  state = {
    showPostModal: false,
    showEditModal: false,
    itemToEdit: {},
  };

  async componentDidMount() {
    debugger;
    await this.props.getCampaignRequests();
  }

  render() {
    if (this.props.campaignRequests === undefined) {
      return null;
    }
    debugger;
    return (
      <div>
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
                      <th style={{ textAlign: "center" }}>Start Date</th>
                      <th style={{ textAlign: "center" }}>End Date</th>
                      <th style={{ textAlign: "center" }}></th>
                    </tr>
                  </thead>
                  <tbody>
                    {this.props.campaignRequests.map((f) => (
                      <tr>
                        <td style={{ textAlign: "center" }}>{f.campaign.id}</td>
                        <td style={{ textAlign: "center" }}>
                          {f.campaign.type}
                        </td>
                        <td style={{ textAlign: "center" }}>
                          {moment(f.campaign.startDate).format("DD/MM/YYYY")}
                        </td>
                        <td style={{ textAlign: "center" }}>
                          {moment(f.campaign.endDate).format("DD/MM/YYYY")}
                        </td>
                        <td style={{ textAlign: "center" }}>
                          <img
                            onClick={() => {
                              this.accept(f);
                            }}
                            src="/images/checked.png"
                          />
                        </td>
                        <td style={{ textAlign: "center" }}>
                          <img
                            onClick={() => {
                              this.reject(f);
                            }}
                            src="/images/cancel.png"
                          />
                        </td>
                        <td style={{ textAlign: "center" }}>
                          <img
                            onClick={() => {
                              this.view(f);
                            }}
                            src="/images/analytics.png"
                          />
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

  view(f) {
    window.location = "/items/" + f.id;
  }

  displayModalPost() {
    this.setState({
      showPostModal: !this.state.showPostModal,
    });
  }

  displayModalEdit() {
    this.setState({
      showEditModal: !this.state.showEditModal,
    });
  }
}

const mapStateToProps = (state) => ({
  campaignRequests: state.campaignRequests,
});

export default compose(
  withRouter,
  connect(mapStateToProps, { getCampaignRequests, updateCampaignRequest })
)(CampaignRequests);
