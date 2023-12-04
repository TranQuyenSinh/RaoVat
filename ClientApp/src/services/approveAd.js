import { authAxios, axios } from '../axios'
import { adApi, approveAdApi } from '../api'

export const getWaitingApproveAds = () => {
    return authAxios.get(approveAdApi.getWaitingApproveAds)
}
