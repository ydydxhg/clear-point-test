import React from 'react'
import { Navigate } from 'react-router-dom'
import HomeView from './views/Home/Home'
import NotFoundView from './views/Errors/NotFound'
const routes = [
  {
    path: '/',
    children: [
      { path: '404', element: <NotFoundView /> },
      {
        path: '/',
        element: <HomeView />,
      },
      { path: '*', element: <Navigate to="/404" /> },
    ],
  },
]

export default routes
