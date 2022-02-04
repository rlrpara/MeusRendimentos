import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:63498'
});

export default api;