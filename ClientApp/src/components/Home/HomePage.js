import React, { useEffect, useState } from 'react'
import authService from '../api-authorization/AuthorizeService'


export default function HomePage() {
    const [budgetData, setBudgetData] = useState([]);

    useEffect(() => {

        async function fetchMyAPI() {
           

            const token = await authService.getAccessToken();
            const response = await fetch('api/Budget', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            });
            const data = await response.json();
            setBudgetData(data)
        }

        fetchMyAPI()


    }, []);

    return (
        <div className="homepage__fullPage_div">

            <div>{budgetData ? "finns" : "finns inte"}</div>
        </div>


    )
}
