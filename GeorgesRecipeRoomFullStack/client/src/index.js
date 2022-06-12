import App from "./App";
import { createRoot } from "react-dom/client";
import firebase from "firebase/app";

const firebaseConfig = {
  apiKey: process.env.REACT_APP_API_KEY,
};
firebase.initializeApp(firebaseConfig);

const container = document.getElementById("root");
const root = createRoot(container);
root.render(<App tab="home" />);
