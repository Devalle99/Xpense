import React, { useEffect, useState } from 'react';
import { Bar } from 'react-chartjs-2';
import { Chart, BarElement, CategoryScale, LinearScale, Tooltip, Legend } from 'chart.js';
import { ExpenseService } from '../Servicios/ExpenseService';

const Graficos = () => {

  Chart.register(BarElement, CategoryScale, LinearScale, Tooltip, Legend);

  const [data, setData] = useState({});

  useEffect(() => {
    getChartData();
  }, []);

  const getChartData = async (startDate, endDate) => {
    let service = new ExpenseService();
    let datos = await service.GetChartData();
    if (datos !== null) {
      setData(datos)
    } else {
      setData({})
    }
  }

  // Convertir el objeto de datos en dos arrays: uno para las etiquetas y otro para los valores
  const labels = Object.keys(data);
  const values = Object.values(data);

  // Crear la estructura de datos para Chart.js
  const chartData = {
    labels: labels,
    datasets: [{
      label: 'Gasto total por categoría',
      data: values,
      backgroundColor: 'rgba(75,192,192,0.4)',
      borderColor: 'rgba(75,192,192,1)',
      borderWidth: 1,
      hoverBackgroundColor: 'rgba(75,192,192,0.7)',
      hoverBorderColor: 'rgba(75,192,192,1)'
    }]
  };

  return (
    <>
      <h3>{"Gráfico de Gastos por Categoría"}</h3>
      {Object.keys(data).length === 0 ?
        "No hay datos para generar un gráfico" :
        <div style={{height: '500px'}}>
          <Bar
            data={chartData}
            options={{
              maintainAspectRatio: false,
              scales: {
                y: {
                  beginAtZero: true
                }
              }
            }}
          />
        </div>
      }
    </>
  );
};

export default Graficos;
