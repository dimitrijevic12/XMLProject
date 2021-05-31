import React, { Component } from "react";
import AsyncSelect from "react-select/async";
import { getHashTagsByText } from "../../actions/actions";
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
        onChange={this.test}
        isClearable
        placeholder="Search"
      />
    );
  }

  test = (value) => {
    debugger;
    this.props.history.push({
      pathname: "/explore",
      state: {
        searchObject: value,
      },
    });
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
    debugger;
    var valueList = [];
    this.props.hashtags.forEach((element) => {
      valueList.push({
        value: element.hashTagText,
        label: element.hashTagText,
        type: "hashtag",
      });
    });
    callback(this.filterOptions(valueList));
  };

  filterOptions = (valueList) => {
    debugger;
    return valueList;
  };
}

const mapStateToProps = (state) => ({ hashtags: state.hashtags });

export default compose(
  withRouter,
  connect(mapStateToProps, { getHashTagsByText })
)(SearchBar);
