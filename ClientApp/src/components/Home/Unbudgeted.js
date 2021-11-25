import React, { useEffect, useState } from 'react'


export default function Unbudgeted(props) {
    const [unbudgeted, setUnbudgeted] = useState([])

    useEffect(() => {
        if (props.data.unbudgeted) {
            setUnbudgeted(props.data.unbudgeted)
        }
    }, [props.data.unbudgeted])

    return (
        <div>
            <label className="unbudgeted__headlines_label">Obudgeterat</label>

            <label>{unbudgeted}</label>
        </div>
    )
}
