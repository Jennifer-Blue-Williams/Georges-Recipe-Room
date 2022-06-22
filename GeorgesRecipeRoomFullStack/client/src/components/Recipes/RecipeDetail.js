import React, { useEffect, useState } from "react";
import { getRecipeDetailsById } from "../../modules/recipeManager";
import { useParams } from "react-router-dom";
import {
  Card,
  CardBody,
  CardFooter,
  CardSubtitle,
  CardText,
  CardTitle,
} from "reactstrap";
import { Link } from "react-router-dom";

const RecipeDetails = () => {
  const [recipe, setRecipe] = useState(null);
  const { recipeId } = useParams();
  const getRecipe = (id) => {
    getRecipeDetailsById(id).then((recipe) => setRecipe(recipe));
  };

  useEffect(() => {
    getRecipe(recipeId);
  }, []);

  if (recipe === null) {
    return null;
  }
  return (
    <Card style={{ margin: "1rem" }}>
      <CardBody>
        <CardTitle tag="h1">{recipe.title}</CardTitle>
        <CardSubtitle className="mb-2 text-muted" tag="h2">
          {recipe.directions}
        </CardSubtitle>
        <CardText>{recipe.imageUrl}</CardText>
        <CardFooter>
          <div>
            Recipe Tags:
            <ul>
              <p>{recipe.tag}</p>
            </ul>
          </div>
        </CardFooter>
      </CardBody>
    </Card>
  );
};

export default RecipeDetails;