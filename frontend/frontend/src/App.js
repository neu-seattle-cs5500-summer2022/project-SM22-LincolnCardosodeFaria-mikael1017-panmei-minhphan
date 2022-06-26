import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/Navbar';

import Client from "./components/Client";

import './App.css';

function App() {
  return (
    // <div className='App'>
    //   <Navbar bg='primary' expand='lg' sticky='top' variant='dark'>
    //     <Container className='container-fluid'>
    //       <Navbar.Brand className='brand' href='/'>
    //         <img src='/icons/client-logo.png' alt='client logo' className='Panel' />
    //         Client
    //       </Navbar.Brand>
    //       <Navbar.Toggle aria-controls='basic-navbar-nav' />
    //       <Navbar.Collapse id='responsive-navbar-nav'>
    //         <Nav className='ml-auto'>
    //           <Nav.Link as={Link} to={'/movies'}>
    //             Movies
    //           </Nav.Link>
    //         </Nav>
    //       </Navbar.Collapse>
    //     </Container>
    //   </Navbar>
    <div className='App'>

      <Navbar bg="light">
        <Container>
          <img src='/icons/client-logo.png' alt='client logo' className='gymLogo' />
          <Navbar.Brand href="#home">Gym Website Name</Navbar.Brand>
        </Container>
      </Navbar>

      <Routes>
        <Route exact path={"/"} element={<Client />} />
        <Route path={"/client/"} element={<Client />} />
        <Route path={"/client/:id/"} element={<Client />} />
      </Routes>
    </div >
  )
}

export default App;
