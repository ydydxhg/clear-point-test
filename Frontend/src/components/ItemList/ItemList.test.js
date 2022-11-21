import React from 'react'
import { cleanup, screen, fireEvent, render } from '@testing-library/react'
import ItemList from './ItemList'
import renderer from 'react-test-renderer'

afterEach(cleanup)
it('should render without crashing', () => {
  render(<ItemList />)
})

it('should matches snapshot', () => {
  const tree = renderer
    .create(
      <ItemList
        items={[]}
        getItems={() => {
          return []
        }}
      />
    )
    .toJSON()
  expect(tree).toMatchSnapshot()
})

it('should mark as complete', () => {
  var item = {
    guid: '0000',
    description: 'test',
    isCompleted: false,
  }
  let handleComplete = jest.fn()
  render(
    <ItemList
      items={[item]}
      getItems={() => {
        return [item]
      }}
      handleMarkAsComplete={handleComplete}
    />
  )
  var button = screen.getByText('Mark as completed')
  fireEvent.click(button)
  expect(handleComplete).toHaveBeenCalledTimes(1)
})
