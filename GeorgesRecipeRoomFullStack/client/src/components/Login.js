import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input, Col, Row } from "reactstrap";
import { useHistory, Link } from "react-router-dom";
import { login } from "../modules/authManager";

export default function Login() {
  const history = useHistory();

  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  const loginSubmit = (e) => {
    e.preventDefault();
    login(email, password)
      .then(() => history.push("/recipes"))
      .catch(() => alert("Invalid email or password"));
  };

  return (
    <div className="container">
      <Row>
        <Col className="xs-2"></Col>
        <Col className="xs-8">
          <div className="authFormContainer">
            <Form onSubmit={loginSubmit}>
              <h1 className="pageTitles">Chef Login</h1>
              <fieldset>
                <FormGroup>
                  <Label for="email">Email</Label>
                  <Input
                    id="email"
                    type="text"
                    autoFocus
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </FormGroup>
                <FormGroup>
                  <Label for="password">Password</Label>
                  <Input
                    id="password"
                    type="password"
                    onChange={(e) => setPassword(e.target.value)}
                  />
                </FormGroup>
                <FormGroup>
                  <Button>Login</Button>
                </FormGroup>
                <em>
                  New Chef?{" "}
                  <span className="registerLink">
                    <Link to="register">Register Here!</Link>
                  </span>
                </em>
              </fieldset>
            </Form>
          </div>
        </Col>
        <Col className="xs-2"></Col>
      </Row>
    </div>
  );
}
