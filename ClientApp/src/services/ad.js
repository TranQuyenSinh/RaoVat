import { axios } from '../axios'
import { adApi } from '../api'

export const getLatestCardAds = ({ currentIndex, province }) => {
    return axios.get(adApi.getCardAds, { params: { type: 'latest', p: province, i: currentIndex } })
}

export const getDetailAd = adId => {
    return axios.get(adApi.getDetailAd, { params: { id: adId } })
}
