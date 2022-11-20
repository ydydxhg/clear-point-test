import './App.css'
import { useRoutes } from 'react-router-dom'
import React from 'react'
import routes from './routes'

const App = () => {
  const routing = useRoutes(routes)
  return (
    <div className="App">
      {routing}

      <footer className="page-footer font-small teal pt-4">
        <div className="footer-copyright text-center py-3">
          © 2021 Copyright:
          <a href="https://clearpoint.digital" target="_blank" rel="noreferrer">
            clearpoint.digital
          </a>
        </div>
      </footer>
    </div>
  )
}

export default App
