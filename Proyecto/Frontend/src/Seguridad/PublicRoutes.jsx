import { Outlet, Navigate } from 'react-router-dom'
import { useAuth } from '../Servicios/AuthService'

function PublicRoutes() {
    const token = useAuth()
    return token ? <Navigate to='/gastos' /> : <Outlet />
}

export default PublicRoutes