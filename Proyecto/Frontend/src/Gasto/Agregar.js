import React, { useState } from "react";
import "./Agregar.css";

const Agregar = ({ agregarGasto }) => {
    const [motivo, setMotivo] = useState('');
    const [monto, setMonto] = useState('');
    const [fecha, setFecha] = useState('');
    const [nuevoMotivo, setNuevoMotivo] = useState('');
    const [motivosDisponibles, setMotivosDisponibles] = useState(["carro", "casa", "comida", "mascota", "otros"]);

    const handleMotivoChange = (e) => {
        setMotivo(e.target.value);
    };

    const handleMontoChange = (e) => {
        setMonto(e.target.value);
    };

    const handleFechaChange = (e) => {
        setFecha(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        if (!motivo || monto <= 0 || !fecha) {
            alert("Por favor, complete todos los campos correctamente.");
            return;
        }

        const nuevoGasto = { motivo, monto: Number(monto), fecha };
        agregarGasto(nuevoGasto);

        setMotivo('');
        setMonto('');
        setFecha('');
    };

    const agregarNuevoMotivo = () => {
        if (nuevoMotivo && !motivosDisponibles.includes(nuevoMotivo.toLowerCase())) {
            setMotivosDisponibles([...motivosDisponibles, nuevoMotivo.toLowerCase()]);
            setMotivo(nuevoMotivo.toLowerCase());
            setNuevoMotivo('');
        } else {
            alert("El motivo ya existe o está vacío.");
        }
    };

    return (
        <div>
            <h3>Agregar Gastos</h3>
            <form onSubmit={handleSubmit}>
                <div className="row">
                    <div className="form-group col-md-4">
                        <select
                            className="form-control"
                            value={motivo}
                            onChange={handleMotivoChange}
                        >
                            <option value="">Seleccione un motivo</option>
                            {motivosDisponibles.map((motivoItem, index) => (
                                <option key={index} value={motivoItem}>{motivoItem}</option>
                            ))}
                        </select>
                        <input
                            type="text"
                            className="form-control mt-2"
                            placeholder="Nuevo motivo"
                            value={nuevoMotivo}
                            onChange={(e) => setNuevoMotivo(e.target.value)}
                        />
                        <button
                            type="button"
                            className="btn btn-secondary mt-2"
                            onClick={agregarNuevoMotivo}
                        >
                            Agregar Motivo
                        </button>
                    </div>
                    <div className="form-group col-md-4">
                        <input
                            type="number"
                            className="form-control"
                            placeholder="Monto"
                            value={monto}
                            onChange={handleMontoChange}
                            min="0"
                        />
                    </div>
                    <div className="form-group col-md-4">
                        <input
                            type="date"
                            className="form-control"
                            value={fecha}
                            onChange={handleFechaChange}
                        />
                    </div>
                </div>
                <div className="boton-centrado">
                    <button type="submit" className="btn btn-primary">Guardar Gasto</button>
                </div>
            </form>
        </div>
    );
};

export default Agregar;
