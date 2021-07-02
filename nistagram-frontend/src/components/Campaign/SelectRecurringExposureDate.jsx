import React, { Component } from "react";
import DateTimePicker from "react-datetime-picker";

class SelectRecurringExposureDate extends Component {
  state = { exposureDates: [""], maxExposureDates: 5 };
  render() {
    debugger;
    return (
      <div className="mt-5">
        {this.state.exposureDates.map((date, i) => {
          return (
            <div className="form-group w-75" style={{ paddingLeft: 300 }}>
              <label className="label">Select exposure date:</label>
              <div className="w-100 d-flex">
                <DateTimePicker
                  value={date}
                  format="dd/MM/yyyy HH:mm"
                  minDate={new Date()}
                  onChange={(e) => this.handleChangeExposureDate(e, i)}
                />
                {i === 0 ? (
                  <div className="pl-4">
                    <button
                      className="btn btn-primary"
                      style={{ width: 50 }}
                      onClick={() => this.addExposureDate()}
                    >
                      +
                    </button>
                  </div>
                ) : null}
                {this.state.exposureDates.length > 1 && i !== 0 ? (
                  <div className="pl-4">
                    <button
                      className="btn btn-primary"
                      style={{ width: 50 }}
                      onClick={() => this.removeExposureDate(i)}
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

  handleChangeExposureDate = (e, i) => {
    debugger;
    this.setState({
      exposureDates: this.state.exposureDates.map((element, j) =>
        j === i ? e : element
      ),
    });
  };

  addExposureDate() {
    this.setState({ exposureDates: this.state.exposureDates.concat("") });
  }

  removeExposureDate(i) {
    debugger;
    this.setState({
      exposureDates: this.state.exposureDates.filter((_, j) => j !== i),
    });
  }

  changeStep() {
    this.props.addExposureDates(this.state.exposureDates);
    this.props.changeStep(2);
  }
}

export default SelectRecurringExposureDate;
