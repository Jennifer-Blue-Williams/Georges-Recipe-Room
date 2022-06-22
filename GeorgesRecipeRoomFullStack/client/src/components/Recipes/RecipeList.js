import React, { useEffect, useState } from "react";
import Recipe from "./Recipe";
import { getAllRecipes } from "../../modules/recipeManager";
import { ListGroup, ListGroupItem } from "reactstrap";
import { Link } from "react-router-dom";
import { deleteRecipe } from "../../modules/recipeManager";
import { FormGroup, Input, Label, Button, Form } from "reactstrap";

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
      <div className="row justify-content-center">
        <ListGroup>
          {recipes.map((recipe) => {
            console.log(recipe);
            return (
              <ListGroupItem key={recipe.id}>
                <Recipe recipe={recipe} />
                {/* <h4>Tags:</h4>
                {recipe.tags.map((tag) => (
                  <p>{tag.label}</p>
                ))} */}

                <Link to={`/recipes/${recipe.id}`}>Details</Link>
                <div>
                  <Button
                    className="btn btn-primary"
                    onClick={() => removeRecipe(recipe.id)}
                  >
                    Delete
                  </Button>
                </div>
              </ListGroupItem>
            );
          })}
        </ListGroup>
      </div>
    </div>
  );
};

export default RecipeList;
