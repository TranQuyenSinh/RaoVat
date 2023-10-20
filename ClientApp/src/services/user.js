import { axios } from '../axios'
import { userApi } from '../api'

export const getDetailShop = (shopId, userId = null) => {
    return axios.get(userApi.getDetailShop, { params: { shopId, userId } })
}
