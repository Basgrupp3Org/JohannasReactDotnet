import React, { useState, useEffect } from 'react'
import authService from '../api-authorization/AuthorizeService'
import './HomePage.css'

export default function FixedCosts(props) {

    const [total, setTotal] = useState();
    const [fixedCosts, setFixedCosts] = useState([])

    useEffect  (() => {
        async function fetchFixedCosts() {
            const token = await authService.getAccessToken();
            const response = await fetch('api/fixedcostcategory', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            });
            const data = await response.json()
            console.log(data)
            setFixedCosts(data)
        }

        fetchFixedCosts()

    }, [])
    useEffect(() => {
        if (fixedCosts) {
            let localTotal = 0;
           fixedCosts.forEach((element, i) => localTotal += (element.cost));
            setTotal(localTotal);
        }
    }, [fixedCosts])




    return (
        <div className="fixedcosts__fullpage">
            <div className="fixedcosts__headline_div">
                <label >Fasta Utgifter</label>
            </div>
            <div className="fixedcosts__content">
                <label className="fixedcosts__labels">Total: {total} kr</label>
                 {fixedCosts.length ? fixedCosts.map((x, i) => {
                     return <div key={i}>
                    <label className="fixedcosts__labels">{x.name}: {x.cost} kr</label>
                  
                </div>
                 }) : null}
            </div>
        </div>
    )
}
