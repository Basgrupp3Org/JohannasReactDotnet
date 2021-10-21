import React, { useEffect, useState } from 'react'
import authService from '../api-authorization/AuthorizeService'
import Budget from './Budget'


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

            <div className="homepage__topPart_div">
                {budgetData ? <Budget data={budgetData} /> : "Laddar data.."}

            </div>
            <hr />
            <div className="homepage__LowerPart_div">
                <div className="homepage__LeftLowerPart_div">
                    {/*{purchaseData ? <LastTransaction data={purchaseData} /> : "Laddar data.."}*/}
                </div>
                <div className="homepage__RightLowerPart_div">
                    {/*{budgetData ? <BigSavingGoal data={budgetData} /> : "Laddar data..."}*/}
                </div>
            </div>
        </div>


    )
}
