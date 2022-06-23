import React from "react";
import { Card, CardBody, CardTitle } from "reactstrap";

const Recipe = ({ recipe }) => {
  return (
    <div className="card-columns">
      <Card>
        <CardBody>
          <CardTitle tag="h1">{recipe.title}</CardTitle>
          <img src={recipe.imageUrl} alt="Food Image" width="100"></img>
        </CardBody>
      </Card>
    </div>
  );
};

export default Recipe;
