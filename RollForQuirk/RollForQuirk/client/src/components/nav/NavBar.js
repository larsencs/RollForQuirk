import { Navbar, NavItem, Button, NavLink } from "reactstrap"
import { useNavigate } from "react-router-dom"
import {logout} from '../../modules/AuthManager.js'

export const NavBar = () =>{

    const navigate = useNavigate()

    return(
<nav className="navbar navbar-expand">
  <div className="container-fluid">
    <a className="nav-link mx-2" onClick={() => navigate("/")} style={{cursor: "pointer"}}>Home</a>
    <div className="collapse navbar-collapse">
      <div className="navbar-nav">
        <a className="nav-link mx-2" onClick={() => navigate("create")} style={{cursor: "pointer"}}>New Character</a>
      </div>
    </div>
    <div><a className="nav-link mx-2" style={{cursor: "pointer"}} onClick={()=>logout()}>Logout</a></div>
  </div>
</nav>
    )
}