import React from "react";
import { Card, CardBody, CardTitle, CardText } from "reactstrap";

const Recipe = ({ recipe }) => {
  return (
    <Card>
      <CardBody>
        <CardTitle tag="h1">{recipe.title}</CardTitle>
        <CardText>{recipe.directions}</CardText>
      </CardBody>
    </Card>
  );
};

export default Recipe;
