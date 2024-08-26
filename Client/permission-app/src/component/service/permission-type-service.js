import axios from 'axios';

const PERMISSION_TYPE_URL = 'https://localhost:5001/api/permissiontype';

export const fetchPermissionTypes = () => axios.get(PERMISSION_TYPE_URL+'/list').then(res => res.data);

export const createPermissionType = (permissionType) => axios.post(PERMISSION_TYPE_URL +'/add', permissionType).then(res => res.data);

export const updatePermissionType = (id, permissionType) => axios.put(`${PERMISSION_TYPE_URL+'/update'}/${id}`, permissionType).then(res => res.data);

export const deletePermissionType = (id) => axios.delete(`${PERMISSION_TYPE_URL+'remove'}/${id}`).then(() => id);