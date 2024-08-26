import React, { useState } from 'react';
import { createPermissionType } from '../service/permission-type-service';
import '../permission-type/permission-type.css';


const PermissionTypeForm = ({ onSubmit, onCancel }) => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const handleSubmit = async (e) => {
    e.preventDefault();
    const newPermissionType = await createPermissionType({ name,description });
    onSubmit && onSubmit(newPermissionType);
    setName('');
  };

  return (
    <form onSubmit={handleSubmit} className="permission-type-form">
      <input
        type="text"
        value={name}
        onChange={(e) => setName(e.target.value)}
        placeholder="Permission Type Name"
        required/>
            <input
        type="text"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        placeholder="Permission Type Description"
        required
      />
      <button type="submit">Add Permission Type</button>
      {onCancel && <button type="button" onClick={onCancel}>Cancel</button>}
    </form>
  );
};

export default PermissionTypeForm;
