import React, { useState, useEffect } from "react";

const Transactions = (props) => {
    const [transaction, setTransaction] = useState([])

    useEffect(() => {
        if (props.data) {
            setTransaction(props.data)
        }
    }, [props.data])

    return (
        <>
            <div className="__transaction-inputs">
                <form className="__transaction-form">
                    <label>Datum från:</label>
                    <input type="date" className="__filter-input" />
                    <label>Datum till:</label>
                    <input type="date" className="__filter-input" />
                    <button className="__filter-btn">Filtrera</button>
                </form>
            </div>
            <input type="text" className="__search-table" placeholder="Sök"></input>
            <div className="__table-wrapper">
                <div className="__transaction-headers">
                    <h3>Namn</h3>
                    <h3>Pris</h3>
                </div>
                {transaction.reverse().slice(0, 5).map((x, i) =>
                    <div key={i} className="__transactions-table">
                        <p>{x.name}</p>
                        <p>{x.price} kr</p>
                    </div>
                )}
            </div>
        </>
    );
};

export default Transactions;
