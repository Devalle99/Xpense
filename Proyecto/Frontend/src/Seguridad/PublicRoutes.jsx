import { Outlet, Navigate } from 'react-router-dom'
import { useAuth } from '../Servicios/AuthService'

function PublicRoutes() {
    const token = useAuth()
    return token ? <Navigate to='/inicio' /> : <Outlet />
}

export default PublicRoutes