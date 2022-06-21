import React, { useEffect, useState } from "react";
import Recipe from "./Recipe";
import { getAllRecipes } from "../../modules/recipeManager";
import { ListGroup, ListGroupItem } from "reactstrap";
import { Link } from "react-router-dom";

const RecipeList = () => {
  const [recipes, setRecipes] = useState([]);

  const getRecipes = () => {
    getAllRecipes().then((recipes) => setRecipes(recipes));
  };

  useEffect(() => {
    getRecipes();
  }, []);

  return (
    <div className="container">
      <div className="row justify-content-center">
        <ListGroup>
          {recipes.map((recipe) => {
            return (
              <ListGroupItem key={recipe.id}>
                <Recipe recipe={recipe} />
                <Link to={`/recipes/${recipe.id}`}>Details</Link>
              </ListGroupItem>
            );
          })}
        </ListGroup>
      </div>
    </div>
  );
};

export default RecipeList;
