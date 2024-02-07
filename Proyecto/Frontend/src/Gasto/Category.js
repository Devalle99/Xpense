import React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import UpdateIcon from '@mui/icons-material/Update';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import IconButton from '@mui/material/IconButton';
import Grid from '@mui/material/Grid';

// Asumiendo que 'react-router-dom' está instalado en tu proyecto
import { useEffect } from 'react';
import { CategoryService } from '../Servicios/CategoryService';
import { Navigate } from 'react-router-dom';


function Category() {
  const [open, setOpen] = React.useState(false);
  const [openDelete, setOpenDelete] = React.useState(false);
  const [nombre, setNombre] = React.useState("");
  const [categories, setCategories] = React.useState([])
  const [loggedIn, setLoggedIn] = React.useState(false)

  useEffect(() => {
    refreshList();
  }, []);

  const refreshList = async () => {
    let service = new CategoryService();
    // let categories = await service.GetCategories();
    let categories = [
      {
        "nombre": "Educación",
        "id": 1
      }
    ];
    setCategories(categories)
  }

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClickOpenDelete = () => {
    setOpenDelete(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleCloseDelete = () => {
    setOpenDelete(false);
  };

  const handleChangeNombre = (e) => {
    setNombre(e.target.value)
  }

  const handleAddCategory = () => {
    let data = {
      "nombre": nombre
    };

    let service = new CategoryService();
    service.AddCategory(data).then(x => {
      refreshList();
      setOpen(false)
    })
  };

  const handleDeleteCategory = () => {
    alert("Eliminado: " + nombre)
  };

  return (
    <Box sx={{ flexGrow: 1 }}>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <h3>Categorías de Gasto</h3>
        </Grid>
        <Grid item xs={12}>
          <Grid item lg={3}>
            <button className="btn btn-primary mt-2" onClick={handleClickOpen}>
              Agregar Categoria
            </button>
          </Grid>
        </Grid>
        <Grid item xs={12}>
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Id</TableCell>
                  <TableCell>Nombre</TableCell>
                  <TableCell>Acciones</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {categories.map(category => {
                  return (
                    <TableRow
                      key={category.id}
                      sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                    >
                      <TableCell component="th" scope="row">
                        {category.id}
                      </TableCell>
                      <TableCell component="th" scope="row">
                        {category.nombre}
                      </TableCell>
                      <TableCell component="th" scope="row">
                        <IconButton color="primary" aria-label="edit" component="label">
                          <UpdateIcon />
                        </IconButton>
                        <IconButton color="primary" aria-label="edit" component="label">
                          <DeleteForeverIcon />
                        </IconButton>
                      </TableCell>
                    </TableRow>
                  )
                })}

              </TableBody>
            </Table>
          </TableContainer>
        </Grid>
      </Grid>

      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          "Agregar nueva categoria"
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField placeholder='Nombre' value={nombre} onChange={handleChangeNombre} />
              </Grid>
            </Grid>
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>Cerrar</Button>
          <Button onClick={handleAddCategory} autoFocus>
            Agregar
          </Button>
        </DialogActions>
      </Dialog>

      <Dialog
        open={openDelete}
        onClose={handleCloseDelete}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          {"Eliminar categoria"}
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            <Grid container spacing={2}>
              <Grid item xs={12}>
                Esta seguro de eliminar este registro?
              </Grid>
            </Grid>
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDelete}>Cerrar</Button>
          <Button onClick={handleDeleteCategory} autoFocus>
            Eliminar
          </Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
}

export default Category;