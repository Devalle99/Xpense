import { useState } from "react";
import { Form, Button, Row, Col } from 'react-bootstrap';

const Agregar = ({ onAgregarGasto, listaDeCategorias }) => {
  const [concepto, setConcepto] = useState('');
  const [monto, setMonto] = useState('');
  const [categoriaId, setCategoriaId] = useState('');

  const handleConceptoChange = (e) => {
    setConcepto(e.target.value);
  };

  const handleMontoChange = (e) => {
    setMonto(e.target.value);
  };

  const handleCategoriaIdChange = (e) => {
    setCategoriaId(e.target.value);
  };

  const validateMonto = () => {
    const trimmedMonto = monto.trim().replace(/,/g, ".");

    if (/^\d*\.?\d*$/.test(trimmedMonto)) {
      return parseFloat(trimmedMonto);
    }

    alert('Por favor, ingrese un número válido.');
    setMonto('');
    return false;
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    let montoFloat = validateMonto();
    if (!montoFloat) {
      return;
    }

    let categoriaIdInteger = parseInt(categoriaId, 10);
    onAgregarGasto(concepto, montoFloat, categoriaIdInteger);

    setConcepto('');
    setMonto('');
    setCategoriaId('');
  };

  return (
    <div>
      <h3>Agregar Gastos</h3>
      <Form onSubmit={handleSubmit}>
        <Row>
          <Col md={4}>
            <Form.Group>
              <Form.Label>Concepto</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese el concepto"
                value={concepto}
                onChange={(e) => handleConceptoChange(e)}
                required
              />
            </Form.Group>
          </Col>
          <Col md={4}>
            <Form.Group>
              <Form.Label>Monto</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese el monto"
                value={monto}
                onChange={(e) => handleMontoChange(e)}
                required
              />
            </Form.Group>
          </Col>
          <Col md={4}>
            <Form.Group>
              <Form.Label>Categoría</Form.Label>
              <Form.Control
                as="select"
                value={categoriaId}
                onChange={(e) => handleCategoriaIdChange(e)}
              >
                <option value="">Seleccionar categoría</option>
                {listaDeCategorias.map((categoria) => (
                  <option key={categoria.id} value={categoria.id}>
                    {categoria.nombre}
                  </option>
                ))}
              </Form.Control>
            </Form.Group>
          </Col>
        </Row>
        <div className="boton-centrado mb-4 mt-2">
          <Button type="submit" variant="primary">
            Guardar Gasto
          </Button>
        </div>
      </Form>
    </div>
  );
};

export default Agregar;
