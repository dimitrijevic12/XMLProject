import React, { Component } from "react";
import { Card, CardBody } from "reactstrap";
import StoryList from "./StoryList";
import { FaChevronCircleLeft, FaChevronCircleRight } from "react-icons/fa";

const it = [...Array(30).keys()];
const items = it.map((item) => ({
  id: item,
  url: `https://loremflickr.com/150/150?random=${item}`,
}));

class StoryCard extends Component {
  constructor(props) {
    super(props);
    this.myRef = React.createRef();
  }
  state = {
    items,
    scrollAmount: 0,
    scrollWidth: 1,
  };
  componentDidMount() {
    debugger;
    this.setState({ scrollWidth: this.myRef.current.clientWidth });
  }
  render() {
    return (
      <Card
        style={{
          display: "flex",
          flexDirection: "row",
          textAlign: "center",
          verticalAlign: "middle",
        }}
      >
        {this.state.scrollAmount > 50 ? (
          <button
            className="scroll-left-button"
            onClick={() => this.scroll(-80)}
          >
            <FaChevronCircleLeft
              color="white"
              style={{
                height: "30px",
                width: "30px",
              }}
              filter="drop-shadow( 3px 3px 2px rgba(0, 0, 0, .7))"
            />
          </button>
        ) : null}
        <CardBody
          className="column"
          innerRef={this.myRef}
          style={{ zIndex: "1", overflowX: "scroll" }}
        >
          <StoryList items={this.state.items} onClick={this.handleClick} />
        </CardBody>
        {this.state.scrollWidth > this.state.scrollAmount ? (
          <button
            className="scroll-right-button"
            onClick={() => this.scroll(80)}
          >
            <FaChevronCircleRight
              color="white"
              style={{
                height: "30px",
                width: "30px",
              }}
              filter="drop-shadow( 3px 3px 2px rgba(0, 0, 0, .7))"
            />
          </button>
        ) : null}
      </Card>
    );
  }
  handleClick = (i) => {
    const toBeMoved = this.state.items[i];
    const newItems = this.state.items.filter((_, ind) => ind !== i);
    const items = [...newItems, toBeMoved];

    this.setState({
      items,
    });
  };
  scroll = (scrollOffset) => {
    debugger;
    this.myRef.current.scrollLeft += scrollOffset;
    var totalOffset = this.state.scrollAmount + scrollOffset;
    this.setState({ scrollAmount: totalOffset });
  };
}

export default StoryCard;
