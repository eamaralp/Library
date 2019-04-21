import React, { Component } from 'react';
import { Redirect } from 'react-router-dom'
import { API_ENDPOINTS } from '../config/api-config.js';

export class ListBooks extends Component {
  static displayName = "Test";
  
  constructor (props) {
    super(props);
    this.state = { books: [], loading: true, modalShow: false };

    this.deleteBook = this.deleteBook.bind(this);

      fetch(API_ENDPOINTS.getAll)
      .then(response => response.json())
      .then(data => {
          this.setState({ books: data, loading: false });
      });
  }

  addBook = () => {
    this.props.history.push(`/add-book`);
  }

  deleteBook = bookId => {
    fetch(API_ENDPOINTS.delete + bookId, { method: 'delete'})
    .then(response => response.json())
  
    window.location.reload();
  };

  renderBooksTable (books) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Publisher</th>
            <th>Publish Date</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {books.map(book =>
              <tr key={book.id}>
              <td>{book.title}</td>
              <td>{book.author}</td>
              <td>{book.publisher}</td>
              <td>{book.publishDate}</td>
              <td>
                <div>
                  <button onClick={() => this.deleteBook(book.id)}  className="btn btn-danger">Delete</button>
                </div>
                <div>
                <button onClick={() => this.deleteBook(book.id)}  className="btn btn-primary">Edit</button>
                </div>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {

    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : this.renderBooksTable(this.state.books);

    return (
      <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <button onClick={this.addBook}  className="btn btn-primary">Add Book</button>
        <p></p>
        {contents}
      </div>
    );
  }
}
