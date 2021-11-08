
import React, { useState, useEffect} from "react";
import authService from "../api-authorization/AuthorizeService"
import {ControlledAccordions} from "./Accordion";
import CreateCategoryModal from "./CreateCategoryModal";
import CreateBudgetModal from './CreateBudgetModal';
import {Accordions} from './Accordion';


export default function BudgetPage() {
    const [budgetData, setBudgetData] = useState([]);
    // const [variableCosts, setVariableCosts] = useState([]);
    // const [fixedCosts, setFixedCosts] = useState([]);

    useEffect(() => {
       async function fetchMyAPI() {
           const token = await authService.getAccessToken();
           const response = await fetch('api/budget', {
               headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
           });
           const data = await response.json();
           console.log(data)
           setBudgetData(data)
       }

       fetchMyAPI()

    }, []);


    
   
    return(
        <div>
            <Accordions/>
        </div>
    )
    
    




       


}