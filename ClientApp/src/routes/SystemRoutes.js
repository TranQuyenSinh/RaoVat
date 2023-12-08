import DetailGenre from '@pages/admin/GenreManage/DetailGenre'
import GenreManage from '../pages/admin/GenreManage/GenreManage'
import Home from '../pages/admin/Home/Home'
import { Navigate } from 'react-router-dom'
import ApproveAd from '@pages/admin/ApproveAd/ApproveAd'
import BannerManage from '@pages/admin/BannerManage/BannerManage'
export const SystemPrivateRoutes = [
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
    {
        path: 'banners',
        element: <BannerManage />,
    },
]
