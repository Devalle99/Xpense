import React, { useState, useEffect } from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import { Table, Modal, Button, Form } from 'react-bootstrap';

function Historial({ expenseList, categoryList, onGetExpenseList, onEliminarGasto, onActualizarGasto }) {

  const getFirstDayOfMonth = () => {
    let currentDate = new Date();
    // Calcular primer día del mes
    let firstDayOfMonth = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);
    return firstDayOfMonth;
  }

  const getLastDayOfMonth = () => {
    let currentDate = new Date();
    // Calcular el último día del mes
    let lastDayOfMonth = new Date(currentDate.getFullYear(), currentDate.getMonth() + 1, 0);
    return lastDayOfMonth;
  }

  const [showModalEditor, setShowModalEditor] = useState(false);
  const [editedExpense, setEditedExpense] = useState({});

  // estados para get all filtrados y ordenados
  const [showModalFiltros, setShowModalFiltros] = useState(false);
  const [orderBy, setOrderBy] = useState("fechaDesc");
  const [minAmountFilter, setMinAmountFilter] = useState(0);
  const [categoriaIdFilter, setCategoriaIdFilter] = useState("");
  const [minDateFilter, setMinDateFilter] = useState(getFirstDayOfMonth());
  const [maxDateFilter, setMaxDateFilter] = useState(getLastDayOfMonth());

  useEffect(() => {
    handleGetAll();
  }, [orderBy, minAmountFilter, categoriaIdFilter, minDateFilter, maxDateFilter]);

  // Editor para actualizar
  const handleShowEditor = (expense) => {
    setEditedExpense(expense);
    setShowModalEditor(true);
  };

  const handleCloseEditor = () => {
    setEditedExpense({});
    setShowModalEditor(false);
  };

  const validateMonto = (monto) => {
    const trimmedMonto = monto.trim().replace(/,/g, ".");

    if (/^\d*\.?\d*$/.test(trimmedMonto)) {
      return parseFloat(trimmedMonto);
    }

    alert('Por favor, ingrese un número válido.');
    return false;
  };

  const handleUpdate = () => {
    // Remover categoriaNombre del objeto
    const { categoriaNombre, ...formattedEditedExpense } = editedExpense;

    // Validar y convertir monto a float
    const validatedMonto = validateMonto(formattedEditedExpense.monto);
    if (!validatedMonto) {
      return;
    }

    // Desestructurar editedExpense para obtener los valores necesarios
    const { id, concepto, categoriaId } = formattedEditedExpense;

    // Llamar a la función onActualizarGasto con los argumentos correctos
    onActualizarGasto(id, concepto, validatedMonto, categoriaId);

    handleCloseEditor();
  };

  const handleDelete = (expenseId) => {
    onEliminarGasto(expenseId);
  }




  // Modal para ordenar y filtrar, a lo mejor no es necesario usar handler functions tan sencillas
  const handleGetAll = () => {
    let categoryId = parseInt(categoriaIdFilter, 10);
    let minAmount = parseInt(minAmountFilter, 10);
    let startDate = minDateFilter.toISOString();
    let endDate = maxDateFilter.toISOString();

    let options = {
      orderBy,
      categoryId,
      minAmount,
      startDate,
      endDate
    };
    onGetExpenseList(options);
  };

  const handleResetFiltros = () => {
    setOrderBy("fechaDesc");
    setMinAmountFilter(0);
    setCategoriaIdFilter("");
    setMinDateFilter(getFirstDayOfMonth());
    setMaxDateFilter(getLastDayOfMonth());

    handleGetAll();
  };

  return (
    <div>
      <h3>Historial de Gastos</h3>

      {/* Botones para filtros */}
      <Button variant="secondary" onClick={() => setShowModalFiltros(true)}>
        Ver filtros
      </Button>

      {/* Tabla de gastos */}
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Concepto</th>
            <th>Monto</th>
            <th>Categoría</th>
            <th>Fecha</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {expenseList.map((gasto) => (
            <tr key={gasto.id}>
              <td>{gasto.concepto}</td>
              <td>${gasto.monto}</td>
              <td>{gasto.categoriaNombre}</td>
              <td>{gasto.createdAt}</td>
              <td>
                <Button variant="secondary" size="sm" onClick={() => handleShowEditor(gasto)}>
                  Editar
                </Button>
                <Button variant="danger" size="sm" onClick={() => handleDelete(gasto.id)}>
                  Eliminar
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      {/* Modal de Edición */}
      <Modal show={showModalEditor} onHide={handleCloseEditor}>
        <Modal.Header closeButton>
          <Modal.Title>Editar Gasto</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="formConcepto">
              <Form.Label>Concepto</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese el concepto"
                value={editedExpense.concepto || ''}
                onChange={(e) => setEditedExpense({ ...editedExpense, concepto: e.target.value })}
              />
            </Form.Group>

            <Form.Group controlId="formMonto">
              <Form.Label>Monto</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese el monto"
                value={editedExpense.monto || ''}
                onChange={(e) => setEditedExpense({ ...editedExpense, monto: e.target.value })}
              />
            </Form.Group>

            <Form.Group controlId="formCategoria">
              <Form.Label>Categoría</Form.Label>
              <Form.Control
                as="select"
                value={editedExpense.categoriaId || ''}
                onChange={(e) => setEditedExpense({ ...editedExpense, categoriaId: e.target.value })}
                required
              >
                <option value="">Seleccionar categoría</option>
                {categoryList.map((categoria) => (
                  <option key={categoria.id} value={categoria.id}>
                    {categoria.nombre}
                  </option>
                ))}
              </Form.Control>
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseEditor}>
            Cerrar
          </Button>
          <Button variant="primary" onClick={handleUpdate}>
            Guardar
          </Button>
        </Modal.Footer>
      </Modal>

      {/* Modal para ordenar y filtrar */}
      <Modal show={showModalFiltros} onHide={() => setShowModalFiltros(false)}>
        <Modal.Header>
          <Modal.Title>Filtrar y Ordenar Gastos</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="formOrderBy">
              <Form.Label>Ordenar Gastos</Form.Label>
              <Form.Control
                as="select"
                value={orderBy}
                onChange={(e) => setOrderBy(e.target.value)}
              >
                <option value="fechaDesc">Más reciente</option>
                <option value="fechaAsc">Más antiguo</option>
                <option value="montoAsc">{"Monto (Ascendente)"}</option>
                <option value="montoDesc">{"Monto (Descendente)"}</option>
                <option value="catgoriaAsc">Categoría</option>
                <option value="conceptoAsc">Concepto</option>
              </Form.Control>
            </Form.Group>

            <Form.Group controlId="formMinAmountFilter">
              <Form.Label>Monto mínimo</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese el monto mínimo"
                value={minAmountFilter}
                onChange={(e) => setMinAmountFilter(e.target.value)}
              />
            </Form.Group>

            <Form.Group controlId="formCategoriaIdFilter">
              <Form.Label>Categoría</Form.Label>
              <Form.Control
                as="select"
                value={categoriaIdFilter}
                onChange={(e) => setCategoriaIdFilter(e.target.value)}
              >
                <option value="">Todas las categorías</option>
                {categoryList.map((categoria) => (
                  <option key={categoria.id} value={categoria.id}>
                    {categoria.nombre}
                  </option>
                ))}
              </Form.Control>
            </Form.Group>

            <Form.Group controlId="formMinDateFilter">
              <Form.Label>Desde</Form.Label>
              <DatePicker
                selected={minDateFilter}
                onChange={date => setMinDateFilter(date)}
                dateFormat="dd/MM/yyyy"
              />
            </Form.Group>

            <Form.Group controlId="formMaxDateFilter">
              <Form.Label>Hasta</Form.Label>
              <DatePicker
                selected={maxDateFilter}
                onChange={date => setMaxDateFilter(date)}
                dateFormat="dd/MM/yyyy"
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowModalFiltros(!showModalFiltros)}>
            Cerrar filtros
          </Button>

          <Button variant="secondary" onClick={() => handleResetFiltros()}>
            Resetear filtros
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}

export default Historial;
