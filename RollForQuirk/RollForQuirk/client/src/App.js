import logo from './logo.svg';
import './App.css';
import { ApplicationViews } from './ApplicationViews';
import { Header } from './components/header/Header';
import { Footer } from './components/footer/Footer';

function App() {
  return (
    <div className="App">
      <Header/>
      <ApplicationViews/>
      <Footer/>
    </div>
  );
}

export default App;
