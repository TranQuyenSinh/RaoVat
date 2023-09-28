import axios from 'axios'

export const getAllLocations = async () => {
    let { data } = await axios.get('https://provinces.open-api.vn/api/p/')
    return data.map(item => item.name)
}
