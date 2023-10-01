import { Counter } from '../components/Counter'
import { Home } from '../pages/customer/Home'

export const CustomerPublicRoutes = [
    {
        index: true,
        element: <Home />,
    },
]

export const CustomerPrivateRoutes = [
    {
        path: 'counter',
        element: <Counter />,
    },
]
