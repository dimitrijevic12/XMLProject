import React, { Component } from "react";
import { NavLink } from "react-router-dom";

class NavigationBar extends Component {
  state = {};

  render() {
    const NavBar = () => {
      return (
        <div className="menu">
          <NavLink exact to="/home" className="btn nav">
            Home
          </NavLink>
          <NavLink exact to="/messages" className="btn nav">
            Messages
          </NavLink>
          <NavLink exact to="/" className="btn nav">
            Profile
          </NavLink>
        </div>
      );
    };
    return (
      <nav>
        <NavBar />
        <span className="line"></span>
      </nav>
    );
  }
}

export default NavigationBar;
