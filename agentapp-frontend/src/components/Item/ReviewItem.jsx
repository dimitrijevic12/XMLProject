import React, { useEffect } from "react";
import { getItemById, deleteItem } from "../../actions/actions";
import { connect } from "react-redux";
import { compose } from "redux";
import { withRouter } from "react-router-dom";

function ReviewItem(props) {
  useEffect(() => {
    props.getItemById(props.location.pathname.slice(7));
  }, [props.location.pathname]);

  const Item = () => {
    debugger;
    if (props.loadedImage === undefined) {
      return null;
    }
    debugger;
    return (
      <img
        src={"data:image/jpg;base64," + props.loadedImage.fileContents}
        style={{ width: 600, height: 320 }}
        className="mb-3"
      />
    );
  };

  debugger;

  const editItem = () => {
    sessionStorage.setItem("itemId", props.item.id);
    window.location = "/edit-item";
  };

  const deleteItem = async () => {
    await props.deleteItem(props.item);
    window.location = "/";
  };

  if (props.item === undefined) {
    return null;
  }

  return (
    <React.Fragment>
      <div className="mt-5">
        <div className="d-inline-flex w-50">
          <div class="form-group w-100 pr-5">
            <Item />
          </div>
        </div>
        <div className="d-inline-flex w-50">
          <div class="form-group w-100 pr-5">
            <label className="label">Name:</label>
            <input
              type="text"
              name="name"
              class="form-control"
              id="name"
              value={props.item.name}
              disabled={true}
              placeholder="Enter name of product"
            />
          </div>
        </div>
      </div>
      <div className="mt-5">
        <div className="d-inline-flex w-50">
          <div class="form-group w-100 pr-5">
            <label for="tag">Price:</label>
            <input
              type="number"
              name="price"
              class="form-control"
              id="price"
              value={props.item.price}
              disabled={true}
              placeholder="Enter price"
            />
          </div>
        </div>
        <div className="d-inline-flex w-50">
          <div class="form-group w-100 pr-5">
            <label for="location">Available count:</label>
            <input
              type="number"
              name="availableCount"
              class="form-control"
              id="availableCount"
              value={props.item.availableCount}
              disabled={true}
              placeholder="Enter availableCount"
            />
          </div>
        </div>
      </div>
      <div style={{ textAlign: "center" }} className="mt-5 pb-5">
        <button
          onClick={() => {
            editItem();
          }}
          className="btn btn-danger btn-block"
        >
          Edit
        </button>
        <span style={{ width: 25, display: "inline-block" }}></span>
        <button
          onClick={() => {
            deleteItem();
          }}
          className="btn btn-danger btn-block"
        >
          Delete
        </button>
      </div>
    </React.Fragment>
  );
}

const mapStateToProps = (state) => ({
  item: state.item,
  loadedImage: state.loadedImage,
});

export default compose(
  withRouter,
  connect(mapStateToProps, {
    getItemById,
    deleteItem,
  })
)(ReviewItem);
