import React, { Component } from "react";
import '../css/app.css';
import { userLoggedIn } from "../actions/actionsUser"
import { connect } from "react-redux"
import background from "../images/nistagrambg.jpg";

class LoginPage extends Component {
  state = {
    username: "",
    password: "",
  };
    render() {
      return (
        <div style={{  width:1580,
            height:1080, backgroundImage: `url(${background})` }} >
        <div id="wrapper">
        <div class="main-content">
          <div class="l-part">
            <input type="text" placeholder="Username" name="username" class="input-1" onChange={this.handleChange}/>
            <div class="overlap-text">
              <input type="password" placeholder="Password" name="password" class="input-2" onChange={this.handleChange}/>
              <a href="#">Forgot?</a>
            </div>
            <input type="button" value="Log in" class="btn" onClick={this.login.bind(this)} />
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

    handleChange = (event) => {
      debugger;
      const { name, value, type, checked } = event.target;
      type === "checkbox"
        ? this.setState({
            [name]: checked,
          })
        : this.setState({
            [name]: value,
          });
    };

    async login() {
      debugger;
        this.props.userLoggedIn({ "Username" : this.state.username,
                                  "Password" : this.state.password })      
      }
  }
  
  const mapStateToProps = (state) =>

    ({ userLoggedIn: state.userLoggedIn })

  export default connect(mapStateToProps, { userLoggedIn })(LoginPage); 



