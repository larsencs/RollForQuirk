import { Media } from "reactstrap"
import {NavBar} from "../nav/NavBar"
import { useNavigate } from "react-router-dom"


export const Header = () =>{


    const navigate = useNavigate()
    const imageSize = {
        maxHeight: 100,
        maxWidth: 200,
        cursor: "pointer"
    }

    return (
        <div>
        <div>
            <Media src="/images/RollForQuirk.png" style={imageSize} onClick={()=> navigate("/")}/>
        </div>
        <NavBar/>
        </div>
    )
}