import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import Validation from './SignupValidation';
import { AuthService } from '../Servicios/AuthService';

function Signup() {
  const [values, setValues] = useState({
    email: '',
    password: '',
    confirmPassword: '',
  });

  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();

    // Verificar que las contraseñas coincidan
    if (values.password !== values.confirmPassword) {
      alert('Las contraseñas no coinciden.');
      return;
    }

    // Crear una instancia del servicio de autenticación
    let service = new AuthService();

    // Llamar a la función de registro
    let register = await service.Register(values.email, values.password);

    // Manejar la respuesta del registro
    if (register.code === '200') {
      navigate('/');
    } else {
      alert('Correo electrónico o contraseña inválidos.');
    }
  };

  return (
    <div className='d-flex justify-content-center align-items-center bg-primary vh-100'>
      <div className='bg-white p-3 rounded w-25'>
        <h2>Registro</h2>
        <form onSubmit={handleSubmit}>
          <div className='mb-3'>
            <label htmlFor='email'><strong>Email</strong></label>
            <input
              type='email'
              placeholder='Ingresar Email'
              name='email'
              className='form-control rounded-0'
              onChange={(e) => setValues({ ...values, email: e.target.value })}
              value={values.email}
              required
            />
          </div>
          <div className='mb-3'>
            <label htmlFor='password'><strong>Contraseña</strong></label>
            <input
              type='password'
              placeholder='Ingresar contraseña'
              name='password'
              className='form-control rounded-0'
              onChange={(e) => setValues({ ...values, password: e.target.value })}
              value={values.password}
              required
            />
          </div>
          <div className='mb-3'>
            <label htmlFor='confirmPassword'><strong>Confirmar Contraseña</strong></label>
            <input
              type='password'
              placeholder='Confirmar contraseña'
              name='confirmPassword'
              className='form-control rounded-0'
              onChange={(e) => setValues({ ...values, confirmPassword: e.target.value })}
              value={values.confirmPassword}
              required
            />
          </div>
          <button type='submit' className='btn btn-success w-100 rounded-0'><strong>Registrarse</strong></button>
          <Link to='/' className='btn btn-default border w-100 bg-light rounded-0 text-decoration-none'>Ingresar</Link>
        </form>
      </div>
    </div>
  );
}

export default Signup;