import { FormGroup,Form,FormText, Button } from "reactstrap"
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { login } from "../../modules/AuthManager.js";
import { Link } from "react-router-dom";
import { BsFileX, BsSlack } from "react-icons/bs";

export const Login = () =>{
    const navigate = useNavigate();

    const [email, setEmail] = useState();
    const [password, setPassword] = useState();
  
    const loginSubmit = (e) => {
      e.preventDefault();
      login(email, password)
        .then(() => navigate("/"))
        .catch(() => alert("Invalid email or password"));
    };

    return (
        <div className="login-container">
        <Form className="login-form">
            <fieldset>
                <FormGroup>
                    <input id="user-email" placeholder="Email Address" type="text" onChange={(e) => setEmail(e.target.value)}></input>
                </FormGroup>
                <FormGroup>
                    <input id="user-pwrd" placeholder="Password" type="password" onChange={(e) => setPassword(e.target.value)}></input>
                </FormGroup>
                <FormGroup>
                    <Button onClick={loginSubmit}>Submit</Button>
                </FormGroup>
                <em>
                Not registered? <Link to="register">Register</Link>
                </em>
            </fieldset>
        </Form>
        </div>
    )
}