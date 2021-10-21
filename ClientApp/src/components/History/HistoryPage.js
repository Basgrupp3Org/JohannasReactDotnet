import React from "react";
import "../History/HistoryPage.css";
import Budgets from "./components/Budgets";
import Transactions from "./components/Transactions";
import {
    BrowserRouter as Router,
    Switch,
    Route,
    NavLink,
    useParams,
    useRouteMatch,
} from "react-router-dom";

export default function HistoryPage() {
    let { path, url } = useRouteMatch();

    return (
        <>
            <Router>
                <div className="container">
                    <nav className="history-nav">
                        <ul>
                            <li>
                                <NavLink to="/history" className="history-nav-btn">
                                    Budgets
                                </NavLink>
                            </li>
                            <div className="line1"></div>
                            <li>
                                <NavLink to="/transactions" className="history-nav-btn">
                                    Transactions
                                </NavLink>
                            </li>
                        </ul>
                        <hr />
                    </nav>

                    <Switch>
                        <Route exact path="/history">
                            <Budgets />
                        </Route>
                        <Route exact path="/transactions">
                            <Transactions />
                        </Route>
                    </Switch>
                </div>
            </Router>
        </>
    );
}
