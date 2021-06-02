import React, { Component } from "react";
import { NavLink } from "react-router-dom";
import {
  NavbarBrand,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  UncontrolledDropdown,
} from "reactstrap";

class NavigationBar extends Component {
  state = {};

  render() {
    const NavBar = () => {
      return (
        <React.Fragment>
          <NavLink exact to="/">
            <img src="images/home.png" />
          </NavLink>
          <span style={{ width: 25, display: "inline-block" }}></span>
          <NavLink exact to="/messages">
            <img src="images/send.png" />
          </NavLink>
          <span style={{ width: 25, display: "inline-block" }}></span>
          <NavLink exact to="/notifications">
            <img src="images/heart.png" />
          </NavLink>
          <span style={{ width: 25, display: "inline-block" }}></span>
          <NavLink exact to="/profile">
            <img
              src="images/download.jfif"
              style={{ width: 24, height: 24, borderRadius: 50 }}
            />
          </NavLink>
          <UncontrolledDropdown style={{ float: "right" }}>
            <DropdownToggle nav caret></DropdownToggle>
            <DropdownMenu right>
              <DropdownItem>
                <NavLink to="/edit">Edit profile</NavLink>
              </DropdownItem>
              <DropdownItem divider />
              <DropdownItem>
                <NavLink to="/logout">Logout</NavLink>
              </DropdownItem>
            </DropdownMenu>
          </UncontrolledDropdown>
        </React.Fragment>
      );
    };
    return <NavBar />;
  }
}

export default NavigationBar;
