import React, { useState, useEffect } from 'react';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import { Table, Modal, Button, Form } from 'react-bootstrap';
import DatePicker from 'react-datepicker';
import { ExpenseService } from '../Servicios/ExpenseService';
import { CategoryService } from '../Servicios/CategoryService';
import 'react-datepicker/dist/react-datepicker.css';


function TotalesDeGasto() {
  const [generalTotal, setGeneralTotal] = useState('0');
  const [categoriaTotal, setCategoriaTotal] = useState('0');
  const [mesTotal, setMesTotal] = useState('0');

  const [categoryList, setCategoryList] = useState([]);
  const [categoryId, setCategoryId] = useState('null');
  const [month, setMonth] = useState(new Date());

  useEffect(() => {
    getCategoryList();
  }, []);

  useEffect(() => {
    // Verifica si categoryId es '0' y establece el total de categoría en cero
    if (categoryId !== 'null') {
      getExpenseTotal("categoria", categoryId, null);
    }
    getExpenseTotal("mes", null, month);
    getExpenseTotal(); // Opcional, según tu lógica
  }, [categoryId, month]);

  const getExpenseTotal = async (attribute, categoryId, month) => {
    try {
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
    } catch (error) {
      console.error(error);
      // Puedes manejar el error aquí, por ejemplo, mostrar un mensaje al usuario
    }
  }

  const getCategoryList = async () => {
    try {
      let service = new CategoryService();
      let categories = await service.GetCategories();
      setCategoryList(categories || []);
    } catch (error) {
      console.error(error);
      // Puedes manejar el error aquí, por ejemplo, mostrar un mensaje al usuario
    }
  }

  return (
    <div>
      <h3>Totales Agrupados</h3>
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
            <option key={'null'} value={'null'}>
              Seleccionar una categoría
            </option>
            <option key={0} value={0}>
              Sin categoría
            </option>
            {categoryList.map((categoria) => (
              <option key={categoria.id} value={categoria.id}>
                {categoria.nombre}
              </option>
            ))}
          </Form.Control>
          {categoryId === 'null' ? "Ninguna categoría seleccionada" : 
          <>
            Para esta categoría, el total es
            <h5>${categoriaTotal}</h5>
          </>}
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
