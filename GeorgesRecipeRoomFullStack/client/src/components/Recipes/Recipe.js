import React from "react";
import { Card, CardBody, CardTitle, CardText } from "reactstrap";

const Recipe = ({ recipe }) => {
  return (
    <Card>
      <CardBody>
        <CardTitle tag="h1">{recipe.title}</CardTitle>
        {/* <CardText>{recipe.imageUrl}</CardText> */}
        <img
          src="{recipe.imageUrl}"
          alt="Food Image"
          width="500"
          height="600"
        ></img>
      </CardBody>
    </Card>
  );
};

export default Recipe;
