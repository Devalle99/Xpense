import React, { useState } from 'react';
import './Historial.css';

function Historial({ historial, presupuestoTotal, iniciarEdicionGasto, eliminarGasto }) {
  const [filtroMotivo, setFiltroMotivo] = useState('');
  const [filtroMonto, setFiltroMonto] = useState(''); // Ya no se usará directamente para filtrar
  const [fechaInicio, setFechaInicio] = useState('');
  const [fechaFin, setFechaFin] = useState('');
  const [mostrarFiltroFechas, setMostrarFiltroFechas] = useState(false);
  const [mostrarFiltroMontos, setMostrarFiltroMontos] = useState(false);
  const [montoInicio, setMontoInicio] = useState('');
  const [montoFin, setMontoFin] = useState('');

  const gastosFiltrados = historial.filter(gasto => {
    const fechaGasto = gasto.fecha ? new Date(gasto.fecha) : null;
    const inicio = fechaInicio ? new Date(fechaInicio) : null;
    const fin = fechaFin ? new Date(fechaFin) : null;
    const monto = parseFloat(gasto.monto);
    const mInicio = parseFloat(montoInicio) || 0;
    const mFin = parseFloat(montoFin) || Number.MAX_SAFE_INTEGER;

    return (
      (filtroMotivo === '' || gasto.motivo.toLowerCase().includes(filtroMotivo.toLowerCase())) &&
      (monto >= mInicio && monto <= mFin) &&
      (!inicio || !fechaGasto || fechaGasto >= inicio) &&
      (!fin || !fechaGasto || fechaGasto <= fin)
    );
  });

  return (
    <div id="historial">
      <h3>Historial de Gastos</h3>
      <table className="table table-hover">
        <thead>
          <tr>
            <th scope="col">
              Motivo
              <input type="text" className="form-control" value={filtroMotivo} onChange={e => setFiltroMotivo(e.target.value)} />
            </th>
            <th scope="col">
              Monto
              <button className="btn btn-sm d-block mb-2 text-white bg-secondary" onClick={() => setMostrarFiltroMontos(!mostrarFiltroMontos)}>
                Filtrar Monto
              </button>


              {mostrarFiltroMontos && (
                <div>
                  Desde: <input type="number" className="form-control mb-2" value={montoInicio} onChange={e => setMontoInicio(e.target.value)} />
                  Hasta: <input type="number" className="form-control mb-2" value={montoFin} onChange={e => setMontoFin(e.target.value)} />
                </div>
              )}
            </th>
            <th scope="col">
              Fecha
              <button className="btn btn-sm d-block mb-2 text-white bg-secondary" onClick={() => setMostrarFiltroFechas(!mostrarFiltroFechas)}>
                Filtrar Fecha
              </button>


              {mostrarFiltroFechas && (
                <div>
                  Desde: <input type="date" className="form-control mb-2" value={fechaInicio} onChange={e => setFechaInicio(e.target.value)} />
                  Hasta: <input type="date" className="form-control mb-2" value={fechaFin} onChange={e => setFechaFin(e.target.value)} />
                </div>
              )}
            </th>
            <th scope="col">Acciones</th>
          </tr>
        </thead>
        <tbody>
          {gastosFiltrados.map((gasto, index) => (
            <tr key={index} className={index % 2 === 0 ? "table-primary" : "table-secondary"}>
              <th scope="row">{gasto.motivo}</th>
              <td>${gasto.monto}</td>
              <td>{gasto.fecha}</td>
              <td>
                <button className="btn btn-secondary btn-sm" onClick={() => iniciarEdicionGasto(index)}>Modificar</button>
                <button className="btn btn-danger btn-sm" onClick={() => eliminarGasto(index)}>Eliminar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Historial;


