import React, { Component } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker-cssmodules.css";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "../../css/acceptdeny.css";
import moment from "moment";

class FilledAgentRequest extends Component {
  state = {
    id: this.props.request.id,
    name:
      this.props.request.registeredUser.firstName +
      " " +
      this.props.request.registeredUser.lastName,
    email: this.props.request.registeredUser.email,
    phoneNumber: this.props.request.registeredUser.phoneNumber,
    dateOfBirth: moment(this.props.request.registeredUser.dateOfBirth).format(
      "DD/MM/YYYY"
    ),
    gender: this.props.request.registeredUser.gender,
    username: this.props.request.registeredUser.username,
    bio: this.props.request.registeredUser.bio,
    webSite: this.props.request.registeredUser.websiteAddress,
    showRequestModal: this.props.show,
  };

  render() {
    return (
      <Modal
        style={{
          maxWidth: "850px",
          width: "849px",
        }}
        isOpen={this.state.showRequestModal}
        centered={true}
      >
        <ModalHeader toggle={this.toggle.bind(this)}>Registration</ModalHeader>
        <ModalBody>
          <div className="text-center pt-5">
            <img
              alt=""
              width="100"
              height="100"
              src="/images/iconfinder_00-ELASTOFONT-STORE-READY_user-circle_2703062.png"
            />
          </div>
          <div className="mt-5">
            <div className="d-inline-flex w-50">
              <div class="form-group w-100 pr-5">
                <label for="firstName">Name and surname:</label>
                <input
                  type="text"
                  name="name"
                  disabled={true}
                  value={this.state.name}
                  class="form-control"
                  id="name"
                  placeholder="Enter name"
                />
              </div>
            </div>
            <div className="d-inline-flex w-50">
              <div class="form-group w-100 pr-5">
                <label for="lastName">Email:</label>
                <input
                  type="text"
                  name="email"
                  disabled={true}
                  value={this.state.email}
                  class="form-control"
                  id="email"
                  placeholder="Enter email"
                />
              </div>
            </div>
          </div>
          <div className="mt-5">
            <div className="d-inline-flex w-50">
              <div class="form-group w-100 pr-5">
                <label for="dateofbirth">Date of birth:</label>
                <div className="d-block w-100">
                  <input
                    type="text"
                    name="dateOfBirth"
                    disabled={true}
                    value={this.state.dateOfBirth}
                    class="form-control"
                    id="dateOfBirth"
                    placeholder="Enter date of birth"
                  />
                </div>
              </div>
            </div>
            <div className="d-inline-flex w-50">
              <div class="form-group w-100 pr-5">
                <label for="telephone">Phone number:</label>
                <input
                  type="text"
                  name="phoneNumber"
                  disabled={true}
                  value={this.state.phoneNumber}
                  class="form-control"
                  id="telephone"
                  placeholder="Enter telephone number"
                />
              </div>
            </div>
          </div>
          <div className="mt-5">
            <div className="d-inline-flex w-50">
              <div class="form-group w-100 pr-5">
                <label for="firstName">Username:</label>
                <input
                  type="text"
                  name="username"
                  disabled={true}
                  value={this.state.username}
                  class="form-control"
                  id="username"
                  placeholder="Enter username"
                />
              </div>
            </div>
            <div className="d-inline-flex w-50">
              <div class="form-group w-100 pr-5">
                <label for="lastName">Gender:</label>
                <select
                  value={this.state.gender}
                  disabled={true}
                  class="form-control"
                  name="gender"
                >
                  <option value=""> </option>
                  <option value="male">Male</option>
                  <option value="female">Female</option>
                </select>
              </div>
            </div>
          </div>
          <div className="mt-5">
            <div className="d-inline-flex w-50">
              <div class="form-group w-100 pr-5">
                <label for="firstName">Biography:</label>
                <textarea
                  name="bio"
                  value={this.state.bio}
                  disabled={true}
                  cols="40"
                  rows="5"
                  class="form-control"
                  placeholder="Enter biography"
                ></textarea>
              </div>
            </div>
            <div className="d-inline-flex w-50">
              <div class="form-group w-100 pr-5">
                <label for="lastName">Web site:</label>
                <input
                  type="text"
                  name="webSite"
                  disabled={true}
                  value={this.state.webSite}
                  class="form-control"
                  id="webSite"
                  placeholder="Enter webSite"
                />
              </div>
            </div>
          </div>
        </ModalBody>
        <ModalFooter>
          <button class="accept">
            ACCEPT <span class="fa fa-check"></span>
          </button>
          <button class="deny">
            DENY <span class="fa fa-close"></span>
          </button>
        </ModalFooter>
      </Modal>
    );
  }

  toggle() {
    debugger;
    this.setState({ showRequestModal: false });
    this.props.onShowChange();
  }
}

export default FilledAgentRequest;
