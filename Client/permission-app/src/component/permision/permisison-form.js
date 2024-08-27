import React, { useState, useEffect } from 'react';
import './permission.css';


const PermissionForm = ({ permission = {}, onSubmit, onCancel, permissionTypes }) => {
  const [name, setName] = useState(permission.name || '');
  const [description, setDescription] = useState(permission.description || '');
  const [permissionTypeId, setPermissionTypeId] = useState(permission.permissionTypeId || '');

  useEffect(() => {
    setName(permission.name || '');
    setDescription(permission.description || '');
    setPermissionTypeId(permission.permissionTypeId || '');
  }, [permission]);

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit({ ...permission, name, description, permissionTypeId });
  };

  return (
    <form onSubmit={handleSubmit} className="permission-form">
      <input
        type="text"
        value={name}
        onChange={(e) => setName(e.target.value)}
        placeholder="Name"
        required
      />
      <input
        type="text"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        placeholder="Description"
        required
      />
      <select
        value={permissionTypeId}
        onChange={(e) => setPermissionTypeId(e.target.value)}
        required
      >
        <option value="" disabled>Select Permission Type</option>
        {permissionTypes.map(type => (
          <option key={type.id} value={type.id}>{type.description}</option>
        ))}
      </select>
      <button type="submit">{permission.id ? 'Update' : 'Add'} Permission</button>
      {onCancel && <button type="button" onClick={onCancel}>Cancel</button>}
    </form>
  );
};

export default PermissionForm;
