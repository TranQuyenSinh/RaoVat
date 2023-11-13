import { adApi } from '../api'
import { authAxios } from '../axios'

export const getAdStatusCount = () => {
    return authAxios.get(adApi.statusCount)
}

export const getDisplayAds = () => {
    return authAxios.get(adApi.displayAds)
}

export const getHiddenAds = () => {
    return authAxios.get(adApi.hiddenAds)
}

export const getExpiredAds = () => {
    return authAxios.get(adApi.expiredAds)
}

export const hideAd = adId => {
    return authAxios.get(adApi.hideAd, { params: { adId } })
}

export const showAd = adId => {
    return authAxios.get(adApi.showAd, { params: { adId } })
}

export const extendAd = adId => {
    return authAxios.get(adApi.extendAd, { params: { adId } })
}

export const deleteAd = adId => {
    return authAxios.get(adApi.deleteAd, { params: { adId } })
}
