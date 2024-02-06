import React, { Component } from "react";
import "./Agregar.css";

class Agregar extends Component {
    constructor(props) {
        super(props);
        this.state = {
            motivo: '',
            monto: '',
            fecha: '',
            nuevoMotivo: '', // Para capturar el valor del nuevo motivo
            motivosDisponibles: ["carro", "casa", "comida", "mascota", "otros"] // Lista inicial de motivos
        };

        // Vincular métodos
        this.handleMotivoChange = this.handleMotivoChange.bind(this);
        this.handleMontoChange = this.handleMontoChange.bind(this);
        this.handleFechaChange = this.handleFechaChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.agregarNuevoMotivo = this.agregarNuevoMotivo.bind(this); // Vincular el nuevo método
    }

    handleMotivoChange(e) {
        this.setState({ motivo: e.target.value });
    }

    handleMontoChange(e) {
        this.setState({ monto: e.target.value });
    }

    handleFechaChange(e) {
        this.setState({ fecha: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();
        const { motivo, monto, fecha } = this.state;

        if (!motivo || monto <= 0 || !fecha) {
            alert("Por favor, complete todos los campos correctamente.");
            return;
        }

        const nuevoGasto = { motivo, monto: Number(monto), fecha };
        this.props.agregarGasto(nuevoGasto);

        this.setState({
            motivo: '',
            monto: '',
            fecha: ''
        });
    }

    agregarNuevoMotivo() {
        const { nuevoMotivo, motivosDisponibles } = this.state;
        if (nuevoMotivo && !motivosDisponibles.includes(nuevoMotivo.toLowerCase())) {
            this.setState({
                motivosDisponibles: [...motivosDisponibles, nuevoMotivo.toLowerCase()],
                motivo: nuevoMotivo.toLowerCase(),
                nuevoMotivo: ''
            });
        } else {
            alert("El motivo ya existe o está vacío.");
        }
    }

    render() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <div className="row">
                        <div className="form-group col-md-4">
                            <select
                                className="form-control"
                                value={this.state.motivo}
                                onChange={this.handleMotivoChange}
                            >
                                <option value="">Seleccione un motivo</option>
                                {this.state.motivosDisponibles.map((motivo, index) => (
                                    <option key={index} value={motivo}>{motivo}</option>
                                ))}
                            </select>
                            <input
                                type="text"
                                className="form-control mt-2"
                                placeholder="Nuevo motivo"
                                value={this.state.nuevoMotivo}
                                onChange={(e) => this.setState({ nuevoMotivo: e.target.value })}
                            />
                            <button
                                type="button"
                                className="btn btn-secondary mt-2"
                                onClick={this.agregarNuevoMotivo}
                            >
                                Agregar Motivo
                            </button>
                        </div>
                        <div className="form-group col-md-4">
                            <input
                                type="number"
                                className="form-control"
                                placeholder="Monto"
                                value={this.state.monto}
                                onChange={this.handleMontoChange}
                                min="0"
                            />
                        </div>
                        <div className="form-group col-md-4">
                            <input
                                type="date"
                                className="form-control"
                                value={this.state.fecha}
                                onChange={this.handleFechaChange}
                            />
                        </div>
                    </div>
                    <div className="boton-centrado">
                        <button type="submit" className="btn btn-primary">Guardar Gasto</button>
                    </div>
                </form>
            </div>
        );
    }
}

export default Agregar;

