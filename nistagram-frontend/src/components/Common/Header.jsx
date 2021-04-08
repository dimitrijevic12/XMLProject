import React, { Component } from "react";
import NavigationBar from "./NavigationBar";

class Header extends Component {
  state = {};
  render() {
    debugger;
    return (
      <header className="pt-4">
        <label>Ništagram</label>
        <span style={{ width: 400, display: "inline-block" }}></span>
        <input
          style={{ textAlign: "center" }}
          type="text"
          placeholder="Search"
        />
        <span style={{ width: 300, display: "inline-block" }}></span>
        <img src="images/home.png" />
        <span style={{ width: 25, display: "inline-block" }}></span>
        <img src="images/send.png" />
        <span style={{ width: 25, display: "inline-block" }}></span>
        <img
          src="images/download.jfif"
          style={{ width: 24, height: 24, borderRadius: 50 }}
        />
        <hr />
      </header>
    );
  }
}

export default Header;
