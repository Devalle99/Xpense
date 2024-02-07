import React, { useState } from "react";
import Agregar from "./Agregar";
import Graficos from "./Graficos";
import Historial from "./Historial";
import NavBar from "../NavBar";
import ModalEditarGasto from "./ModalEditarGasto";
import Category from "./Category";
import "./GestionGastos.css";

const GestionGastos = () => {
  const [historial, setHistorial] = useState([]);
  const [totalGastado, setTotalGastado] = useState(0);
  const [gastoEnEdicion, setGastoEnEdicion] = useState(null);

  const manejarGastos = (nuevoGasto) => {
    setHistorial((prevHistorial) => {
      const totalGastadoActualizado = prevHistorial.reduce(
        (acc, gasto) => acc + Number(gasto.monto),
        0
      );
      setTotalGastado(totalGastadoActualizado + Number(nuevoGasto.monto));
      return [...prevHistorial, nuevoGasto];
    });
  };

  const modificarGasto = (index, gastoModificado) => {
    setHistorial((prevHistorial) => {
      const historialActualizado = [...prevHistorial];
      historialActualizado[index] = { ...gastoModificado, index };
      setTotalGastado(
        historialActualizado.reduce((acc, gasto) => acc + Number(gasto.monto), 0)
      );
      return historialActualizado;
    });
  };

  const eliminarGasto = (index) => {
    setHistorial((prevHistorial) => {
      const historialActualizado = prevHistorial.filter((_, i) => i !== index);
      setTotalGastado(
        historialActualizado.reduce((acc, gasto) => acc + Number(gasto.monto), 0)
      );
      return historialActualizado;
    });
  };

  const iniciarEdicionGasto = (index) => {
    const gastoAEditar = historial[index];
    setGastoEnEdicion({ ...gastoAEditar, index });
  };

  const guardarCambiosGasto = (index, gastoModificado) => {
    modificarGasto(index, gastoModificado);
    setGastoEnEdicion(null);
  };

  const cancelarEdicionGasto = () => {
    setGastoEnEdicion(null);
  };

  return (
    <div className="app container">
      <NavBar />
      <div className="jumbotron">
        <h2 className="text-center">Gestor de Gastos</h2>
        <Category />
        <Agregar agregarGasto={manejarGastos} />
        <Historial
          historial={historial}
          iniciarEdicionGasto={iniciarEdicionGasto}
          eliminarGasto={eliminarGasto}
        />
        <Graficos historial={historial} />
        {gastoEnEdicion && (
          <ModalEditarGasto
            gasto={gastoEnEdicion}
            guardarCambiosGasto={guardarCambiosGasto}
            cancelarEdicionGasto={cancelarEdicionGasto}
          />
        )}
      </div>
    </div>
  );
};

export default GestionGastos;
