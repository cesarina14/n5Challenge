// src/api/axiosInstance.js
import axios from 'axios';

// Create an Axios instance with default settings
const api = axios.create({
  baseURL: 'https://https://localhost:5001/api', // Replace with your API base URL
  headers: {
    'Content-Type': 'application/json',
  },
});



export default api;
