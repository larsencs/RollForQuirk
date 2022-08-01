import { Form, FormGroup, Button } from "reactstrap"

export const Register = () =>{
    return (
        <div className="login-container">
        <Form className="login-form">
            <fieldset>
                <FormGroup>
                    <input id="user-email" placeholder="Email Address" type="text" ></input>
                </FormGroup>
                <FormGroup>
                    <input id="user-pwrd" placeholder="Password" type="password" ></input>
                </FormGroup>
                <FormGroup>
                    <Button>Submit</Button>
                </FormGroup>
            </fieldset>
        </Form>
        </div>
    )
}