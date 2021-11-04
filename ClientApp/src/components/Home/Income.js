import React, { useEffect, useState } from 'react'
import './HomePage.css'

export default function Income(props) {
    const [income, setIncome] = useState([])
    console.log(income)

    useEffect(() => {
        if (props.data.income) {
            setIncome(props.data.income)
        }
    }, [props.data.income])


    return (
        <div className="income__fullpage">
            <div className="income__headerdiv">
                <label>Inkomster</label>
            </div>
            <div className="income__contentdiv">
                <label>{income}</label>
            </div>
            
        </div>
    )

}
