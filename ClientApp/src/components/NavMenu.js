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
import { AiFillHome, AiFillEye, AiOutlineHistory, AiFillDollarCircle } from 'react-icons/ai';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
            <NavbarBrand tag={Link} to="/">
              <span className="text-white"> JohannasReactProject</span>
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={!this.state.collapsed}
              navbar
            >
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-white" to="/">
                    <AiFillHome style={{ color: "white", marginRight: "5px", marginBottom: "5px" }} />
                    Home
                  </NavLink>
                </NavItem>

                <NavItem>
                  <NavLink tag={Link} className="text-white" to="/HomePage">
                    <AiFillEye style={{ color: "white", marginRight: "5px", marginBottom: "5px" }} />
                    Overview
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-white" to="/HistoryPage">
                    <AiOutlineHistory style={{ color: "white", marginRight: "5px", marginBottom: "5px" }} />
                    History
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-white" to="/BudgetPage">
                    <AiFillDollarCircle style={{ color: "white", marginRight: "5px", marginBottom: "5px" }} />
                    Budget
                  </NavLink>
                </NavItem>
                <LoginMenu></LoginMenu>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
