import React, { Component } from "react";
import AsyncSelect from "react-select/async";
import {
  getHashTagsByText,
  getLocationsByText,
  getUsersByName,
} from "../../actions/actions";
import { connect } from "react-redux";
import { compose } from "redux";
import { withRouter } from "react-router-dom";

class SearchBar extends Component {
  state = { inputValue: "", type: "" };
  render() {
    return (
      <AsyncSelect
        cacheOptions
        loadOptions={this.loadOptions}
        defaultOptions
        onInputChange={this.handleInputChange}
        onChange={this.search}
        defaultValue={""}
        placeholder="Search"
      />
    );
  }

  search = (value) => {
    debugger;
    if (value.type !== "user") {
      this.props.history.replace({
        pathname: "/explore" + value.label,
        state: {
          searchObject: value,
        },
      });
    } else {
      this.props.history.replace({
        pathname: "/profile/" + value.label,
        state: {
          searchObject: value,
        },
      });
    }
  };

  handleInputChange = (newValue) => {
    debugger;
    const inputValue = newValue.replace(/\W/g, "");
    this.setState({ inputValue });
    return inputValue;
  };

  loadOptions = async (inputValue, callback) => {
    debugger;
    await this.props.getHashTagsByText(inputValue);
    var valueList = [];
    this.props.hashtags.forEach((element) => {
      valueList.push({
        value: element.hashTagText,
        label: element.hashTagText,
        type: "hashtag",
      });
    });
    await this.props.getLocationsByText(inputValue);
    this.props.locations.forEach((element) => {
      valueList.push({
        value: element,
        label: this.createLocationLabel(element),
        type: "location",
      });
    });
    debugger;
    await this.props.getUsersByName(inputValue);
    this.props.users.forEach((element) => {
      valueList.push({
        value: element,
        label: element.username,
        type: "user",
      });
    });
    callback(this.filterOptions(valueList));
  };

  filterOptions = (valueList) => {
    debugger;
    return valueList;
  };

  createLocationLabel(element) {
    debugger;
    if (element.street !== "") return element.street + ", " + element.cityName;
    if (element.cityName !== "")
      return element.cityName + ", " + element.country;
    else return element.country;
  }
}

const mapStateToProps = (state) => ({
  hashtags: state.hashtags,
  locations: state.locations,
  users: state.users,
});

export default compose(
  withRouter,
  connect(mapStateToProps, {
    getHashTagsByText,
    getLocationsByText,
    getUsersByName,
  })
)(SearchBar);
