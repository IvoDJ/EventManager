import axios from 'axios'

const api = axios.create({
  baseURL: 'https://eventmanager-3fov.onrender.com'
})

export default api
