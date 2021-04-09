import React, { Component } from "react";
import { NavLink } from "react-router-dom";

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
        </React.Fragment>
      );
    };
    return <NavBar />;
  }
}

export default NavigationBar;
