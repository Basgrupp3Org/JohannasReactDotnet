
import React, { useState, useEffect} from "react";
import authService from "../api-authorization/AuthorizeService"
import {ControlledAccordions} from "./Accordion";
import {Accordions} from './Accordion';
import './BudgetPage.css'



export default function BudgetPage() {
    const [budgetData, setBudgetData] = useState([]);
    // const [variableCosts, setVariableCosts] = useState([]);
    // const [fixedCosts, setFixedCosts] = useState([]);

   
    

    
   
    return(
        
        <div className="budgetpage__fullpage_div">
            <div className="budgetpage__leftside_div">
            <Accordions/> 
            </div>
            
            
            
        

            
        </div>
    )
    
    




       


}