import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [books, setBooks] = useState([]);

  //return data from the api
  useEffect(() => {
    axios.get('http://localhost:5000/api/books')
      .then(response => {
        console.log(response);
        setBooks(response.data);
      })
  }, [])

  return (
    <div>
      <Header as='h2' icon='book' content='Recobookation' />
      <List>
        <p>THIS IS ONLY FOR TESTING PURPOUSE</p>
        {books.map((book: any) => (
          <List.Item key={book.id}>
            {book.title}
          </List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
