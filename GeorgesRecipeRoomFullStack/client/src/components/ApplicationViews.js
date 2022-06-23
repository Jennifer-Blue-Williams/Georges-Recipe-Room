import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import RecipeList from "./Recipes/RecipeList";
import RecipeDetailsById from "./Recipes/RecipeDetail";
import RecipeForm from "./Recipes/RecipeForm";
import RecipeEdit from "./Recipes/RecipeEdit";

export default function ApplicationViews({ isLoggedIn }) {
  return (
    <main>
      <Switch>
        <Route path="/" exact>
          {isLoggedIn ? <RecipeList /> : <Redirect to="/login" />}
        </Route>
        <Route path="/recipes" exact>
          {isLoggedIn ? <RecipeList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/recipes/:recipeId(\d+)">
          {isLoggedIn ? <RecipeDetailsById /> : <Redirect to="/login" />}
        </Route>

        <Route path="/recipes/edit/:recipeId(\d+)" exact>
          {isLoggedIn ? <RecipeEdit /> : <Redirect to="/login" />}
        </Route>

        <Route path="/recipes/create" exact>
          {isLoggedIn ? <RecipeForm /> : <Redirect to="/login" />}
        </Route>

        <Route path="/login">
          <Login />
        </Route>

        <Route path="/register">
          <Register />
        </Route>
      </Switch>
    </main>
  );
}
