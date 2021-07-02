import React, { Component } from "react";
import TimePicker from "react-time-picker";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import "../../css/datepicker.css";
import { intersection } from "lodash";

class SelectRecurringExposureDate extends Component {
  state = {
    exposureTimes: [""],
    maxExposureDates: 5,
    startDate: "",
    endDate: "",
    validTimes: false,
  };
  render() {
    debugger;
    return (
      <div className="mt-5">
        <div className="form-group w-75" style={{ paddingLeft: 300 }}>
          <label className="label">Select start date:</label>
          <DatePicker
            className="form-control w-100"
            id="startDate"
            name="startDate"
            dateFormat="dd/MM/yyyy"
            selected={this.state.startDate}
            minDate={new Date()}
            maxDate={this.state.endDate === "" ? null : this.state.endDate}
            onChange={(e) => this.handleChangeStartDate(e)}
          />
        </div>
        <div className="form-group w-75" style={{ paddingLeft: 300 }}>
          <label className="label">Select end date:</label>
          <DatePicker
            className="form-control w-100"
            id="endDate"
            name="endDate"
            dateFormat="dd/MM/yyyy"
            selected={this.state.endDate}
            minDate={
              this.state.startDate === "" ? new Date() : this.state.startDate
            }
            onChange={(e) => this.handleChangeEndDate(e)}
          />
        </div>
        {this.state.exposureTimes.map((date, i) => {
          return (
            <div className="form-group w-75" style={{ paddingLeft: 300 }}>
              <label className="label">Select exposure date:</label>
              <div className="w-100 d-flex">
                <TimePicker
                  value={date}
                  format="HH:mm"
                  onChange={(e) => this.handleChangeExposureTime(e, i)}
                />
                {i === 0 ? (
                  <div className="pl-4">
                    <button
                      className="btn btn-primary"
                      style={{ width: 50 }}
                      onClick={() => this.addExposureTime()}
                    >
                      +
                    </button>
                  </div>
                ) : null}
                {this.state.exposureTimes.length > 1 && i !== 0 ? (
                  <div className="pl-4">
                    <button
                      className="btn btn-primary"
                      style={{ width: 50 }}
                      onClick={() => this.removeExposureTime(i)}
                    >
                      -
                    </button>
                  </div>
                ) : null}
              </div>
            </div>
          );
        })}
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
              this.state.startDate === "" ||
              this.state.endDate === "" ||
              this.state.validTimes === false
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

  handleChangeStartDate = (e) => {
    debugger;
    this.setState({
      startDate: e,
    });
  };

  handleChangeEndDate = (e) => {
    debugger;
    this.setState({
      endDate: e,
    });
  };

  handleChangeExposureTime = (e, i) => {
    this.setState({
      exposureTimes: this.state.exposureTimes.map((element, j) =>
        j === i ? e : element
      ),
      validTimes: this.checkIfAllTimesNotEmpty(),
    });
  };

  addExposureTime() {
    this.setState({
      exposureTimes: this.state.exposureTimes.concat(""),
      validTimes: this.checkIfAllTimesNotEmpty(),
    });
  }

  removeExposureTime(i) {
    debugger;
    this.setState({
      exposureTimes: this.state.exposureTimes.filter((_, j) => j !== i),
    });
  }

  checkIfAllTimesNotEmpty() {
    let valid = true;
    this.state.exposureTimes.forEach((time) =>
      time === "" ? (valid = false) : null
    );
    return valid;
  }

  changeStep() {
    debugger;
    let tempDate = new Date(this.state.startDate);
    let endDate = new Date(this.state.endDate);
    while (tempDate <= endDate) {
      this.state.exposureTimes.forEach((time) => {
        let dateToAdd = new Date(tempDate);
        let timeArray = time.split(":");
        let hours = parseInt(timeArray[0]);
        let minutes = parseInt(timeArray[1]);
        dateToAdd.setHours(dateToAdd.getHours() + hours);
        dateToAdd.setMinutes(dateToAdd.getMinutes() + minutes);
        this.props.addExposureDates(dateToAdd);
      });

      tempDate.setDate(tempDate.getDate() + 1);
    }
    this.props.changeStep(2);
  }
}

export default SelectRecurringExposureDate;
