import React from 'react'
import { Button, Table } from 'react-bootstrap'

const ItemList = (props) => {
  return (
    <>
      <h1>
        Showing {props.items ? props.items.length : 0} Item(s){' '}
        <Button variant="primary" className="pull-right" onClick={() => props.getItems()}>
          Refresh
        </Button>
      </h1>

      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Id</th>
            <th>Description</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {props.items &&
            props.items.length > 0 &&
            props.items.map((item) => (
              <tr key={item.guid}>
                <td>{item.guid}</td>
                <td>{item.description}</td>
                <td>
                  <Button variant="warning" size="sm" onClick={() => props.handleMarkAsComplete(item)}>
                    Mark as completed
                  </Button>
                </td>
              </tr>
            ))}
        </tbody>
      </Table>
    </>
  )
}

export default ItemList
