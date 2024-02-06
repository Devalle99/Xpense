import React, { Component } from "react";
import Agregar from "./Agregar";
import Graficos from "./Graficos";
import Historial from './Historial';
import NavBar from './NavBar';
import ModalEditarGasto from './ModalEditarGasto'; // Asegúrate de crear este componente
import "./GestionGastos.css";

class GestionGastos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            historial: [],
            presupuestoTotal: 0,
            totalGastado: 0,
            saldoRestante: 0,
            nuevoPresupuesto: '',
            gastoEnEdicion: null, // Estado para manejar el gasto actualmente en edición
        };

        this.manejarPresupuestoInput = this.manejarPresupuestoInput.bind(this);
        this.actualizarPresupuesto = this.actualizarPresupuesto.bind(this);
        this.manejarGastos = this.manejarGastos.bind(this);
        this.modificarGasto = this.modificarGasto.bind(this);
        this.eliminarGasto = this.eliminarGasto.bind(this);
        this.iniciarEdicionGasto = this.iniciarEdicionGasto.bind(this);
        this.guardarCambiosGasto = this.guardarCambiosGasto.bind(this);
        this.cancelarEdicionGasto = this.cancelarEdicionGasto.bind(this);
    }

    manejarPresupuestoInput(event) {
        this.setState({ nuevoPresupuesto: event.target.value });
    }

    actualizarPresupuesto() {
        const nuevoPresupuesto = Number(this.state.nuevoPresupuesto);
        if (nuevoPresupuesto >= 0) {
            this.setState({
                presupuestoTotal: nuevoPresupuesto,
                saldoRestante: nuevoPresupuesto - this.state.totalGastado,
                nuevoPresupuesto: ''
            });
        } else {
            alert("Por favor, ingrese un valor válido para el presupuesto.");
        }
    }

    manejarGastos(nuevoGasto) {
        this.setState(prevState => {
            const totalGastadoActualizado = prevState.totalGastado + Number(nuevoGasto.monto);
            return {
                historial: [...prevState.historial, nuevoGasto],
                totalGastado: totalGastadoActualizado,
                saldoRestante: prevState.presupuestoTotal - totalGastadoActualizado
            };
        });
    }

    modificarGasto(index, gastoModificado) {
        this.setState(prevState => {
            const historialActualizado = [...prevState.historial];
            historialActualizado[index] = {...gastoModificado, index}; // Asegúrate de incluir cualquier otro campo necesario
            const totalGastadoActualizado = historialActualizado.reduce((acc, gasto) => acc + Number(gasto.monto), 0);
            return {
                historial: historialActualizado,
                totalGastado: totalGastadoActualizado,
                saldoRestante: prevState.presupuestoTotal - totalGastadoActualizado,
            };
        });
    }

    eliminarGasto(index) {
        this.setState(prevState => {
            const historialActualizado = prevState.historial.filter((_, i) => i !== index);
            const totalGastadoActualizado = historialActualizado.reduce((acc, gasto) => acc + Number(gasto.monto), 0);
            return {
                historial: historialActualizado,
                totalGastado: totalGastadoActualizado,
                saldoRestante: prevState.presupuestoTotal - totalGastadoActualizado
            };
        });
    }

    iniciarEdicionGasto(index) {
        const gastoAEditar = this.state.historial[index];
        this.setState({ gastoEnEdicion: { ...gastoAEditar, index } });
    }

    guardarCambiosGasto(index, gastoModificado) {
        this.modificarGasto(index, gastoModificado);
        this.setState({ gastoEnEdicion: null });
    }

    cancelarEdicionGasto() {
        this.setState({ gastoEnEdicion: null });
    }

    render() {
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
                            value={this.state.nuevoPresupuesto}
                            onChange={this.manejarPresupuestoInput}
                        />
                        <button onClick={this.actualizarPresupuesto} className="btn btn-primary mt-2">
                            Actualizar Presupuesto
                        </button>
                    </div>
                    <Agregar
                        agregarGasto={this.manejarGastos}
                        presupuestoTotal={this.state.presupuestoTotal}
                    />
                    <Historial
                        historial={this.state.historial}
                        presupuestoTotal={this.state.presupuestoTotal}
                        iniciarEdicionGasto={this.iniciarEdicionGasto}
                        eliminarGasto={this.eliminarGasto}
                    />
                    <Graficos
                        historial={this.state.historial}
                        presupuestoTotal={this.state.presupuestoTotal}
                    />
                    {this.state.gastoEnEdicion && (
                        <ModalEditarGasto
                            gasto={this.state.gastoEnEdicion}
                            guardarCambiosGasto={this.guardarCambiosGasto}
                            cancelarEdicionGasto={this.cancelarEdicionGasto}
                        />
                    )}
                </div>
            </div>
        );
    }
}

export default GestionGastos;

