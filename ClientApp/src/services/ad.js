import axios from '../axios'
import { adApi } from '../api'

export const getLatestCardAds = ({ currentIndex, province }) => {
    return axios.get(adApi.getCardAds, { params: { type: 'latest', p: province, i: currentIndex } })
}
