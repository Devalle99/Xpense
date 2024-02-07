import React, { useState } from "react";
import Agregar from "./Agregar";
import Graficos from "./Graficos";
import Historial from './Historial';
import NavBar from './NavBar';
import ModalEditarGasto from './ModalEditarGasto'; // Asegúrate de crear este componente
import "./GestionGastos.css";

const GestionGastos = () => {
    const [historial, setHistorial] = useState([]);
    const [presupuestoTotal, setPresupuestoTotal] = useState(0);
    const [totalGastado, setTotalGastado] = useState(0);
    const [saldoRestante, setSaldoRestante] = useState(0);
    const [nuevoPresupuesto, setNuevoPresupuesto] = useState('');
    const [gastoEnEdicion, setGastoEnEdicion] = useState(null);

    const manejarPresupuestoInput = (event) => {
        setNuevoPresupuesto(event.target.value);
    };

    const actualizarPresupuesto = () => {
        const nuevoPresupuestoNum = Number(nuevoPresupuesto);
        if (nuevoPresupuestoNum >= 0) {
            setPresupuestoTotal(nuevoPresupuestoNum);
            setSaldoRestante(nuevoPresupuestoNum - totalGastado);
            setNuevoPresupuesto('');
        } else {
            alert("Por favor, ingrese un valor válido para el presupuesto.");
        }
    };

    const manejarGastos = (nuevoGasto) => {
        setHistorial((prevHistorial) => {
            const totalGastadoActualizado = totalGastado + Number(nuevoGasto.monto);
            setTotalGastado(totalGastadoActualizado);
            setSaldoRestante(presupuestoTotal - totalGastadoActualizado);
            return [...prevHistorial, nuevoGasto];
        });
    };

    const modificarGasto = (index, gastoModificado) => {
        setHistorial((prevHistorial) => {
            // Copia el historial existente para no modificar el estado directamente
            const historialActualizado = [...prevHistorial];
    
            // Reemplaza el gasto en la posición 'index' con el gastoModificado
            historialActualizado[index] = { ...gastoModificado, index };
    
            // Calcula el total gastado sumando los montos de todos los gastos en el historialActualizado
            const totalGastadoActualizado = historialActualizado.reduce((acc, gasto) => acc + Number(gasto.monto), 0);
    
            // Actualiza el estado totalGastado con el nuevo total calculado
            setTotalGastado(totalGastadoActualizado);
    
            // Actualiza el saldoRestante restando el totalGastadoActualizado del presupuestoTotal
            setSaldoRestante(presupuestoTotal - totalGastadoActualizado);
    
            // Devuelve el historial actualizado, que se establecerá como el nuevo estado
            return historialActualizado;
        });
    };    

    const eliminarGasto = (index) => {
        setHistorial((prevHistorial) => {
            // Filtra el historialActualizado excluyendo el gasto en la posición 'index'
            const historialActualizado = prevHistorial.filter((_, i) => i !== index);
    
            // Calcula el total gastado sumando los montos de todos los gastos en el historialActualizado
            const totalGastadoActualizado = historialActualizado.reduce((acc, gasto) => acc + Number(gasto.monto), 0);
    
            // Actualiza el estado totalGastado con el nuevo total calculado
            setTotalGastado(totalGastadoActualizado);
    
            // Actualiza el saldoRestante restando el totalGastadoActualizado del presupuestoTotal
            setSaldoRestante(presupuestoTotal - totalGastadoActualizado);
    
            // Devuelve el historial actualizado, que se establecerá como el nuevo estado
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
        <div className='app container'>
            <NavBar />
            <div className="jumbotron">
                <p className='lead text-center'>Gestor de Gastos</p>
                <div className="form-group">
                    <input
                        type="number"
                        className="form-control"
                        placeholder="Ingrese nuevo presupuesto"
                        value={nuevoPresupuesto}
                        onChange={manejarPresupuestoInput}
                    />
                    <button onClick={actualizarPresupuesto} className="btn btn-primary mt-2">
                        Actualizar Presupuesto
                    </button>
                </div>
                <Agregar
                    agregarGasto={manejarGastos}
                    presupuestoTotal={presupuestoTotal}
                />
                <Historial
                    historial={historial}
                    presupuestoTotal={presupuestoTotal}
                    iniciarEdicionGasto={iniciarEdicionGasto}
                    eliminarGasto={eliminarGasto}
                />
                <Graficos
                    historial={historial}
                    presupuestoTotal={presupuestoTotal}
                />
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