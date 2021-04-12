import React, { Component } from "react";
import '../css/app.css';
import background from "../images/nistagrambg.jpg";

class LoginPage extends Component {
    state = {
    };
    render() {
      return (
        <div style={{  width:1580,
            height:1080, backgroundImage: `url(${background})` }} >
        <div id="wrapper">
        <div class="main-content">
          <div class="l-part">
            <input type="text" placeholder="Username" class="input-1" />
            <div class="overlap-text">
              <input type="password" placeholder="Password" class="input-2" />
              <a href="#">Forgot?</a>
            </div>
            <input type="button" value="Log in" class="btn" />
          </div>
        </div>
        <div class="sub-content">
          <div class="s-part">
            Don't have an account?<a href="#">Sign up</a>
          </div>
        </div>
      </div>
      </div>
      );
    }
  }
  
  export default LoginPage;



