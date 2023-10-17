import { Counter } from '../components/Counter'
import { Home } from '../pages/customer/Home'
import DetailAd from '../pages/customer/DetailAd/DetailAd'
import PostAd from '../pages/customer/PostAd/PostAd'

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
    {
        path: 'dang-tin',
        element: <PostAd />,
    },
]
