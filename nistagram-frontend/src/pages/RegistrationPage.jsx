import React, { Component } from "react";
import Registration from "../components/Registration/Registration";
import LayoutRegistration from "../layouts/LayoutRegistration";

class RegistrationPage extends Component {
  render() {
    return (
      <LayoutRegistration>
        <Registration />
      </LayoutRegistration>
    );
  }
}

export default RegistrationPage;