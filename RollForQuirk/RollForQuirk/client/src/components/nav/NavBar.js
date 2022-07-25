import { Navbar, NavItem, Button, NavLink } from "reactstrap"
import { useNavigate } from "react-router-dom"
import {logout} from '../../modules/AuthManager.js'

export const NavBar = () =>{

    const navigate = useNavigate()

    return(
<nav className="navbar navbar-expand-lg navbar-light bg-dark">
  <div className="container-fluid">
    <a className="navbar-brand" onClick={() => navigate("/")} style={{cursor: "pointer", color: "white"}}>Home</a>
    <div className="collapse navbar-collapse">
      <div className="navbar-nav">
        <a className="nav-link" onClick={() => navigate("create")} style={{cursor: "pointer", color: "white"}}>New Character</a>
      </div>
    </div>
    <div><a className="nav-link" style={{cursor: "pointer", color: "white"}} onClick={()=>logout()}>Logout</a></div>
  </div>
</nav>
    )
}