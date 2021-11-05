import React, { useState, useEffect } from "react";
import "../History/HistoryPage.css";
import Budgets from "./components/Budgets";
import Transactions from "./components/Transactions";
import authService from '../api-authorization/AuthorizeService';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    NavLink
} from "react-router-dom";

export default function HistoryPage() {
    const [budgetData, setBudgetData] = useState([]);
    const [purchaseData, setPurchaseData] = useState([]);

    useEffect(() => {
        async function fetchBudgets() {
            const token = await authService.getAccessToken();
            const response = await fetch('api/budget', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            });
            const data = await response.json();
            console.log(data)
            setBudgetData(data[data.length - 1])
        }
        fetchBudgets()
    }, []);

    useEffect(() => {
        async function fetchPurchases() {
            const token = await authService.getAccessToken();
            const response = await fetch('api/purchase', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            });
            const data = await response.json()
            console.log(data)
            setPurchaseData(data)
        }
        fetchPurchases()
    }, []);

    return (
        <>
            <Router>
                <div className="__container">
                    <nav className="__history-nav">
                        <ul>
                            <li>
                                <NavLink to="/history" className="__history-nav-btn">
                                    Budgets
                                </NavLink>
                            </li>
                            <div className="__line1"></div>
                            <li>
                                <NavLink to="/transactions" className="__history-nav-btn">
                                    Transactions
                                </NavLink>
                            </li>
                        </ul>
                        <hr />
                    </nav>
                    <Switch>
                        <Route exact path="/history">
                            {budgetData ? < Budgets data={budgetData} /> : "Loading..."}
                        </Route>
                        <Route exact path="/transactions">
                            {purchaseData ? <Transactions data={purchaseData} /> : "Loading..."}
                        </Route>
                    </Switch>
                </div>
            </Router>
        </>
    );
}
