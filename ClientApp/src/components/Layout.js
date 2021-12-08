import React, { Component } from 'react';
import { Container } from 'reactstrap';
import Footer from './Footer';
import { NavMenu } from './NavMenu';

export function Layout(props) {
  // static displayName = Layout.name;


  return (
    <>
      <NavMenu />
      <Container>
        {props.children}
      </Container>
      <Footer />
    </>
  );
}

