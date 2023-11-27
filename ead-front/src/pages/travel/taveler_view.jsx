import React, { useState, useEffect } from "react";
import Card from "react-bootstrap/Card";
import { useNavigate } from "react-router-dom";
import Button from "react-bootstrap/Button";
import axios from "axios";
import Swal from "sweetalert2";



//VIEW Traveler accounts
const TView = () => {
  const [acc, setAcc] = useState([]);
  const navigate = useNavigate();

  const getData = () => {
    axios
      .get("http://localhost:44334/api/TravelerProfile?isActive=true")
      .then((response) => {
        const fetchedData = response.data;
        setAcc(fetchedData);
      })
      .catch((error) => {
        console.error("Error fetching data:", error);
      });
  };
  useEffect(() => {
    getData();
  }, []);

  const handleDelete = (itemId) => {
    console.log(itemId);
    axios
      .delete(`http://localhost:44334/api/TravelerProfile/${itemId}`)
      .then((response) => {
        Swal.fire({
          icon: "success",
          title: "Success!",
          text: "Account Deleted.",
        }).then(() => {
          getData();
        });
      })
      .catch((error) => {
        Swal.fire({
          icon: "error",
          title: "Error!",
          text: "Failed.",
        });
      });
  };

  return (
    <div
      style={{ marginTop: "150px" }}
      className="d-flex flex-column justify-content-center align-items-center"
    >
      <h3>All Accounts</h3>
      <br />
      {acc &&
        acc.map((item) => (
          <Card
            className="shadow"
            style={{ height: "380px", width: "500px", marginBottom: "100px" }}
            key={item.id}
          >
            <Card.Body>
              <div
                className="d-flex flex-column justify-content-center align-items-center"
                style={{ marginTop: "5px" }}
              >
                <h5>First Name: {item.firstName}</h5>
                <br />
                <h5>Last Name: {item.lastName}</h5>
                <br />
                <h5>NIC: {item.nic}</h5>
                <br />
                <Button
                  className="btn btn-blue"
                  onClick={() => navigate(`/tupp/${item.nic}`)}
                >
                  Update Account
                </Button>
                <br />
                <Button
                  className="btn btn-red"
                  onClick={() => handleDelete(item.id)}
                >
                  Delete Account
                </Button>
              </div>
            </Card.Body>
          </Card>
        ))}
      <div style={{ marginBottom: "600px" }}></div>
    </div>
  );
};

export default TView;
