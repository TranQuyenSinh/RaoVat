import DetailGenre from '@pages/admin/GenreManage/DetailGenre'
import { Counter } from '../components/Counter'
import { FetchData } from '../components/FetchData'
import GenreManage from '../pages/admin/GenreManage/GenreManage'
import Home from '../pages/admin/Home/Home'
import { Navigate } from 'react-router-dom'
import ApproveAd from '@pages/admin/ApproveAd/ApproveAd'
export const SystemPublicRoutes = [
    {
        index: 'admin',
        element: <Navigate to={'/admin/dashboard'} />,
    },
    {
        path: 'dashboard',
        element: <Home />,
    },
    {
        path: 'approve-ad',
        element: <ApproveAd />,
    },
    {
        path: 'genres',
        element: <GenreManage />,
    },
    {
        path: 'genres/:genreId',
        element: <DetailGenre />,
    },
]

export const SystemPrivateRoutes = [
    {
        path: 'counter',
        element: <Counter />,
    },
]
