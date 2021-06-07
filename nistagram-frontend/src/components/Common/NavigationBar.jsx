import React, { Component } from "react";
import { NavLink } from "react-router-dom";
import { withRouter } from "react-router-dom";
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
            <img src="/images/home.png" />
          </NavLink>
          <span style={{ width: 25, display: "inline-block" }}></span>
          <NavLink exact to="/post">
            <img src="/images/addpost.png" />
          </NavLink>
          <span style={{ width: 25, display: "inline-block" }}></span>
          <NavLink exact to="/messages">
            <img src="/images/send.png" />
          </NavLink>
          <span style={{ width: 25, display: "inline-block" }}></span>
          <NavLink exact to="/requests">
            <img src="/images/heart.png" />
          </NavLink>
          <span style={{ width: 25, display: "inline-block" }}></span>
          <NavLink exact to={"/profile/" + sessionStorage.getItem("userId")}>
            <img
              src="/images/user.png"
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
                <NavLink to="/login" onClick={this.logout.bind(this)}>
                  Logout
                </NavLink>
              </DropdownItem>
            </DropdownMenu>
          </UncontrolledDropdown>
        </React.Fragment>
      );
    };
    return <NavBar />;
  }

  logout() {
    this.removeLocalStorage();
    this.removeSessionStorage();
    this.props.history.push("/login");
  }
  removeLocalStorage() {
    localStorage.setItem("storage", "");
    localStorage.setItem("token", "");
    localStorage.setItem("id", "");
    localStorage.setItem("role", "");
    localStorage.setItem("username", "");
  }

  removeSessionStorage() {
    localStorage.setItem("storage", "");
    sessionStorage.setItem("token", "");
    sessionStorage.setItem("id", "");
    sessionStorage.setItem("role", "");
    sessionStorage.setItem("username", "");
  }
}

export default withRouter(NavigationBar);
