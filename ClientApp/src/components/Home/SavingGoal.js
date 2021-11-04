import React, { useEffect, useState } from 'react'

export default function SavingGoal(props) {
    const [savingGoal, setSavingGoal] = useState([])
console.log(props);
    useEffect(() => {
        if (props.data) {
            setSavingGoal(props.data)
        }
    }, [props.data])

    return (

        <div className="savinggoal__fullpage">
            <div className="savinggoal__headerdiv">
                <label className="savinggoal__title_label">Sparmål</label>
            </div>


            <div className="savinggoal__contentdiv">

                {savingGoal.map((x, i) => (
                    <div key={i} className="savinggoal__divformap">
                        <label className="savinggoal__content_label">{x.name}</label> <label className="savinggoal__content_label2"> Att Spara: {x.toSave} kr</label> <label className="savinggoal__content_label3">Sparat: {x.saved} kr</label>
                    </div>
                ))}

            </div>


        </div>
    )
}
