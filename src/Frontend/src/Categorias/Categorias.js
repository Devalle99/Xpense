import NavBar from "../NavBar";
import { Form, Button, Row, Col, Table, Modal } from 'react-bootstrap';
import { useState, useEffect } from "react";
import { CategoryService } from '../Servicios/CategoryService';

function Categorias() {

  const [listaDeCategorias, setListaDeCategorias] = useState([]);

  // estado para crear
  const [nombre, setNombre] = useState('');
  // estado para actualizar
  const [showModalEditor, setShowModalEditor] = useState(false);
  const [editedCategory, setEditedCategory] = useState({});

  useEffect(() => {
    getCategoryList(); // al montarse el componente
  }, []);


  // Create categoria
  const agregarCategoria = async (nombre) => {
    let data = {
      "nombre": nombre
    };

    let service = new CategoryService();
    const categoriaAgregada = await service.AddCategory(data);
    setListaDeCategorias(await service.GetCategories());
  };

  // Update categoria
  const actualizarCategoria = async (categoriaId, nombre) => {
    let data = {
      "id": categoriaId,
      "nombre": nombre
    };

    let service = new CategoryService();
    const gastoActualizado = await service.UpdateCategory(data);
    setListaDeCategorias(await service.GetCategories());
  };

  // Delete categoria
  const eliminarCategoria = async (categoriaId) => {
    let service = new CategoryService();
    const categoriaActualizada = await service.DeleteCategory(categoriaId);
    setListaDeCategorias(await service.GetCategories());
  };

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

    agregarCategoria(nombre);
    setNombre('');
  };

  const handleUpdate = () => {
    const { id, nombre } = editedCategory;
    actualizarCategoria(parseInt(id, 10), nombre);
    handleCloseEditor();
  };

  return (
    <div className="app container">
      <NavBar />
      <div className="jumbotron">
        <h2 className="text-center mb-4">Gestor de Categorías</h2>

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
                  onChange={(e) => setNombre(e.target.value)}
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
            {listaDeCategorias.map((categoria) => (
              <tr key={categoria.id}>
                <td>{categoria.nombre}</td>
                <td>
                  <Button variant="secondary" size="sm" onClick={() => handleShowEditor(categoria)}>
                    Editar
                  </Button>
                  <Button variant="danger" size="sm" onClick={() => eliminarCategoria(categoria.id)}>
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
      </div>
    </div>
  );
};

export default Categorias;