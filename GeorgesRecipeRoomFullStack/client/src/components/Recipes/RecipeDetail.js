import React, { useEffect, useState } from "react";
import { getRecipeDetailsById } from "../../modules/recipeManager";
import { useParams } from "react-router-dom";
import {
  Card,
  CardBody,
  Button,
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
        {/* <CardText>{recipe.imageUrl}</CardText> */}
        <img src={recipe.imageUrl} alt="Food Image" width="100"></img>
        <CardFooter>
          <div>
            Recipe Tags:
            <ul>
              <p>
                {recipe.tags
                  .map((tag) => {
                    return tag.label;
                  })
                  .join(", ")}
              </p>
            </ul>
          </div>
        </CardFooter>
        <Link to={`/recipes/edit/${recipeId}`}>
          <Button>Edit</Button>
        </Link>
      </CardBody>
    </Card>
  );
};

export default RecipeDetails;
