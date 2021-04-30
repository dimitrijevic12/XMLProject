import React, { Component } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker-cssmodules.css";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "../../css/acceptdeny.css";

class FilledAgentRequest extends Component {
  state = {
    id: 1,
    name: "Ana",
    email: "ana@gmail.com",
    phoneNumber: "123-456789",
    dateOfBirth: "",
    gender: "Female",
    username: "ana",
    bio:
      "Asdasa sadgas fhgfdhdfhdf gdgsggdsg ofohdfosdho oshfdsfshfsdhiudsfhids hshdf",
    webSite: "www.ana.com",
    password: "ana",
    repeatPassword: "ana",
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
                <label for="firstName">Name:</label>
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
                  <DatePicker
                    className="form-control w-100"
                    id="dateofbirth"
                    name="dueDate"
                    disabled={true}
                    dateFormat="dd/MM/yyyy"
                    selected={this.state.dateOfBirth}
                    maxDate={new Date()}
                    onChange={(e) => this.handleChangeDate(e)}
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
                  <option value="Male">Male</option>
                  <option value="Female">Female</option>
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
