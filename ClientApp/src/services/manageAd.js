import { adApi } from '../api'
import { authAxios } from '../axios'

export const getAdStatusCount = () => {
    return authAxios.get(adApi.statusCount)
}

export const getDisplayAds = () => {
    return authAxios.get(adApi.displayAds)
}

export const hideAd = (adId, isHide) => {
    return authAxios.get(adApi.hideAd, { params: { adId, isHide } })
}

export const getHiddenAds = () => {
    return authAxios.get(adApi.hiddenAds)
}
