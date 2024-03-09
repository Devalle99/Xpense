import React, { useState, useEffect } from "react";
import NavBar from "../NavBar";
import Graficos from "./Graficos";
import TotalesDeGasto from "./TotalesDeGasto";

const Totales = () => {
  return (
    <div className="app container">
      <NavBar />
      <div className="jumbotron">
        <h2 className="text-center mb-4">Total de Gastos</h2>
        <TotalesDeGasto />
        <Graficos />
      </div>
    </div>
  );
};

export default Totales;