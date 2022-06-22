import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { FormGroup, Input, Label, Button, Form } from "reactstrap";
import { postRecipe } from "../../modules/recipeManager";
import { getAllTags } from "../../modules/tagManager";

const RecipeForm = () => {
  const history = useHistory();

  const emptyRecipe = {
    Title: "",
    Directions: "",
    ImageUrl: "",
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
    postRecipe(recipeCopy).then((newRecipe) => {
      history.push(`/recipes/${newRecipe.id}`);
    });
  };

  const SubmitButton = () => {
    return (
      <Button className="btn btn-primary" onClick={handleSave}>
        Submit
      </Button>
    );
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
    <>
      <Form>
        <FormGroup>
          <Label for="Title">Title</Label>
          <Input
            type="text"
            name="Title"
            id="Title"
            placeholder="Title"
            value={recipe.Title}
            onChange={handleInputChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="Directions">Directions</Label>
          <Input
            type="text"
            name="Directions"
            id="Directions"
            placeholder="Directions"
            value={recipe.Directions}
            onChange={handleInputChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="ImageUrl">Food Image URL</Label>
          <Input
            type="text"
            name="ImageUrl"
            id="ImageUrl"
            placeholder="Food Image URL here"
            value={recipe.ImageUrl}
            onChange={(changeEvent) => {
              const copy = { ...recipe };
              copy.ImageUrl = changeEvent.target.value;
              setRecipe(copy);
            }}
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
        <SubmitButton />
      </Form>
    </>
  );
};

export default RecipeForm;
