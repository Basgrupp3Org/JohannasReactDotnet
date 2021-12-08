import React, { Component } from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import { LoginMenu } from "./api-authorization/LoginMenu";
import "./NavMenu.css";
import { AiFillHome, AiFillEye, AiFillCalendar, AiFillDollarCircle } from 'react-icons/ai';
import { ThemeContext } from "../Theme";

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
      // theme: "",

    };
  }

  // componentDidMount() {
  //   let theme = localStorage.getItem("theme
  // console.log(theme); ");
  //   this.setState({ theme: theme })
  // }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    return (
      <ThemeContext.Consumer>
        {theme => (
          <header>
            <Navbar
              className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
              light>

              <Container>
                <NavbarBrand tag={Link} to="/">
                  <span className={theme}> JohannasReactProject</span>
                </NavbarBrand>
                <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                <Collapse
                  className="d-sm-inline-flex flex-sm-row-reverse"
                  isOpen={!this.state.collapsed}
                  navbar
                >
                  <ul className="navbar-nav flex-grow">
                    <NavItem>
                      <NavLink tag={Link} to="/">

                        <span className={theme} > <AiFillHome className="mb-2 me-2" /> Home </span>
                      </NavLink>
                    </NavItem>

                    <NavItem>
                      <NavLink tag={Link} to="/HomePage">

                        <span className={theme}> <AiFillEye className="mb-2 me-2" /> Overview</span>
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={Link} to="/HistoryPage">

                        <span className={theme}> <AiFillCalendar className="mb-2 me-2" /> History </span>
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={Link} to="/BudgetPage">

                        <span className={theme}><AiFillDollarCircle className="mb-2 me-2" /> Budget </span>
                      </NavLink>
                    </NavItem>
                    <LoginMenu></LoginMenu>
                  </ul>
                </Collapse>
              </Container>
            </Navbar>
          </header >
        )}


      </ThemeContext.Consumer>)
  }
}
