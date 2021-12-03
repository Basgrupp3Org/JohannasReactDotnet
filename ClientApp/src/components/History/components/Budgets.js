import React, { useState, useEffect } from "react";
import HistorySidebar from "./HistorySidebar";
import BudgetData from "./BudgetData";
import Budget from "../../Home/Budget";
import authService from "../../api-authorization/AuthorizeService";


export default function Budgets(props) {
    const [activeBudget, setActiveBudget] = useState([]);
    const [budgets, setBudgets] = useState([]);
    const [savingData, setSavingData] = useState([]);
    console.log(props);

    useEffect(() => {
        async function fetchBudgets() {
            const token = await authService.getAccessToken();
            const response = await fetch('api/budget', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            });
            const data = await response.json();
            console.log(data)
            setBudgets(data)
        }
        fetchBudgets()
    }, []);

    useEffect(() => {
        async function fetchSavingGoals() {
            const token = await authService.getAccessToken();
            const response = await fetch('api/savinggoal', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            });
            const data = await response.json()
            console.log(data)
            setSavingData(data)
        }

        fetchSavingGoals()

    }, []);

    useEffect(() => {
        setActiveBudget(props.data)
    }, [])

    const changeBudget = (x) => {
        // for (let i = 0; i < budgets.length; i++) {
        //     if (i === x) {
        //         setActiveBudget(budgets[i])
        //         setSavingData(props.savingData)
        //         console.log(budgets[i]);
        //     }

        // }
        setActiveBudget(budgets[x])
    }

    return (
        <>
            <div className="__history-sidebar">
                {budgets.length ? budgets.map((x, i) => {
                    return <div key={i}>

                        <div onClick={() => changeBudget(i)} className="__budget-btn">
                            {x.name}
                        </div>


                    </div>
                }) : null}

                {/* <ul>
                    <li>
                        <button className="__budget-btn" onClick={() => active ? setActive("") : setActive("FirstCard")}>2021</button>
                        {active === "FirstCard" && <HistorySidebar data={BudgetData} cardIndex={0} />}
                    </li>
                    <li>
                        <button className="__budget-btn" onClick={() => active ? setActive("") : setActive("SecondCard")}>2020</button>
                        {active === "SecondCard" && <HistorySidebar data={BudgetData} cardIndex={1} />}
                    </li>
                    <li>
                        <button className="__budget-btn" onClick={() => active ? setActive("") : setActive("ThirdCard")}>2019</button>
                        {active === "ThirdCard" && <HistorySidebar data={BudgetData} cardIndex={2} />}
                    </li>
                </ul> */}

            </div>
            <div className="__line2"></div>
            <div className="__history-table">
                <Budget data={activeBudget} savingData={savingData} />
            </div>
        </>
    );
};
