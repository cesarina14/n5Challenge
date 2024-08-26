import React, { useState } from 'react';
import PermissionList from './component/permision/permision-list'; 
import PermissionTypeList from './component/permission-type/permission-type-list'; 
import './style.css'; // Add your styles here

const App = () => {
  const [activeTab, setActiveTab] = useState('permissions');

  return (
    <div className="app">
      <div className="tabs">
        <button
          className={`tab-button ${activeTab === 'permissions' ? 'active' : ''}`}
          onClick={() => setActiveTab('permissions')}
        >
          Permissions
        </button>
        <button
          className={`tab-button ${activeTab === 'permissionTypes' ? 'active' : ''}`}
          onClick={() => setActiveTab('permissionTypes')}
        >
          Permission Types
        </button>
      </div>
      <div className="tab-content">
        {activeTab === 'permissions' && <PermissionList />}
        {activeTab === 'permissionTypes' && <PermissionTypeList />}
      </div>
    </div>
  );
};

export default App;
