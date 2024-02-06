import React from "react";
import { Bar } from 'react-chartjs-2';
import Chart from 'chart.js/auto';

function Graficos({ historial, presupuestoTotal }) {
    const totalGastado = historial.reduce((acc, gasto) => acc + gasto.monto, 0);
    const saldoRestante = presupuestoTotal - totalGastado; // Calcular el saldo restante

    // Preparar etiquetas y datos para el gráfico
    const etiquetas = ['Total Gastado', 'Saldo Restante'];

    // Asegurar que el eje Y se ajuste para mostrar un poco más allá del valor máximo
    const maximoValor = Math.max(presupuestoTotal, totalGastado);
    const margenSuperior = maximoValor * 0.1; // 10% más para asegurar visibilidad

    const data = {
        labels: etiquetas,
        datasets: [
            {
                label: 'Resumen',
                data: [totalGastado, saldoRestante >= 0 ? saldoRestante : 0], // Asegurar que el saldo no sea negativo en el gráfico
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(75, 192, 192, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(75, 192, 192, 1)'
                ],
                borderWidth: 1,
            }
        ]
    };

    const options = {
        scales: {
            y: {
                beginAtZero: true,
                max: maximoValor + margenSuperior, // Configurar el máximo dinámicamente
            }
        },
        plugins: {
            tooltip: {
                callbacks: {
                    label: function(context) {
                        let label = context.dataset.label || '';
                        if (label) {
                            label += ': $';
                        }
                        if (context.parsed.y !== null) {
                            label += context.parsed.y;
                        }
                        return label;
                    }
                }
            }
        }
    };

    return (
        <div id="graficoResumenFinanciero"> {/* Agrega el ID aquí */}
            <h3>Resumen Financiero</h3>
            <Bar data={data} options={options} />
        </div>
    );
}

export default Graficos;

