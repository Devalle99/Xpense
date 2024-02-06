import React, {useState } from 'react';
import {Link, useNavigate} from 'react-router-dom'
import Validation from './SignupValidation';
import axios from 'axios';
import './Signup.css';


function Signup() {

    const [values, setValues] = useState({
        name: '',
        email: '',
        password:''  
   })
   const navigate = useNavigate();
   const [errors, setErrrors] = useState({})
   const handleInput = (event) =>{
        setValues(prev => ({...prev, [event.target.name]: event.target.value}))
   }
   const handleSubmit = (event) => {
        event.preventDefault();
        setErrrors(Validation(values));
        if(errors.email ==="" && errors.password==="" && errors.confirmPassword === ""){
            axios.post('http://localhost:8081/signup', values)
            .then(res => {
                navigate('/');
            })
            .catch(err => console.log(err));
        }
   };

    return (
        
        <div  className='d-flex justify-content-center align-items-center bg-primary vh-100'>
            <div className='bg-white p-3 rounded w-25'>
              <h2>Registro</h2>
              <form action="" onSubmit={handleSubmit}>
                    <div className='mb-3'>
                            <label htmlFor="name"><strong>Nombre</strong></label>
                            <input type="text" placeholder='Ingresar nombre' name='name'
                             onChange={handleInput} className='form-control rounded-0'/>
                             {errors.name && <span className='text-danger'>{errors.name}</span>}
                     </div>
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
                     <div className='mb-3'>
                            <label htmlFor="confirmPassword"><strong>Confirmar Contraseña</strong></label>
                            <input
                                type="password"
                                placeholder='Confirmar contraseña'
                                name='confirmPassword'
                                onChange={handleInput}
                                className='form-control rounded-0'
                            />
                            {errors.confirmPassword && <span className='text-danger'>{errors.confirmPassword}</span>}
                    </div>
                     <button type='submit' className='btn btn-success w-100 rounded-0'><strong>Registrarse</strong></button>
                     <Link to="/" className='btn btn-default border w-100 bg-light rounded-0 text-decoration-none'>Ingresar</Link>
              </form>
            </div>
        </div>
    )   

}

export default Signup;