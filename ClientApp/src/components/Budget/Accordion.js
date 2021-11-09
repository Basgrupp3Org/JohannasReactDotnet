import React, {useState} from 'react';
import { ExpandMore } from '@material-ui/icons';
import {Accordion,AccordionSummary, AccordionDetails } from '@material-ui/core';
import { AccordionActions, Button, Divider } from '@material-ui/core';
import authService from "../api-authorization/AuthorizeService"

// import DatePicker from "react-datepicker";
// import "react-datepicker/dist/react-datepicker.css";





 export function Accordions() {


    
    const [budgetName, setBudgetName] = useState("");
    const [income, setIncome] = useState(0);
    const [endDate, setEndDate] = useState("");
    const [startDate, setStartDate] = useState("");
    const [expandedPanel, setExpandedPanel] = useState(null);
  
    const handleAccordionChange = (panel) => (event, isExpanded) => {
      console.log({ event, isExpanded });
      setExpandedPanel(isExpanded ? panel : false);
    };
// console.log(budgetName)    
// console.log(income)
// console.log(endDate)

const handleIncome = (e) => {
    setIncome(e.target.value)
}


async function PostBudget() {
    const requestObject = {
        Income: income,
        StartDate: startDate,
        EndDate: endDate,
        Name: budgetName,
    }
    const token = await authService.getAccessToken();
    await fetch('api/budget', {
        method: 'POST',
        headers: !token ? {} : { 'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'},
        body: JSON.stringify(requestObject)
    }).then(data => { console.log(data) })
    .catch((err) => {
        console.error(err);
    })
    
    
}

    return (
      <div className="Accordions">
                                        {/* Här börjar panel1(Date) */}
        <Accordion expanded={expandedPanel === 'panel1'} onChange={handleAccordionChange('panel1')} >
  
          <AccordionSummary className="AccordionSummary" expandIcon={<ExpandMore />}
          aria-label="Expand"
          aria-controls="additional-actions1-content"
          id="additional-actions1-header"
          >
              
          Date: {startDate}  -  {endDate}

          </AccordionSummary>
  
          {/* <AccordionDetails>
          Det som skrev i input
          </AccordionDetails> */}
           
          <input
          type="date"
          value={startDate}
          onChange={e => setStartDate(e.target.value)}
          />

          <input
          type="date"
          value={endDate}
          onChange={e => setEndDate(e.target.value)}
          />

          

      
       
                            
        </Accordion>
                                        {/* Här börjar panel2(Income) */}
        <Accordion expanded={expandedPanel === 'panel2'} onChange={handleAccordionChange('panel2')}  >
  
          <AccordionSummary className="AccordionSummary" expandIcon={<ExpandMore />}
           aria-label="Expand"
           aria-controls="additional-actions2-content"
           id="additional-actions2-header"
          >
              
              Income: {income}:-


          </AccordionSummary>
           
          {/* <AccordionDetails>

              det som skrevs i input
          
          </AccordionDetails> */}
          <input
          
              placeholder="Amount"
              type="text"
              value= {income}
              onChange={ e => setIncome(e.target.value)}
            
            />
        </Accordion>
                                    {/* Här börjar panel3(Unbudgeted) */}
        <Accordion expanded={expandedPanel === 'panel3'} onChange={handleAccordionChange('panel3')}  >
  
          <AccordionSummary className="AccordionSummary" expandIcon={<ExpandMore />}>
            Budget name:         {budgetName}
          </AccordionSummary>
  
          {/* <AccordionDetails>
          Det som skrev i input
          </AccordionDetails> */}

          <input className="input"
          
              placeholder="Name"
              type="Text"
              value= {budgetName}
              onChange={ e => setBudgetName(e.target.value)}
           
              
            />
         
        </Accordion>

  <button className="SubmitBudget" onClick={PostBudget}>
      Save Budget
      </button>
      </div>
    );
  }
