import React, { useState, useEffect } from 'react';

function ModalEditarGasto({ gasto, guardarCambiosGasto, cancelarEdicionGasto }) {
    const [motivo, setMotivo] = useState(gasto.motivo);
    const [monto, setMonto] = useState(gasto.monto);
    const [fecha, setFecha] = useState(gasto.fecha);

    // Asegurarse de que el estado se actualiza si el gasto a editar cambia
    useEffect(() => {
        setMotivo(gasto.motivo);
        setMonto(gasto.monto);
        setFecha(gasto.fecha);
    }, [gasto]);

    const guardarCambios = () => {
        // Llamar a la función de guardar cambios del componente padre con los nuevos valores
        guardarCambiosGasto(gasto.index, { motivo, monto, fecha });
    };

    return (
        <div className="modal show" tabIndex="-1" role="dialog" style={{display: 'block', backgroundColor: 'rgba(0,0,0,0.5)'}}>
            <div className="modal-dialog" role="document">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title">Editar Gasto</h5>
                        <button type="button" className="close" data-dismiss="modal" aria-label="Close" onClick={cancelarEdicionGasto}>
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div className="modal-body">
                        <form>
                            <div className="form-group">
                                <label htmlFor="motivo">Motivo</label>
                                <input type="text" className="form-control" id="motivo" value={motivo} onChange={(e) => setMotivo(e.target.value)} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="monto">Monto</label>
                                <input type="number" className="form-control" id="monto" value={monto} onChange={(e) => setMonto(e.target.value)} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="fecha">Fecha</label>
                                <input type="date" className="form-control" id="fecha" value={fecha} onChange={(e) => setFecha(e.target.value)} />
                            </div>
                        </form>
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-primary" onClick={guardarCambios}>Guardar Cambios</button>
                        <button type="button" className="btn btn-secondary" data-dismiss="modal" onClick={cancelarEdicionGasto}>Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ModalEditarGasto;
