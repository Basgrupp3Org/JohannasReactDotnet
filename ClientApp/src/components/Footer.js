import React from 'react'
import "./Footer.css"
import { AiFillGithub, AiFillYoutube } from 'react-icons/ai';

export default function Footer() {
    return (
        <footer>
            <p className="footer-content">© 2021 Copyright Basgrupp 3</p>
            <a href="https://github.com/Basgrupp3Org" style={{ color: "#ABB2BF" }}>
                <AiFillGithub style={{ fontSize: "40px", marginRight: "10px" }} />
            </a>
            <a href="https://youtu.be/UIkmw0LBGiA?t=3155" style={{ color: "#ABB2BF" }}>
                <AiFillYoutube style={{ fontSize: "40px" }} />
            </a>

        </footer>
    )
}
