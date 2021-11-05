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
                <form>
                    <label>Datum från:</label>
                    <input type="date" className="__filter-input" />
                    <label>Datum till:</label>
                    <input type="date" className="__filter-input" />
                    <label>Kategori:</label>
                    <input type="text" className="__filter-input" placeholder="Välj" />
                    <button className="__filter-btn">Filtrera</button>
                </form>
            </div>
            <input type="text" className="__search-table" placeholder="Sök"></input>
            <div className="__table-wrapper">
                {/* <table className="__transactions-table">
                    <thead>
                        <tr>
                            <th>Namn</th>
                            <th>Pris</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>{props.data.name}</td>
                            <td>{props.data.price}</td>
                        </tr>
                        <tr>
                            <td>{props.data.name}</td>
                            <td>{props.data.price}</td>
                        </tr>
                    </tbody>
                </table> */}

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
