import { Counter } from '../components/Counter'
import DetailAd from '../pages/customer/DetailAd/DetailAd'
import { Home } from '../pages/customer/Home'

export const CustomerPublicRoutes = [
    {
        index: true,
        element: <Home />,
    },
    {
        path: 'tin-dang/:adId',
        element: <DetailAd />,
    },
]

export const CustomerPrivateRoutes = [
    {
        path: 'counter',
        element: <Counter />,
    },
]
