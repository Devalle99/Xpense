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
import GestionGastos from './Gasto/GestionGastos';
import PrivateRoutes from './Seguridad/PrivateRoutes'
import PublicRoutes from './Seguridad/PublicRoutes'

function App() {
  return (
    <Router>
      <Routes>
        <Route element={<PrivateRoutes />}>
          <Route path='/inicio' element={<GestionGastos />}></Route>
        </Route>
        <Route element={<PublicRoutes />}>
          <Route element={<Login />} path='/' />
          <Route path='/registro' element={<Signup />}></Route>
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
