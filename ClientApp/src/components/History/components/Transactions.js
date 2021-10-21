import React from "react";

const Transactions = () => {
    return (
        <>
            <div className="transaction-inputs">
                <form>
                    <label>Datum från:</label>
                    <input type="date" className="filter-input" />
                    <label>Datum till:</label>
                    <input type="date" className="filter-input" />
                    <label>Kategori:</label>
                    <input type="text" className="filter-input" placeholder="Välj" />
                    <button className="filter-btn">Filtrera</button>
                </form>
            </div>
            <input type="text" className="search-table" placeholder="Sök"></input>
            <div className="table-wrapper">
                <table className="transactions-table">
                    <thead>
                        <tr>
                            <th>Namn</th>
                            <th>Pris</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Mat</td>
                            <td>500</td>
                        </tr>
                        <tr>
                            <td>Glass</td>
                            <td>25</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </>
    );
};

export default Transactions;
