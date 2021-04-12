import React, { Component } from "react";
import { NavLink } from "react-router-dom";
import NavigationBar from "./NavigationBar";

class Header extends Component {
  state = {};
  render() {
    debugger;
    return (
      <header className="pt-4">
        <NavLink exact to="/">
          <img src="images/nistagram-logo.png" width="130px"></img>
        </NavLink>
        <span style={{ width: 400, display: "inline-block" }}></span>
        <input
          style={{ textAlign: "center" }}
          type="text"
          placeholder="Search"
        />
        <span style={{ width: 200, display: "inline-block" }}></span>
        <NavigationBar />
        <hr />
      </header>
    );
  }
}

export default Header;
