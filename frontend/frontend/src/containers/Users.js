import React from "react";
import { Link } from "react-router-dom";
import { Table, Button } from "react-bootstrap";

function Users({ users }) {
  return (
    <div>
      <Table striped bordered condensed hover responsive>
        <thead>
          <tr>
            <th>UserId</th>
            <th>Username</th>
            {/* <th>Password</th>
            <th>Email</th>
            <th>Full Name</th>
            <th>Date Of Birth</th>
            <th>Address</th>
            <th>Phone</th> */}
          </tr>
        </thead>
        <tbody>
          {users.map((user) => {
            return (
              <tr key={user.id}>
                <td>{user.id}</td>
                <td>{user.username}</td>
                <td>
                  <Link to={`/user/${user.id}`}>
                    <Button variant="info" onClick={() => {}}>
                      Edit
                    </Button>
                  </Link>
                </td>
                {/* <td>{user.password}</td>
                <td>{user.email}</td>
                <td>{user.fullname}</td>
                <td>{user.dob}</td>
                <td>{user.address}</td>
                <td>{user.phone}</td> */}
              </tr>
            );
          })}
        </tbody>
      </Table>
    </div>
  );
}

export default Users;
