import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

function App() {
  const [books, setBooks] = useState([]);

  //return our data from the api
  useEffect(() => {
    axios.get('http://localhost:5000/api/books')
      .then(response => {
        console.log(response);
        setBooks(response.data);
      })
  }, [])

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <ul>
          <p>THIS IS ONLY FOR TESTING PURPOUSE</p>
          {books.map((book: any) => (
            <li key={book.id}>
              {book.title}
            </li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;
