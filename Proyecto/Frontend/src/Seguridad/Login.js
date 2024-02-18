import React, { useState } from 'react';
import { Link, Navigate} from 'react-router-dom';
import { AuthService } from '../Servicios/AuthService';
import './Login.css';


function Login() {

  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);

    let service = new AuthService();
    let login = await service.GetToken(data.get('email'), data.get('password'));
    console.log(login);
    if (login.code === "200") {
      localStorage.setItem("loggedIn", true);
      setIsLoggedIn(true);
    } else {
      setIsLoggedIn(false);
      alert("Correo electrónico o contraseña incorrectos.");
    }
  };

  return (
    <div className='d-flex justify-content-center align-items-center bg-primary vh-100'>
      <div className='bg-white p-3 rounded w-25'>
        <h2>Iniciar Sesión</h2>
        <form onSubmit={handleSubmit}>
          <div className='mb-3'>
            <label htmlFor="email"><strong>Email</strong></label>
            <input type="email" placeholder="Ingresar Email" id="email" name="email" className='form-control rounded-0' required/>
          </div>
          <div className='mb-3'>
            <label htmlFor="password"><strong>Contraseña</strong></label>
            <input type="password" placeholder="Ingresar contraseña" id="password" name="password" className='form-control rounded-0' required/>
          </div>
          <button type='submit' className='btn btn-success w-100 rounded-0'><strong>Ingresar</strong></button>
          <Link to="/registro" className='btn btn-default border w-100 bg-light rounded-0 text-decoration-none'>Crear cuenta</Link>
        </form>

        {isLoggedIn && <Navigate to="/gastos" />}
      </div>
    </div>
  );
}

export default Login;
