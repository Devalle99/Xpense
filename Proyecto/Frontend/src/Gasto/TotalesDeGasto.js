import React, { useState, useEffect } from 'react';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import { Table, Modal, Button, Form } from 'react-bootstrap';
import DatePicker from 'react-datepicker';
import { ExpenseService } from '../Servicios/ExpenseService';
import 'react-datepicker/dist/react-datepicker.css';

function TotalesDeGasto({ categoryList }) {
  const [generalTotal, setGeneralTotal] = useState(null);
  const [categoriaTotal, setCategoriaTotal] = useState(null);
  const [mesTotal, setMesTotal] = useState(null);
  const [categoryId, setCategoryId] = useState(categoryList[0].id);
  const [month, setMonth] = useState(new Date());

  useEffect(() => {
    getExpenseTotal("categoria", categoryId, null);
    getExpenseTotal("mes", null, month);
    getExpenseTotal();
  }, [categoryId, month]);

  // Get totales de gasto
  const getExpenseTotal = async (attribute, categoryId, month) => {
    let service = new ExpenseService();
    let total = await service.GetTotals(attribute, categoryId, month);

    switch (attribute) {
      case "categoria":
        setCategoriaTotal(total);
        break;
      case "mes":
        setMesTotal(total);
        break;
      default:
        setGeneralTotal(total);
    }
  }

  return (
    <div>
      <h3>Total de Gastos</h3>
      <Tabs
        defaultActiveKey="general"
        id="total-de-gastos"
        className="mb-3"
      >
        <Tab eventKey="general" title="General">
          Entre todos tus gastos, el total es
          <h5>${generalTotal}</h5>
        </Tab>
        <Tab eventKey="categoria" title="Por Categoría">
          <Form.Control
            as="select"
            value={categoryId}
            onChange={(e) => setCategoryId(e.target.value)}
          >
            {categoryList.map((categoria) => (
              <option key={categoria.id} value={categoria.id}>
                {categoria.nombre}
              </option>
            ))}
          </Form.Control>
          Para esta categoría, el total es
          <h5>${categoriaTotal}</h5>
        </Tab>
        <Tab eventKey="mes" title="Por Mes">
          <p>Seleccionar el mes</p>
          <DatePicker
            selected={month}
            onChange={(date) => setMonth(date)}
            dateFormat="MM/yyyy"
            showMonthYearPicker
          />
          Para ese mes, el total es
          <h5>${mesTotal}</h5>
        </Tab>
      </Tabs>
    </div>
  );
}

export default TotalesDeGasto;
