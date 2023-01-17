import React, { useEffect } from 'react';
import axios from 'axios';
import { useState } from 'react';

function ListData() {
    const baseurl = "http://localhost:5136/api"

    const [apiData, setApiData] = useState({ username: "", course: "", courseDate: "" });
    const [submitted, setSubmitted] = useState(false);
    const [error, setError] = useState(false);

    const listData = (event) => {
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

    const tableData = () => {
        return userData.map((val) => {
          return (
            <tr key={val.id}>
              <td>{val.id}</td>
              <td>{val.username}</td>
              <td>{val.email}</td>
              <td>{val.password}</td>
              <td>
                <button type='button'
                  onClick={() => {
                    // alert("Delete Clicked");
                    deleteData(val.id);
                  }}
                >
                  Delete
                </button>
              </td>
              <td>
                <button type='button'
                  onClick={() => {
                    alert("Update Clicked");
                    // updateData(val.id);
                  }}
                >
                  Update
                </button>
              </td>
            </tr>
          );
        });
      }

    return(
        <section>
          <div>
            <h2>List Data</h2>
            <table>
              <thead>
                <tr>
                  <th>id</th>
                  <th>username</th>
                  <th>course</th>
                  <th>courseDate</th>
                </tr>
              </thead>
              <tbody>
                {listData()}
              </tbody>
            </table>
          </div>
        </section>
      );
}

export default ListData