import { Form, Button, Row, Col, Table, Modal } from 'react-bootstrap';
import { useState } from "react";

function Category({
  categoryList,
  onAgregarCategoria,
  onActualizarCategoria,
  onEliminarCategoria,
  onGetExpenseList
}) {

  // estado para crear
  const [nombre, setNombre] = useState('');
  // estado para actualizar
  const [showModalEditor, setShowModalEditor] = useState(false);
  const [editedCategory, setEditedCategory] = useState({});

  const handleNombreChange = (e) => {
    setNombre(e.target.value);
  };

  const handleShowEditor = (category) => {
    setEditedCategory(category);
    setShowModalEditor(true);
  };

  const handleCloseEditor = () => {
    setEditedCategory({});
    setShowModalEditor(false);
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    onAgregarCategoria(nombre);
    setNombre('');
  };

  const handleUpdate = () => {
    const { id, nombre } = editedCategory;
    onActualizarCategoria(parseInt(id, 10), nombre);
    handleCloseEditor();
  };

  const handleDelete = (categoryId) => {
    onEliminarCategoria(categoryId);
  }

  return (
    <div>
      <h3>Gestionar Categorías</h3>

      {/* Form para agregar */}
      <Form onSubmit={handleSubmit}>
        <Row>
          <Col md={4}>
            <Form.Group>
              <Form.Label>Nombre</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese el nombre"
                value={nombre}
                onChange={(e) => handleNombreChange(e)}
                required
              />
            </Form.Group>
          </Col>
        </Row>
        <div className="mb-4 mt-2">
          <Button type="submit" variant="primary">
            Guardar Categoría
          </Button>
        </div>
      </Form>

      {/* Tabla de categorias */}
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {categoryList.map((categoria) => (
            <tr key={categoria.id}>
              <td>{categoria.nombre}</td>
              <td>
                <Button variant="secondary" size="sm" onClick={() => handleShowEditor(categoria)}>
                  Editar
                </Button>
                <Button variant="danger" size="sm" onClick={() => handleDelete(categoria.id)}>
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
          <Modal.Title>Editar Categoría</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="formNombre">
              <Form.Label>Nombre</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese el nuevo nombre"
                value={editedCategory.nombre || ''}
                onChange={(e) => setEditedCategory({ ...editedCategory, nombre: e.target.value })}
              />
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
    </div >
    
  );
}

export default Category;