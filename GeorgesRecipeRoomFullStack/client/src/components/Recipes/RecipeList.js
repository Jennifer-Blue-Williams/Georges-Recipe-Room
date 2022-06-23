import React, { useEffect, useState } from "react";
import Recipe from "./Recipe";
import { getAllRecipes } from "../../modules/recipeManager";
import { ListGroup, ListGroupItem, Row, Col, Button } from "reactstrap";
import { Link } from "react-router-dom";
import { deleteRecipe } from "../../modules/recipeManager";

const RecipeList = () => {
  const [recipes, setRecipes] = useState([]);

  const getRecipes = () => {
    getAllRecipes().then((recipes) => setRecipes(recipes));
  };

  const removeRecipe = (id) => {
    deleteRecipe(id).then(getRecipes());
  };

  useEffect(() => {
    getRecipes();
  }, []);

  return (
    <div className="container">
      <Row>
        <Col className="xs-8">
          <div className="recipeCard">
            <ListGroup horizontal>
              {recipes.map((recipe) => {
                console.log(recipe);
                return (
                  <div className="card">
                    <ListGroupItem key={recipe.id}>
                      <Row>
                        <Col className="xs-2"></Col>
                        <Col className="xs-8">
                          <Row>
                            <Col>
                              <Recipe recipe={recipe} />
                            </Col>
                          </Row>
                          <Row>
                            <div classname="tags">
                              {recipe.tags.map((tag) => (
                                <Col className="xs-2">
                                  <p>{tag.label}</p>
                                </Col>
                              ))}
                            </div>
                          </Row>
                          <Button
                            className="btn btn-primary submitButton"
                            href={`/recipes/${recipe.id}`}
                          >
                            View
                          </Button>
                          <div>
                            <Button
                              className="btn btn-primary submitButton"
                              onClick={() => removeRecipe(recipe.id)}
                            >
                              Delete
                            </Button>
                          </div>
                        </Col>
                        <Col className="xs-2"></Col>
                      </Row>
                    </ListGroupItem>
                  </div>
                );
              })}
            </ListGroup>
          </div>
        </Col>
      </Row>
    </div>
  );
};

export default RecipeList;
