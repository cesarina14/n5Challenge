import React, { useState, useEffect } from 'react';
import { fetchPermissions, deletePermission, createPermission, updatePermission } from '../service/permission-service';
import { fetchPermissionTypes } from '../service/permission-type-service';
import PermissionForm from '../permision/permisison-form';
import PermissionTypeList from '../permission-type/permission-type-from';
import '../permision/permission-list.css';

const PermissionList = () => {
  const [permissions, setPermissions] = useState([]);
  const [permissionTypes, setPermissionTypes] = useState([]);
  const [editingPermission, setEditingPermission] = useState(null);

  useEffect(() => {
    const loadPermissions = async () => {
      const fetchedPermissions = await fetchPermissions();
      setPermissions(fetchedPermissions);
    };

    loadPermissions();
  }, []);
  useEffect(() => {
    const LoadPermissionTypes = async () => {
      const loadPermissionTypes = await fetchPermissionTypes();
      setPermissionTypes(loadPermissionTypes);
    };

    LoadPermissionTypes();
  }, []);

  const handleDelete = async (id) => {
    await deletePermission(id);
    setPermissions(permissions.filter(permission => permission.id !== id));
  };

  const handleUpdate = async (permission) => {
    const updatedPermission = await updatePermission(permission.id, permission);
    setPermissions(permissions.map(p => (p.id === permission.id ? updatedPermission : p)));
    setEditingPermission(null);
  };

  const handleCreate = async (permission) => {
    const newPermission = await createPermission(permission);
    setPermissions([...permissions, newPermission]);
  };

  return (
    <div>
      <h1>Permissions List</h1>
      {editingPermission && (
        <PermissionForm
          permission={editingPermission}
          permissionTypes={permissionTypes}
          onSubmit={handleUpdate}
          onCancel={() => setEditingPermission(null)}
        />
      )}
      <PermissionForm
        permissionTypes={permissionTypes}
        onSubmit={handleCreate}
      />
      <ul>
        {permissions.map(permission => (
          <li key={permission.id}>
            {permission.name} - {permission.description} (Type ID: {permission.permissionTypeId})
            <button onClick={() => setEditingPermission(permission)}>Edit</button>
            <button onClick={() => handleDelete(permission.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PermissionList;
