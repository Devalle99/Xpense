import React from 'react';
import Login from './Login';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Signup from './Signup';
import GestionGastos from './GestionGastos';
import './App.css'; // Importa el archivo CSS aquí

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Login />}></Route>
        <Route path='/signup' element={<Signup />}></Route>
        <Route path='/gestiongastos' element={<GestionGastos />}></Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
