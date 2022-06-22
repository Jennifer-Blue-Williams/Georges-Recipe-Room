import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { useParams } from "react-router-dom";
import { editRecipeById } from "../../modules/recipeManager";
import { FormGroup, Input, Label, Button, Form } from "reactstrap";
import { getAllTags } from "../../modules/tagManager";

const EditRecipe = () => {
  const history = useHistory();
  const { recipeId } = useParams();
  const emptyRecipe = {
    Id: recipeId,
    Title: "",
    Directions: "",
    InsImageUrl: "",
    SelectedTagIds: new Set(),
  };
  const [recipe, setRecipe] = useState(emptyRecipe);
  const [tags, setTags] = useState([]);

  const getTags = () => {
    getAllTags().then((tags) => setTags(tags));
  };

  useEffect(() => {
    getTags();
  }, []);

  //   useEffect(() => {
  //     getRecipeToEdit(recipeId).then((recipe) => {
  //       recipe.SelectedTagIds = new Set(recipe.selectedTagIds);
  //       setRecipe(recipe);
  //     });
  //   }, recipeId);

  const handleInputChange = (evt) => {
    const value = evt.target.value;
    const key = evt.target.id;

    const recipeCopy = { ...recipe };

    recipeCopy[key] = value;
    setRecipe(recipeCopy);
  };

  const handleSave = (evt) => {
    evt.preventDefault();
    const recipeCopy = { ...recipe };
    recipeCopy.SelectedTagIds = Array.from(recipeCopy.SelectedTagIds);
    editRecipeById(recipeCopy).then((newRecipe) => {
      history.push(`/recipes/${newRecipe.id}`);
    });
  };

  const handleTagCheck = (evt) => {
    const recipeCopy = { ...recipe };
    const tagId = parseInt(evt.target.value);

    if (recipeCopy.SelectedTagIds.has(tagId)) {
      recipeCopy.SelectedTagIds.delete(tagId);
    } else {
      recipeCopy.SelectedTagIds.add(tagId);
    }

    setRecipe(recipeCopy);
  };

  return (
    <Form>
      <FormGroup>
        <Label for="title">Title</Label>
        <Input
          type="text"
          name="title"
          id="title"
          placeholder="Title"
          value={recipe.title}
          onChange={handleInputChange}
        />
      </FormGroup>
      <FormGroup>
        <Label for="Directions">Directions</Label>
        <Input
          type="text"
          name="directions"
          id="directions"
          placeholder="directions"
          value={recipe.directions}
          onChange={handleInputChange}
        />
      </FormGroup>
      <FormGroup>
        <Label for="Instructions">ImageUrl</Label>
        <Input
          type="text"
          name="imageUrl"
          id="imageUrl"
          placeholder="imageUrl"
          value={recipe.imageUrl}
          onChange={handleInputChange}
        />
      </FormGroup>

      <div>
        Select all that apply:
        {tags.map((tag) => {
          return (
            <div>
              <input
                type="checkbox"
                value={tag.id}
                onChange={(evt) => handleTagCheck(evt)}
              />
              <label>{tag.label}</label>
            </div>
          );
        })}
      </div>
      <Button className="btn btn-primary" onClick={handleSave}>
        Save Changes
      </Button>
    </Form>
  );
};

export default EditRecipe;
