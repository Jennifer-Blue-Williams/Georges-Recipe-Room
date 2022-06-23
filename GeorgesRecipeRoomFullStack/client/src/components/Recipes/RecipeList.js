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
            <ListGroup>
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
                          <ListGroup horizontal={"sm"} className="my-2">
                            {recipe.tags.map((tag) => (
                              <ListGroupItem className="border-0" key={tag.id}>
                                {tag.label}
                              </ListGroupItem>
                            ))}
                          </ListGroup>
                          <Row>
                            <Col className="xs-1"></Col>
                            <Col>
                              <Button
                                className="btn btn-primary submitButton"
                                href={`/recipes/${recipe.id}`}
                              >
                                View
                              </Button>
                              <Button
                                className="btn btn-primary submitButton"
                                onClick={() => removeRecipe(recipe.id)}
                              >
                                Delete
                              </Button>
                            </Col>
                            <Col className="xs-1"></Col>
                          </Row>
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
