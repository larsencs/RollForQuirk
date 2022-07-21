import logo from './logo.svg';
import './App.css';
import React, { useEffect, useState } from 'react';
import { ApplicationViews } from './ApplicationViews';
import { BrowserRouter as Router } from "react-router-dom";
import { onLoginStatusChange } from './modules/AuthManager';
import { Spinner } from 'reactstrap';
import { Header } from './components/header/Header';
import { Footer } from './components/footer/Footer';

function App({getLoggedInUser}) {

  const [isLoggedIn, setIsLoggedIn] = useState(null);

  useEffect(() => {
    onLoginStatusChange(setIsLoggedIn);
  }, []);

  if (isLoggedIn === null) {
    return <Spinner className="app-spinner dark" />;
  }

  return (
    <div className="App">
      <Router>
        <Header isLoggedIn={isLoggedIn}/>
        <ApplicationViews isLoggedIn={isLoggedIn} getLoggedInUser={getLoggedInUser}/>
        <Footer isLoggedIn={isLoggedIn}/>
      </Router>
    </div>
  );
}

export default App;
