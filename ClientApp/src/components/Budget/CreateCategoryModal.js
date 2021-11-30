import "./BudgetPage";
import React, { useState, useEffect, useContext } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Modal from "@material-ui/core/Modal";
import { Input } from "@material-ui/core";
import authService from "../api-authorization/AuthorizeService"



function getModalStyle() {
    const top = 50;
    const left = 50;

    return {
        top: `${top}%`,
        left: `${left}%`,
        transform: `translate(-${top}%, -${left}%)`,
    };
}

const useStyles = makeStyles((theme) => ({
    paper: {
        position: "absolute",
        width: 800,
        backgroundColor: '#2A9D8F',
        border: "2px solid #000",
        boxShadow: theme.shadows[5],
        padding: theme.spacing(2, 4, 3),
    },
}));

function CreateCategoryModal() {
    const classes = useStyles();
    const [modalStyle] = React.useState(getModalStyle);
    const [summary, setSummary] = useState("");
    const [open, setOpen] = useState(false);
    const [name, setName] = useState("");
    const [cost, setCost] = useState("");







    // reset fields and close modal 
    const ResetFixedCategory = (data) => {

        setName('')
        setCost('')

        setOpen(false)
        window.alert('Your Category has succesfully been uploaded!')
    }

    const handleBudgetChange = (e) => {
       
       setCost(e.target.value)

       
    }

    async function PostFixedCategory() {
        const requestObject = { 
            Name: name,
            Cost : cost,
        }

        const token = await authService.getAccessToken();
        await fetch('api/fixedcostcategory', {
            method: 'POST',
            headers: !token ? {} : {'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'},
        body: JSON.stringify(requestObject)
        }).then(data => {console.log(data) })
        .then(ResetFixedCategory())
        .catch((err) => {
            console.error(err);
        })

    }



    // const setPurchaseName1 = (e) => {
    //     if (purchaseRegex.exec(e.target.value)) {
    //         setSummary("");
    //         setCategoryName(e.target.value);
    //     } else {
    //         setSummary("no numbers allowed");
    //     }
    // };

    // const purchaseRegex = new RegExp("^[A-ZÅÄÖÈa-zåäöé ]{0,29}$");

    return (
        <div className="rpm">
            <button className="btn2" onClick={() => setOpen(true)}>Lägg till en fast Kategori</button>

            <Modal open={open} onClose={() => setOpen(false)}>
                <div style={modalStyle} className={classes.paper}>
                    <form className="rpm__registerpurchase">
                        <center>
                            <h2 className="rpm__purchasetext">Skapa Kategori</h2>
                        </center>
                        {summary}
                        <input
                            type="text"
                             className="modalinputs"
                            placeholder="Category Name"
                            value={name}
                            onChange={e => setName(e.target.value)}
                            required
                        ></input>


                           <input
                            type="number"
                             className="modalinputs"
                            placeholder="Category Cost"
                            value={cost}
                            onChange={e => setCost(e.target.value)}
                            required
                        ></input>


                        <button
                            variant="contained"
                            className="modalinputssubmit"
                             onClick={PostFixedCategory}
                        >
                            Skapa
                        </button>
                    </form>
                </div>
            </Modal>
        </div>
    );
}


export default CreateCategoryModal;
