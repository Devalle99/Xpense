import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import Validation from './LoginValidation';
import axios from 'axios';
import './Login.css';


function Login() {
  const [values, setValues] = useState({
    name: '',
    email: '',
    password: ''  
  });
  const navigate = useNavigate();
  const [errors, setErrors] = useState({}); // Corregido el nombre de la función setErrors
  const handleInput = (event) => {
    setValues(prev => ({...prev, [event.target.name]: event.target.value}));
  };
  const handleSubmit = (event) => {
    event.preventDefault();
    setErrors(Validation(values)); // Corregido el nombre de la función setErrors
    // Aquí deberías verificar si hay errores antes de navegar
    navigate('/gestiongastos');
  };

  return (
    <div className='d-flex justify-content-center align-items-center bg-primary vh-100'>
      <div className='bg-white p-3 rounded w-25'>
        <h2>Iniciar Sesión</h2>
        <form onSubmit={handleSubmit}>
          <div className='mb-3'>
            <label htmlFor="email"><strong>Email</strong></label>
            <input type="email" placeholder='Ingresar Email' name='email'
              onChange={handleInput} className='form-control rounded-0'/>
            {errors.email && <span className='text-danger'>{errors.email}</span>}
          </div>
          <div className='mb-3'>
            <label htmlFor="password"><strong>Contraseña</strong></label>
            <input type="password" placeholder='Ingresar contraseña' name='password'
              onChange={handleInput} className='form-control rounded-0'/>
            {errors.password && <span className='text-danger'>{errors.password}</span>}
          </div>
          <button type='submit' className='btn btn-success w-100 rounded-0'><strong>Ingresar</strong></button>
          <Link to="/signup" className='btn btn-default border w-100 bg-light rounded-0 text-decoration-none'>Crear cuenta</Link>
        </form>
      </div>
    </div>
  );
}

export default Login;
