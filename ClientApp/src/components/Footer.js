import React from 'react'
import "./Footer.css"
import { AiFillGithub, AiFillYoutube } from 'react-icons/ai';
import { ThemeContext } from "../Theme";

export default function Footer() {
  return (
    <footer>
      <p className="footer-content">© 2021 Copyright Basgrupp 3</p>
      <ThemeContext.Consumer>
        {theme => (
          <span className={theme}>
            <a href="https://github.com/Basgrupp3Org" >
              <AiFillGithub style={{ fontSize: "30px", marginRight: "10px" }} />
            </a>
            <a href="https://youtu.be/UIkmw0LBGiA?t=3155" >
              <AiFillYoutube style={{ fontSize: "30px" }} />
            </a>
          </span>
        )}
      </ThemeContext.Consumer>
    </footer>
  )
}
