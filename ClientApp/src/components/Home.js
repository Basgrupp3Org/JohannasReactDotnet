import React, { Component } from "react";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1 style={{ color: "white" }}>Budget App</h1>
        <p style={{ color: "white" }}>Välkommen till detta</p>
      </div>
    );
  }
}
