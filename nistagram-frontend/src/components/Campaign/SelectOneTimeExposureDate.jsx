import React, { Component } from "react";
import DateTimePicker from "react-datetime-picker";

class SelectOneTimeExposureDate extends Component {
  state = { exposureDate: "" };
  render() {
    return (
      <div className="mt-5">
        <div className="form-group w-75" style={{ paddingLeft: 300 }}>
          <label className="label">Select exposure date and time:</label>
          <div className="w-100">
            <DateTimePicker
              value={this.state.exposureDate}
              format="dd/MM/yyyy HH:mm"
              minDate={new Date()}
              onChange={this.handleChangeExposureDate}
            />
          </div>
        </div>
        <div
          className="pb-5"
          style={{
            width: "150px",
            position: "fixed",
            bottom: 0,
            right: 250,
          }}
        >
          <button
            disabled={
              this.state.minDateOfBirth === "" ||
              this.state.maxDateOfBirth === "" ||
              this.state.gender === ""
            }
            onClick={() => this.changeStep()}
            className="btn btn-primary btn-lg"
          >
            Next
          </button>
        </div>
      </div>
    );
  }

  changeStep() {
    this.props.addExposureDates(this.state.exposureDate);
    this.props.changeStep(2);
  }

  handleChangeExposureDate = (e) => {
    debugger;
    this.setState({
      exposureDate: e,
    });
  };
}

export default SelectOneTimeExposureDate;
