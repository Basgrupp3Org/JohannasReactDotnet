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
    const [savingData, setSavingData] = useState([]);

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

    return (
        <>
            <Router>
                <div className="__container">
                    <nav className="__history-nav">
                        <div className="__history-nav-items">
                            <NavLink to="/history" className="__history-nav-btn">
                                Budgets
                            </NavLink>
                            {/* <div className="__line1"></div> */}
                            <NavLink to="/transactions" className="__history-nav-btn">
                                Transactions
                            </NavLink>
                        </div>
                        <hr />
                    </nav>
                    <Switch>
                        <Route exact path="/history">
                            {budgetData ? < Budgets data={budgetData} savingData={savingData} /> : "Loading..."}
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
