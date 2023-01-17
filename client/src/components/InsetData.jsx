import React, { useEffect } from 'react';
import axios from 'axios';
import { useState } from 'react';

function InsetData() {

    const baseurl = "http://localhost:5136/api"

    const [apiData, setApiData] = useState({ username: "", course: "", courseDate: "" });
    const [submitted, setSubmitted] = useState(false);
    const [error, setError] = useState(false);

    const insertData = (event) => {
        event.preventDefault();
        if (apiData.username === "" || apiData.course === "" || apiData.courseDate === "") {
            setError(true);
            setSubmitted(false);
        }
        else {
            setSubmitted(true);
            axios.post(baseurl + "/user", apiData);
        }
    }

    const successMessage = () => { if (submitted) { return (<p> Data inserted successfully</p>) } }
    const errorMessage = () => { if (error) { return (<p>Every fileds are required</p>) } }

    const handleChange = (event) => {
        const { name, value } = event.target
        setApiData({ ...apiData, [name]: value })
        setSubmitted = (false);
    }

    return (
        <section>
            <h1>Insert Data</h1>
            <div className="messages">
                {errorMessage()}
                {successMessage()}
            </div>
            <form method="POST" onSubmit={insertData}>
                <label htmlFor="username">Username</label>
                <input type="text" name="username" id="username" onChange={handleChange} />
                <br />
                <label htmlFor="course">Course</label>
                <input type="text" name="course" id="course" onChange={handleChange} />
                <br />
                <label htmlFor="courseDate">Course Date</label>
                <input type="text" name="courseDate" id="courseDate" onChange={handleChange} />
                <br />
                <button type="submit">Submit</button>
            </form>
        </section>
    )
}

export default InsetData