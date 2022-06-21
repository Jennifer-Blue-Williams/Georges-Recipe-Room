import { getToken } from "./authManager";

const _apiUrl = "/api/Tag";

export const getAllTags = () => {
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
        throw new Error("An error occurred retrieving tags");
      }
    });
  });
};
