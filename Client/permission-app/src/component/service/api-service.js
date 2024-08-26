import axios from 'axios';
import api from '../../api';
const Url = api.API_URL;
export const fetchItems = () => axios.get(Url).then(res => res.data);

export const createItem = (item) => axios.post(Url, item).then(res => res.data);

export const updateItem = (id, item) => axios.put(`${Url}/${id}`, item).then(res => res.data);

export const deleteItem = (id) => axios.delete(`${Url}/${id}`).then(() => id);