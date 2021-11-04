import React, { useEffect, useState } from "react";
import { CircularProgressbar } from "react-circular-progressbar";
import "react-circular-progressbar/dist/styles.css";
import authService from "../api-authorization/AuthorizeService";

export default function VariableCosts(props) {
  const [variableCosts, setVariableCosts] = useState([]);

  useEffect(() => {
    async function fetchVariableCosts() {
      const token = await authService.getAccessToken();
      const response = await fetch(
        "api/variablecostcategory/forcurrentbudget",
        {
          headers: !token ? {} : { Authorization: `Bearer ${token}` },
        }
      );
      const data = await response.json();
      console.log(data);
      setVariableCosts(data);
    }

    fetchVariableCosts();
  }, []);

  function percentage(partialValue, totalValue) {
    return ((100 * partialValue) / totalValue).toFixed(2);
  }

  return (
    <div>
      <label>Rörliga Kostnader</label>

      {variableCosts.map((x, i) => (
        <div key={i}>
          <label className="variablecosts__name_label">{x.name}</label>
          <div
            className="variablecosts__progressbar_div"
            style={{ width: 80, height: 75 }}
          >
            <CircularProgressbar
              value={percentage(x.spent, x.toSpend)}
              text={`${percentage(x.spent, x.toSpend)}%`}
            />
          </div>
        </div>
      ))}
    </div>
  );
}
