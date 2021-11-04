import React, { useEffect, useState } from "react";
import "./HomePage.css";
import Income from "./Income";
import FixedCosts from "./FixedCosts";
import SavingGoal from "./SavingGoal";
import Unbudgeted from "./Unbudgeted";
import VariableCosts from "./VariableCosts";

export default function Budget(props) {
  console.log(props);
  return (
    <div>
      <label className="budget__centercontent">{props.data.name}</label>
      <p className="budget__centercontent" className="budget__dates">
        {props.data.startDate} - {props.data.endDate}{" "}
      </p>
      <div className="budget__headlines_div">
        <Income data={props.data} />
        <FixedCosts />
        <SavingGoal data={props.savingData} />
        <VariableCosts />
        <Unbudgeted data={props.data} />
      </div>
    </div>
  );
}
