import React, { useContext } from "react";
import { ThemeContext } from "../Theme";
import "./Home.css"

export function Home() {
  // static displayName = Home.name;
  const { theme, toggleTheme } = useContext(ThemeContext);


  return (
    // <div>
    //   <h1>Budget app</h1>
    //   <p>Välkommen till detta</p>
    //   <div className="header-toggle-buttons">
    //     <button onClick={() => toggleTheme()}>{theme}</button>
    //   </div>
    // </div>
    <div className="landing-container">
      <div className="header-toggle-buttons">
        <button onClick={() => toggleTheme()}>{theme}</button>
      </div>
    </div>
  );
}

