import React, { Component } from "react";
import { Table } from "reactstrap";
import { Card } from "reactstrap";
import FilledAgentRequest from "./FilledAgentRequest";

class ApprovalAgentRequest extends Component {
  state = {
    showRequestModal: false,
  };

  render() {
    return (
      <React.Fragment>
        {this.state.showRequestModal ? (
          <FilledAgentRequest
            show={this.state.showRequestModal}
            onShowChange={this.displayModalRequest.bind(this)}
          />
        ) : null}
        <main className="main pt-0 pb-0" style={{ backgroundColor: "#4da3ff" }}>
          <div className="wrap bg-white">
            <div className="text-center pt-5">
              <img
                alt=""
                width="150"
                height="150"
                src="/images/iconfinder_00-ELASTOFONT-STORE-READY_user-circle_2703062.png"
              />
            </div>
            <br />
            <div style={{ float: "left" }}>
              <button
                className="btn btn-primary btn-block btn-md mb-2"
                onClick={() => {
                  this.registerAgent();
                }}
              >
                Register Agent
              </button>
            </div>
            <br />

            <Card
              className="mt-5"
              style={{
                shadowColor: "gray",
                boxShadow: "0 8px 6px -6px #999",
              }}
            >
              <div className="pt-2" style={{ textAlign: "center" }}>
                <label className="label">Agent requests:</label>
              </div>
              <Table className="table allPrescriptions mb-0" striped>
                <thead>
                  <tr>
                    <th style={{ textAlign: "left", width: "35%" }}></th>
                    <th className="pr-3" style={{ textAlign: "right" }}></th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td
                      className="pl-4 pt-4 pb-4"
                      style={{ textAlign: "center" }}
                    >
                      Request: Ana Stanic
                    </td>
                    <td
                      className="pl-4 pt-4 pb-4"
                      style={{ textAlign: "center" }}
                    >
                      <button
                        className="btn btn-primary btn-block btn-md mb-2"
                        onClick={() => {
                          this.displayModalRequest(1);
                        }}
                      >
                        Open
                      </button>
                    </td>
                  </tr>
                  {/* {allReports.map((f) => (
                    <tr key={f.id}>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        Report: {f.id}
                      </td>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        <button
                          className="btn btn-primary btn-block btn-md mb-2"
                          onClick={() => {
                            this.displayModalRequest(f.id);
                          }}
                        >
                          Open
                        </button>
                      </td>
                    </tr>
                  ))} */}
                </tbody>
              </Table>
            </Card>
          </div>
        </main>
      </React.Fragment>
    );
  }

  registerAgent() {
    window.location.href = "http://localhost:3000/registration";
  }

  displayModalRequest(id) {
    debugger;
    localStorage.setItem("requestId", id);
    this.setState({
      showRequestModal: !this.state.showRequestModal,
    });
  }
}

export default ApprovalAgentRequest;
