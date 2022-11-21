import { render, screen } from '@testing-library/react'
import App from './App'
import { BrowserRouter } from 'react-router-dom'

test('renders the footer text', () => {
  render(
    <BrowserRouter>
      <App />
    </BrowserRouter>
  )
  const footerElement = screen.getByText(/clearpoint.digital/i)
  expect(footerElement).toBeInTheDocument()
})
