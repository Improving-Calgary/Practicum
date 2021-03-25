import SearchBar from "../components/searchbar.component";
import renderer from "react-test-renderer";
import React from "react";

describe("When drawing search bar", () => {
  test("renders correctly", () => {
    let tree = renderer.create(<SearchBar onGetVehicles={() => {}} />).toJSON();

    expect(tree).toMatchSnapshot();
  });
});
