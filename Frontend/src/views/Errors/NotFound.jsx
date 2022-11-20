import React, { useEffect, useState } from 'react'
import '../../App.css'
import { Image, Alert, Button, Container, Row, Col, Form, Table, Stack } from 'react-bootstrap'
import { useParams } from 'react-router-dom'

const NotFoundView = () => {
  return (
    <Container>
      <Row>
        <Col>
          <Image src="clearPointLogo.png" fluid rounded />
        </Col>
      </Row>
      <Row>
        <Col>
          <Alert variant="error">
            <Alert.Heading>Page not found</Alert.Heading>
            Cannot find the page you are looking for, please check the url
          </Alert>
        </Col>
      </Row>
    </Container>
  )
}

export default NotFoundView
