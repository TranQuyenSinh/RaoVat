import { axios } from '../axios'
import { adApi } from '../api'

export const getLatestCardAds = (index, province, genreSlug) => {
    return axios.get(adApi.getCardAds, { params: { type: 'latest', p: province, i: index, genreSlug: genreSlug } })
}

export const getRelatedCardAds = shopId => {
    return axios.get(adApi.getCardAdsRelated, { params: { type: 'related', shopId } })
}

export const getSimilarAd = adId => {
    return axios.get(adApi.getCardAdsSimilar, { params: { type: 'similar', adId } })
}

export const getDetailAd = (adId, userId = null) => {
    return axios.get(adApi.getDetailAd, { params: { id: adId, userId } })
}

export const saveAdToFavorite = (userId, adId) => {
    return axios.put(adApi.saveAdToFavorite, { userId, adId })
}

export const followShop = (userId, shopId) => {
    return axios.put(adApi.followShop, { userId, shopId })
}
