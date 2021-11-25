import React, { useEffect, useState } from 'react'
import authService from '../api-authorization/AuthorizeService'
import Budget from './Budget'
import './HomePage.css'
import LastTransaction from './LastTransaction'
import BigSavingGoal from './BigSavingGoal'


export default function HomePage() {
    const [budgetData, setBudgetData] = useState([]);
    const [purchaseData, setPurchaseData] = useState([]);
    const [savingData, setSavingData] = useState([]);
    useEffect(() => {
        async function fetchMyAPI() {
            const token = await authService.getAccessToken();
            const response = await fetch('api/budget', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            });
            const data = await response.json();
            console.log(data)
            setBudgetData(data[data.length - 1])
        }

        fetchMyAPI()

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
        <div className="homepage__fullPage_div">

            <div className="homepage__topPart_div">
                {budgetData ? <Budget data={budgetData} savingData={savingData} /> : "Laddar data.."}

            </div>
            <hr />
            <div className="homepage__LowerPart_div">
               <div className="homepage__LeftLowerPart_div">
           {purchaseData ? <LastTransaction data={purchaseData} /> : "Laddar data.."}
               </div>
               <div className="homepage__RightLowerPart_div">
                  {savingData ? <BigSavingGoal data={savingData} /> : "Laddar data..."}
                </div>
            </div>
        </div>


    )
}
