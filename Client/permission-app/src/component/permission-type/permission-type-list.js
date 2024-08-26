import React, { useState, useEffect } from 'react';
import { fetchPermissionTypes, deletePermissionType, createPermissionType, updatePermissionType } from '../service/permission-type-service';
import PermissionTypeForm from '../permission-type/permission-type-from';
import '../permission-type/permission-type-list.css';

const PermissionTypeList = () => {
  const [permissionTypes, setPermissionTypes] = useState([]);
  const [editingPermissionType, setEditingPermissionType] = useState(null);

  useEffect(() => {
    const loadPermissionTypes = async () => {
      const fetchedPermissionTypes = await fetchPermissionTypes();
      setPermissionTypes(fetchedPermissionTypes);
    };

    loadPermissionTypes();
  }, []);

  const handleDelete = async (id) => {
    await deletePermissionType(id);
    setPermissionTypes(permissionTypes.filter(permissionType => permissionType.id !== id));
  };

  const handleUpdate = async (permissionType) => {
    const updatedPermissionType = await updatePermissionType(permissionType.id, permissionType);
    setPermissionTypes(permissionTypes.map(pt => (pt.id === permissionType.id ? updatedPermissionType : pt)));
    setEditingPermissionType(null);
  };

  const handleCreate = async (permissionType) => {
    const newPermissionType = await createPermissionType(permissionType);
    setPermissionTypes([...permissionTypes, newPermissionType]);
  };

  return (
    <div>
      <h1>Permission Types List</h1>
      {editingPermissionType && (
        <PermissionTypeForm
          permissionType={editingPermissionType}
          onSubmit={handleUpdate}
          onCancel={() => setEditingPermissionType(null)}
        />
      )}
      <PermissionTypeForm
        onSubmit={handleCreate}
      />
      <ul>
        {permissionTypes.map(permissionType => (
          <li key={permissionType.id}>
            {permissionType.name} - {permissionType.description}
            <button onClick={() => setEditingPermissionType(permissionType)}>Edit</button>
            <button onClick={() => handleDelete(permissionType.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PermissionTypeList;
