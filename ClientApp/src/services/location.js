import axios from 'axios'

export const getAllLocations = () => {
    return axios.get('https://provinces.open-api.vn/api/p/')
}
