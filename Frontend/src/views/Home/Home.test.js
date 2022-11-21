import React from 'react'
import { cleanup, fireEvent, render } from '@testing-library/react'
import HomeView from './Home'

afterEach(cleanup)
it('should render without crashing', () => {
  render(<HomeView />)
})

it('should update state when typed on', () => {
  const { getByTestId } = render(<HomeView />)
  expect(getByTestId('descText')).toHaveValue('')
})
