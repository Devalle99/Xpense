import React, { useState, useEffect } from "react";
import NavBar from "../NavBar";
import Agregar from "./Agregar";
import Historial from "./Historial";
import { ExpenseService } from '../Servicios/ExpenseService';
import { CategoryService } from '../Servicios/CategoryService';

const Gastos = () => {
  const [listaDeGastos, setListaDeGastos] = useState([]);
  const [listaDeCategorias, setListaDeCategorias] = useState([]);

  useEffect(() => {
    getCategoryList(); // al montarse el componente
  }, []);

  useEffect(() => { // cambios en la lista de categorias afectan la lista de gastos
    // obtener la lista de gastos cuando cambia la lista de categorías
    getExpenseList();
  }, [listaDeCategorias]);


  // Create gasto
  const agregarGasto = async (concepto, monto, categoriaId) => {
    let data = {
      "concepto": concepto,
      "monto": monto,
      "categoriaId": categoriaId
    };

    let service = new ExpenseService();
    const gastoAgregado = await service.AddExpense(data);
    setListaDeGastos(await service.GetExpenses());
  };

  // Update gasto
  const actualizarGasto = async (gastoId, concepto, monto, categoriaId) => {
    let data = {
      "id": gastoId,
      "concepto": concepto,
      "monto": monto,
      "categoriaId": categoriaId
    };

    let service = new ExpenseService();
    const gastoActualizado = await service.UpdateExpense(data);
    setListaDeGastos(await service.GetExpenses());
  };

  // Delete gasto
  const eliminarGasto = async (gastoId) => {
    let service = new ExpenseService();
    const gastoActualizado = await service.DeleteExpense(gastoId);
    setListaDeGastos(await service.GetExpenses());
  };

  // Get all gastos
  const getExpenseList = async (options) => {
    let service = new ExpenseService();
    let expenses = await service.GetExpenses(options);
    if (expenses !== null) {
      setListaDeGastos(expenses)
    } else {
      setListaDeGastos([])
    }
  }

  // Get all categorias
  const getCategoryList = async () => {
    let service = new CategoryService();
    let categories = await service.GetCategories();
    if (categories !== null) {
      setListaDeCategorias(categories)
    } else {
      setListaDeCategorias([])
    }
  }

  return (
    <div className="app container">
      <NavBar />
      <div className="jumbotron">
        <h2 className="text-center mb-4">Gestor de Gastos</h2>
        <Agregar
          onAgregarGasto={agregarGasto}
          listaDeCategorias={listaDeCategorias}
        />
        <Historial 
          expenseList={listaDeGastos}
          categoryList={listaDeCategorias}
          onGetExpenseList={getExpenseList}
          onEliminarGasto={eliminarGasto}
          onActualizarGasto={actualizarGasto}
        />
      </div>
    </div>
  );
};

export default Gastos;
