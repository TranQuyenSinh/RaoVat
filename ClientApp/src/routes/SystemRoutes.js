import { Counter } from '../components/Counter'
import { FetchData } from '../components/FetchData'
import { Home } from '../pages/customer/Home'

export const SystemPublicRoutes = [
    {
        index: 'system',
        element: <Home />,
    },
    {
        path: 'fetch-data',
        element: <FetchData />,
    },
]

export const SystemPrivateRoutes = [
    {
        path: 'counter',
        element: <Counter />,
    },
]
