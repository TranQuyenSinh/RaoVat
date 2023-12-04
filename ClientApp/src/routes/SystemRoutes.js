import DetailGenre from '@pages/admin/GenreManage/DetailGenre'
import { Counter } from '../components/Counter'
import { FetchData } from '../components/FetchData'
import GenreManage from '../pages/admin/GenreManage/GenreManage'
import Home from '../pages/admin/Home/Home'

export const SystemPublicRoutes = [
    {
        index: 'admin',
        element: <Home />,
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
