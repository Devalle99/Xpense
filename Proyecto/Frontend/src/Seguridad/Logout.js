import { Link, Navigate } from 'react-router-dom';


function Logout() {

  localStorage.removeItem("loggedIn");

  return (
    <Navigate to="/" />
  );
}

export default Logout;
