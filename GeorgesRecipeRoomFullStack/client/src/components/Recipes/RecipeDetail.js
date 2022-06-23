import React, { useEffect, useState } from "react";
import { getRecipeDetailsById } from "../../modules/recipeManager";
import { useParams } from "react-router-dom";
import "../../../src/index.css";
import {
  Card,
  CardBody,
  Button,
  CardFooter,
  CardSubtitle,
  CardTitle,
  Col,
  Row,
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
    <div className="container">
      <Row>
        <Col className="xs-8">
          <div className="recipeCard">
            <Card style={{ margin: "2rem", width: "500px" }}>
              <CardBody>
                <CardTitle className="">{recipe.title}</CardTitle>
                {/* <CardText>{recipe.imageUrl}</CardText> */}
                <img src={recipe.imageUrl} alt="Food Image" width="250"></img>
                <CardSubtitle className="mb-2 text-muted" tag="h2">
                  {recipe.directions}
                </CardSubtitle>
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
                  <Button className="btn btn-primary submitButton">Edit</Button>
                </Link>
              </CardBody>
            </Card>
          </div>
        </Col>
      </Row>
    </div>
  );
};

export default RecipeDetails;
