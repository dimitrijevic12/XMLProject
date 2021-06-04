import React, { Component } from "react";
import NavigationBar from "./NavigationBar";
import SearchBar from "./SearchBar";

class Header extends Component {
  state = {};
  render() {
    return (
      <header className="pt-4">
        <b>Ništagram</b>
        <span style={{ width: 300, display: "inline-block" }}></span>
        <span style={{ width: 300, display: "inline-block" }}>
          <SearchBar></SearchBar>
        </span>
        <span style={{ display: "inline-block", float: "right", zIndex: "4" }}>
          <NavigationBar />
        </span>
        <hr />
      </header>
    );
  }
}

export default Header;
