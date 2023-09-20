import { Counter } from '../components/Counter'
import { FetchData } from '../components/FetchData'
import { Home } from '../pages/customer/Home'

const SystemRoutes = [
    {
        index: 'system',
        element: <Home />,
    },
    {
        path: 'counter',
        element: <Counter />,
    },
    {
        path: 'fetch-data',
        element: <FetchData />,
    },
]

export default SystemRoutes
