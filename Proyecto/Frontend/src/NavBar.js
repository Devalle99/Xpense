import React from 'react';
import './NavBar.css'; // Importa el archivo CSS

function NavBar() {
  const scrollToSection = (sectionId) => {
    const section = document.getElementById(sectionId);
    if (section) {
      section.scrollIntoView({ behavior: 'smooth' });
    }
  };

  return (
    <nav style={{ backgroundColor: '#f0f0f0', padding: '10px 0', textAlign: 'center' }}>
      <button onClick={() => scrollToSection('agregar')}>Gestor de gastos</button>
      <button onClick={() => scrollToSection('graficoResumenFinanciero')}>Ver Gráfico</button> {/* Actualizado para usar el ID del gráfico */}
      <button onClick={() => scrollToSection('historial')}>Historial de gastos</button> {/* Nuevo botón para el Historial */}
    </nav>
  );
}

export default NavBar;
