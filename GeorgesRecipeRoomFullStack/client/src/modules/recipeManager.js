import { getToken } from "./authManager";

const _apiUrl = "/api/Recipe";

export const getAllRecipes = () => {
  return getToken().then((token) => {
    return fetch(_apiUrl, {
      method: "GET",
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }).then((resp) => {
      if (resp.ok) {
        return resp.json();
      } else {
        throw new Error("An error occurred retrieving recipes");
      }
    });
  });
};

export const getRecipeDetailsById = (id) => {
  return getToken().then((token) => {
    return fetch(`${_apiUrl}/${id}`, {
      method: "GET",
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }).then((resp) => {
      if (resp.ok) {
        return resp.json();
      } else {
        throw new Error("An error occured retrieving recipe details");
      }
    });
  });
};

export const deleteRecipe = (id) => {
  return getToken().then((token) => {
    return fetch(`${_apiUrl}/${id}`, {
      method: "DELETE",
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
  });
};

export const postRecipe = (recipe) => {
  return getToken().then((token) => {
    return fetch(_apiUrl, {
      method: "POST",
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json",
      },
      body: JSON.stringify(recipe),
    }).then((res) => {
      if (res.ok) {
        return res.json();
      } else {
        throw new Error("An error occured posting the recipe");
      }
    });
  });
};

export const getRecipeToEdit = (id) => {
  return getToken().then((token) => {
    return fetch(`${_apiUrl}/ToEdit/${id}`, {
      method: "GET",
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }).then((resp) => {
      if (resp.ok) {
        return resp.json();
      } else {
        throw new Error("An error occured retrieving recipe details");
      }
    });
  });
};

export const editRecipeById = (recipe) => {
  return getToken().then((token) => {
    return fetch(_apiUrl, {
      method: "PUT",
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json",
      },
      body: JSON.stringify(recipe),
    }).then((resp) => {
      if (resp.ok) {
        return resp.json();
      } else {
        throw new Error(
          "An unknown error occurred while trying to save changes to recipe."
        );
      }
    });
  });
};
