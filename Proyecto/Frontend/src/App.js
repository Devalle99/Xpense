import React from 'react';
import {
  BrowserRouter as Router,
  createBrowserRouter,
  Route,
  RouterProvider,
  Routes
} from 'react-router-dom';
import Login from './Seguridad/Login';
import Signup from './Seguridad/Signup';
import Gastos from './Gastos/Gastos';
import Totales from './Totales/Totales';
import Categorias from './Categorias/Categorias';
import PrivateRoutes from './Seguridad/PrivateRoutes'
import PublicRoutes from './Seguridad/PublicRoutes'

function App() {
  return (
    <Router>
      <Routes>
        <Route element={<PrivateRoutes />}>
          <Route path='/gastos' element={<Gastos />}></Route>
          <Route path='/totales' element={<Totales />}></Route>
          <Route path='/categorias' element={<Categorias />}></Route>
        </Route>
        <Route element={<PublicRoutes />}>
          <Route path='/' element={<Login />} />
          <Route path='/registro' element={<Signup />}></Route>
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
