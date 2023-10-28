import { Counter } from '../components/Counter'
import { Home } from '../pages/customer/Home'
import DetailAd from '../pages/customer/DetailAd/DetailAd'
import PostAdForm from '../pages/customer/PostAd/PostAdForm'
import { SpecifyGenre } from '../pages/customer/SpecifyGenre/SpecifyGenre'

export const CustomerPublicRoutes = [
    {
        index: true,
        element: <Home />,
    },
    {
        path: 'tin-dang/:adId',
        element: <DetailAd />,
    },
    {
        path: ':genreSlug',
        element: <SpecifyGenre />,
    },
]

export const CustomerPrivateRoutes = [
    {
        path: 'counter',
        element: <Counter />,
    },
    {
        path: 'dang-tin',
        element: <PostAdForm />,
    },
]
