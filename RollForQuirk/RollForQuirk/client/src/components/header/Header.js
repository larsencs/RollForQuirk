import { Media } from "reactstrap"
import {NavBar} from "../nav/NavBar"


export const Header = () =>{

    const imageSize = {
        maxHeight: 100,
        maxWidth: 200
    }

    return (
        <div>
        <div>
            <Media src="/images/RollForQuirk.png" style={imageSize}/>
        </div>
        <NavBar/>
        </div>
    )
}