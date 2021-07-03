import React, { Component } from "react";
import {
  savePost,
  getLocationsByText,
  getTaggableUsers,
} from "../../actions/actions";
import { connect } from "react-redux";
import axios from "axios";
import { withRouter } from "react-router-dom";
import { compose } from "redux";
import { createNotification } from "../../actions/actionsNotification";
import Stepper from "react-stepper-horizontal";
import SelectCampaignType from "./SelectCampaignType";
import SelectTargetAudience from "./SelectTargetAudience";
import SelectOneTimeExposureDate from "./SelectOneTimeExposureDate";
import SelectRecurringExposureDate from "./SelectRecurringExposureDate";
import CreatePostCampaign from "./CreatePostCampaign";

class CreatePost extends Component {
  state = {
    activeStep: 0,
    recurrence: "",
    type: "",
    minDateOfBirth: "",
    maxDateOfBirth: "",
    gender: "",
    exposureDates: [],
  };

  render() {
    debugger;
    return (
      <React.Fragment>
        <div className="mt-5">
          <Stepper
            steps={[
              { title: "Select Campaign Type" },
              { title: "Select Exposure Date" },
              { title: "Select Target Audience" },
              { title: "Step Four" },
            ]}
            activeStep={this.state.activeStep}
          />
          {this.state.activeStep === 0 ? (
            <SelectCampaignType
              recurrence={this.state.recurrence}
              type={this.state.type}
              handleChange={this.handleChange.bind(this)}
              changeStep={this.changeStep.bind(this)}
            />
          ) : null}
          {this.state.activeStep === 1 &&
          this.state.recurrence === "oneTimeCampaign" ? (
            <SelectOneTimeExposureDate
              addExposureDates={this.addExposureDates.bind(this)}
              changeStep={this.changeStep.bind(this)}
            />
          ) : null}
          {this.state.activeStep === 1 &&
          this.state.recurrence === "recurringCampaign" ? (
            <SelectRecurringExposureDate
              addExposureDates={this.addExposureDates.bind(this)}
              changeStep={this.changeStep.bind(this)}
            />
          ) : null}
          {this.state.activeStep === 2 ? (
            <SelectTargetAudience
              minDateOfBirth={this.state.minDateOfBirth}
              maxDateOfBirth={this.state.maxDateOfBirth}
              gender={this.state.gender}
              handleChange={this.handleChange.bind(this)}
              handleChangeMinDate={this.handleChangeMinDate.bind(this)}
              handleChangeMaxDate={this.handleChangeMaxDate.bind(this)}
              changeStep={this.changeStep.bind(this)}
            />
          ) : null}
          {this.state.activeStep === 3 && this.state.type === "post" ? (
            <CreatePostCampaign
              minDateOfBirth={this.state.minDateOfBirth}
              maxDateOfBirth={this.state.maxDateOfBirth}
              gender={this.state.gender}
              handleChange={this.handleChange.bind(this)}
              handleChangeMinDate={this.handleChangeMinDate.bind(this)}
              handleChangeMaxDate={this.handleChangeMaxDate.bind(this)}
              changeStep={this.changeStep.bind(this)}
            />
          ) : null}
        </div>
      </React.Fragment>
    );
  }

  addExposureDates(dates) {
    this.setState({ exposureDates: this.state.exposureDates.concat(dates) });
  }

  changeStep(step) {
    this.setState({ activeStep: step });
    console.log(this.state);
  }

  handleChange = (event) => {
    debugger;
    const { name, value, type, checked } = event.target;
    type === "checkbox"
      ? this.setState({
          [name]: checked,
        })
      : this.setState({
          [name]: value,
        });
  };

  handleChangeMinDate = (e) => {
    debugger;
    this.setState({
      minDateOfBirth: e,
    });
  };

  handleChangeMaxDate = (e) => {
    debugger;
    this.setState({
      maxDateOfBirth: e,
    });
  };
}

const mapStateToProps = (state) => ({
  locations: state.locations,
  taggableUsers: state.taggableUsers,
  post: state.post,
});

export default compose(
  withRouter,
  connect(mapStateToProps, {
    savePost,
    getLocationsByText,
    getTaggableUsers,
    createNotification,
  })
)(CreatePost);
