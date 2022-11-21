import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import axios from 'axios'
import { Image, Alert, Button, Container, Row, Col, Form, Table, Stack, ProgressBar } from 'react-bootstrap'
import { homeStore } from './homeStore'
import ItemList from '../../components/ItemList/ItemList'
import { GET_ITEMS_REQUESTED, ADD_ITEM_REQUESTED, COMPLETE_ITEM_REQUESTED } from './homeReducer'

const HomeView = () => {
  const [description, setDescription] = useState('')
  const [items, setItems] = useState([])
  const [loading, setLoading] = useState(false)
  useEffect(() => {
    homeStore.dispatch({
      type: GET_ITEMS_REQUESTED,
      payload: {},
    })
    const unsubscribe = homeStore.subscribe((r) => {
      let homeState = homeStore.getState()
      console.log('items', homeState)
      setItems(homeState.items)
      setLoading(homeState.setLoading)
      setDescription(homeState.currentItem)
    })
    return unsubscribe
  }, [])

  const renderAddTodoItemContent = () => {
    return (
      <Container>
        <h1>Add Item</h1>
        <Form.Group as={Row} className="mb-3" controlId="formAddTodoItem">
          <Form.Label column sm="2">
            Description
          </Form.Label>
          <Col md="6">
            <Form.Control
              data-testid="descText"
              type="text"
              placeholder="Enter description..."
              value={description}
              onChange={handleDescriptionChange}
            />
          </Col>
        </Form.Group>
        <Form.Group as={Row} className="mb-3 offset-md-2" controlId="formAddTodoItem">
          <Stack direction="horizontal" gap={2}>
            <Button variant="primary" onClick={() => handleAdd()}>
              Add Item
            </Button>
            <Button variant="secondary" onClick={() => handleClear()}>
              Clear
            </Button>
          </Stack>
        </Form.Group>
      </Container>
    )
  }

  const handleDescriptionChange = (event) => {
    setDescription(event.target.value)
  }

  async function getItems() {
    try {
      homeStore.dispatch({
        type: GET_ITEMS_REQUESTED,
        payload: {},
      })
    } catch (error) {
      console.error(error)
    }
  }

  async function handleAdd() {
    try {
      homeStore.dispatch({
        type: ADD_ITEM_REQUESTED,
        payload: {
          Description: description,
        },
      })
    } catch (error) {
      console.error(error)
    }
  }

  function handleClear() {
    setDescription('')
  }

  async function handleMarkAsComplete(item) {
    try {
      homeStore.dispatch({
        type: COMPLETE_ITEM_REQUESTED,
        payload: item,
      })
    } catch (error) {
      console.error(error)
    }
  }

  return (
    <div>
      <Container>
        <Row>
          <Col>
            <Image src="clearPointLogo.png" fluid rounded />
          </Col>
        </Row>
        <Row>
          <Col>
            <Alert variant="success">
              <Alert.Heading>Todo List App</Alert.Heading>
              Welcome to the ClearPoint frontend technical test. We like to keep things simple, yet clean so your
              task(s) are as follows:
              <br />
              <br />
              <ol className="list-left">
                <li>Add the ability to add (POST) a Todo Item by calling the backend API</li>
                <li>
                  Display (GET) all the current Todo Items in the below grid and display them in any order you wish
                </li>
                <li>
                  Bonus points for completing the 'Mark as completed' button code for allowing users to update and mark
                  a specific Todo Item as completed and for displaying any relevant validation errors/ messages from the
                  API in the UI
                </li>
                <li>Feel free to add unit tests and refactor the component(s) as best you see fit</li>
              </ol>
              {loading && <ProgressBar striped now={50} />}
            </Alert>
          </Col>
        </Row>
        <Row>
          <Col>{renderAddTodoItemContent()}</Col>
        </Row>
        <br />
        <Row>
          <Col>
            <ItemList items={items} getItems={getItems} handleMarkAsComplete={handleMarkAsComplete} />
          </Col>
        </Row>
      </Container>
    </div>
  )
}

export default HomeView
