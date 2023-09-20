import axios from 'axios'

const instance = axios.create({
    baseURL: process.env.ASPNET_SERVER_URL || 'https://localhost:8080',
    timeout: 10000,
})

export default instance
