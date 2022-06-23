import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input, Col, Row } from "reactstrap";
import { useHistory } from "react-router-dom";
import { register } from "../modules/authManager";
import "../../src/index.css";

export default function Register() {
  const history = useHistory();

  const [name, setName] = useState();
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();

  const registerClick = (e) => {
    e.preventDefault();
    if (password && password !== confirmPassword) {
      alert("Passwords don't match. Try again.");
    } else {
      const userProfile = {
        name,
        email,
      };
      register(userProfile, password).then(() => history.push("/recipes"));
    }
  };

  return (
    <div className="container">
      <Row>
        <Col className="xs-2"></Col>
        <Col className="xs-8">
          <div className="authFormContainer">
            <Form onSubmit={registerClick}>
              <h1 className="pageTitles">Chef Registration</h1>
              <fieldset>
                <FormGroup>
                  <Label htmlFor="name">Name</Label>
                  <Input
                    id="name"
                    type="text"
                    onChange={(e) => setName(e.target.value)}
                  />
                </FormGroup>
                <FormGroup>
                  <Label for="email">Email</Label>
                  <Input
                    id="email"
                    type="text"
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
                  <Label for="confirmPassword">Confirm Password</Label>
                  <Input
                    id="confirmPassword"
                    type="password"
                    onChange={(e) => setConfirmPassword(e.target.value)}
                  />
                </FormGroup>
                <FormGroup>
                  <Button className="btn btn-primary submitButton">
                    Register
                  </Button>
                </FormGroup>
              </fieldset>
            </Form>
          </div>
        </Col>
        <Col className="xs-2"></Col>
      </Row>
    </div>
  );
}
