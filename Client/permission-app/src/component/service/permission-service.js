import axios from 'axios';

const API_URL = 'https://localhost:5001/api/permission';

export const fetchPermissions = () => axios.get(API_URL+'/list').then(res => res.data);

export const createPermission = (permission) => axios.post(API_URL+'/add', permission).then(res => res.data);

export const updatePermission = (id, permission) => axios.put(`${API_URL+'/update'}/${id}`, permission).then(res => res.data);

export const deletePermission = (id) => axios.delete(`${API_URL+'/remove'}/${id}`).then(() => id);
