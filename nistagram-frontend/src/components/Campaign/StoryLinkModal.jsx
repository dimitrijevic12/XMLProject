import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { connect } from "react-redux";
import { getAdForContent } from "../../actions/actionsCampaign";

class StoryLinkModal extends Component {
  state = {
    showPostModal: this.props.show,
  };

  async componentDidMount() {
    await this.props.getAdForContent(this.props.contentId);
  }

  render() {
    if (this.props.ad === undefined) {
      return null;
    }
    return (
      <Modal
        style={{
          maxWidth: "450px",
          width: "449px",
        }}
        isOpen={this.state.showPostModal}
        centered={true}
      >
        <ModalHeader toggle={this.toggle.bind(this)}>Link</ModalHeader>
        <ModalBody>
          <a href={this.props.ad.link}>{this.props.ad.link}</a>
        </ModalBody>
        <ModalFooter></ModalFooter>
      </Modal>
    );
  }

  toggle() {
    debugger;
    this.setState({ showPostModal: false });
    this.props.onShowChange();
  }
}

const mapStateToProps = (state) => ({ ad: state.ad });

export default connect(mapStateToProps, { getAdForContent })(StoryLinkModal);
