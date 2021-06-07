import React, { Component } from "react";
import { getCollectionsByUser } from "../../actions/actions";
import { connect } from "react-redux";
import { Table } from "reactstrap";
import { Card } from "reactstrap";
import { withRouter } from "react-router-dom";
import { compose } from "redux";

class CollectionsMenu extends Component {
  state = {};

  componentDidMount() {
    debugger;
    this.props.getCollectionsByUser();
  }

  render() {
    debugger;
    if (this.props.collections === undefined) {
      return null;
    }
    const collections = this.props.collections;
    return (
      <div>
        <div className="wrap bg-white pt-3 pb-3" style={{ height: "100vh" }}>
          <div style={{ marginTop: "40px" }} id="appointmentTable">
            <div className="text-center">
              <img
                style={{ width: 48, height: 48 }}
                src="/images/collection.png"
              />
            </div>

            <Card
              className="mt-5"
              style={{
                shadowColor: "gray",
                boxShadow: "0 8px 6px -6px #999",
              }}
            >
              <Table className="table allPrescriptions mb-0" striped>
                <thead>
                  <tr>
                    <th style={{ textAlign: "center" }}>Collection Name</th>
                    <th style={{ textAlign: "center" }}>View</th>
                  </tr>
                </thead>
                <tbody>
                  {collections.map((f) => (
                    <tr>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        {f.collectionName}
                      </td>
                      <td
                        className="pl-4 pt-4 pb-4"
                        style={{ textAlign: "center" }}
                      >
                        <button
                          className="btn btn-primary mb-2"
                          onClick={() => {
                            this.view(f);
                          }}
                        >
                          View
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </Table>
            </Card>
          </div>
        </div>
      </div>
    );
  }

  view(f) {
    window.location = "/collection/" + f.id;
  }
}

const mapStateToProps = (state) => ({ collections: state.collections });

export default compose(
  withRouter,
  connect(mapStateToProps, {
    getCollectionsByUser,
  })
)(CollectionsMenu);
