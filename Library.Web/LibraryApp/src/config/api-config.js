let backendHost;

backendHost = 'https://localhost:44370';

export const API_ENDPOINTS = {root: `${backendHost}/api/`,
                               get: `${backendHost}/api/get`,
                               post: 'api/Books/PostAsync/',
                               getAll: 'api/Books/GetAllAsync',
                               delete: 'api/Books/DeleteAsync/'};