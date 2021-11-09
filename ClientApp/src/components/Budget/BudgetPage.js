
import React, { useState, useEffect} from "react";
import authService from "../api-authorization/AuthorizeService"
import {ControlledAccordions} from "./Accordion";
import CreateCategoryModal from "./CreateCategoryModal";
import {Accordions} from './Accordion';
import CreateVariableCostModal from "./CreateVariableCostModal";
import './BudgetPage.css'


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
        
        <div className="budgetpage__fullpage_div">
            <div className="budgetpage__leftside_div">
            <Accordions/> 
            </div>
            
            <div className="budgetpage__bottomtopleft_div">
            <CreateCategoryModal />
            <CreateVariableCostModal />
            </div>
            

        

            
        </div>
    )
    
    




       


}