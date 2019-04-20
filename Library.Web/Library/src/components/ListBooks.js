import React, { Component } from 'react';
import { AddBook } from './AddBook';
import { API_ENDPOINTS } from '../config/api-config.js';

export class ListBooks extends Component {
  static displayName = "Test";

  constructor (props) {
    super(props);
    this.state = { books: [], loading: true, modalShow: false };

    var myHeaders = new Headers();

    var myInit = { method: 'GET',
                    headers: myHeaders,
                    mode: 'cors',
                    cache: 'default' };

      fetch(API_ENDPOINTS.getAll, myInit )
      .then(response => response.json())
      .then(data => {
          console.log(data)
          this.setState({ books: data, loading: false });
      });
  }

  static renderBooksTable (books) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Title</th>
            <th>Subtitle</th>
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
              <td>{book.subtitle}</td>
              <td>{book.author}</td>
              <td>{book.publisher}</td>
              <td>{book.publishDate}</td>
              <td><button type="button" className="btn btn-danger">Delete</button></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : ListBooks.renderBooksTable(this.state.books);

    return (
      <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <button type="button" className="btn btn-primary">Add Book</button>

        <AddBook 
          show={this.state.modalShow}
          onHide={modalClose}/>

        <DeleteBook
          show={this.state.modalShow}
          onHide={modalClose}
        />
        <p></p>
        {contents}
      </div>
    );
  }
}
