import React, { Component } from "react";
import StoryCard from "../components/StoryCard";
import Layout from "../layouts/Layout";
import InfiniteScroll from "react-infinite-scroll-component";
import { Card, CardBody, CardHeader } from "reactstrap";
import { Checkbox, FormControlLabel } from "@material-ui/core";
import { Favorite, FavoriteBorder } from "@material-ui/icons";

const style = {
  height: 30,
  border: "1px solid green",
  margin: 6,
  padding: 8,
};

class HomePage extends Component {
  state = {
    items: Array.from({ length: 10 }),
  };
  render() {
    return (
      <Layout>
        <StoryCard />
        <InfiniteScroll
          dataLength={this.state.items.length}
          next={this.fetchMoreData}
          hasMore={true}
          loader={<h4>Loading...</h4>}
        >
          {this.state.items.map((i, index) => (
            <Card
              style={{
                marginTop: "40px",
                marginBottom: "40px",
                maxHeight: "900px",
                height: "900px",
              }}
            >
              <CardHeader>
                <img
                  src="images/nature.jpg"
                  style={{ width: 32, height: 32, borderRadius: 50 }}
                />
                <span style={{ width: 15, display: "inline-block" }}></span>
                sample
              </CardHeader>
              <CardBody>
                <img
                  src="images/nature.jpg"
                  style={{
                    maxHeight: "530px",
                    width: "100%",
                    height: "100%",
                  }}
                />
                <div>September 29, 2020</div>
                <br />
                <br />
                <FormControlLabel
                  style={{ width: 24, height: 24 }}
                  control={
                    <Checkbox
                      icon={<FavoriteBorder />}
                      checkedIcon={<Favorite />}
                      name="checkedH"
                    />
                  }
                />
                <img src="images/chat.png" />
                <span style={{ width: 15, display: "inline-block" }}></span>
                <img src="images/send.png" />
                <br />
                <br />
                Likes: <a href="javascript:;">61</a> <br />
                <hr />
                <img src="images/user.png" /> Nice photo great eye
                <br />
                <hr />
                <div style={{ float: "left" }}>
                  <input
                    style={{ border: 0 }}
                    type="text"
                    placeholder="Add a comment..."
                  />
                </div>
                <div style={{ float: "right" }}>
                  <a href="javascript:;"> Post </a>
                </div>
              </CardBody>
            </Card>
          ))}
        </InfiniteScroll>
      </Layout>
    );
  }

  fetchMoreData = () => {
    // a fake async api call like which sends
    // 20 more records in 1.5 secs
    setTimeout(() => {
      this.setState({
        items: this.state.items.concat(Array.from({ length: 20 })),
      });
    }, 1500);
  };
}

export default HomePage;
