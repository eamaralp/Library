import React, { Component } from 'react';
import { DatePicker } from 'react-datepicker';
import { API_ENDPOINTS } from '../config/api-config.js';

export class AddBook extends Component {
  static displayName = "Test";

  constructor(props) {
    super(props);
    this.state = {
      book: {
        title: '',
        author: '',
        publisher: '',
        publishDate: null,
      }
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleShow = this.handleShow.bind(this);
    this.handleClose = this.handleClose.bind(this);
  }

  handleClose() {
    this.setState({ show: false });
  }

  handleShow() {
    this.setState({ show: true });
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;

    this.setState(prevState => ({
      book: {
        ...prevState.book,
        [name]: value
      }
    }))
  }

  saveBook() {
    (async () => {
      const rawResponse = await fetch(API_ENDPOINTS.post, {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.state.book)
      });
      const content = await rawResponse.json();

      console.log(content);
    })();
  }

  render() {
    return (
      <div style={{ marginTop: 10 }}>
        <h3>Add New Book</h3>
        <form onSubmit={this.onSubmit}>
          <div className="form-group">
            <label>Title:  </label>
            <input
              type="text"
              className="form-control"
              name="title"
              value={this.state.title}
              onChange={this.handleInputChange}
            />
          </div>
          <div className="form-group">
            <label>Author: </label>
            <input type="text"
              name="author"
              className="form-control"
              value={this.state.author}
              onChange={this.handleInputChange}
            />
          </div>
          <div className="form-group">
            <label>Authos: </label>
            <input type="text"
              name="publisher"
              className="form-control"
              value={this.state.publisher}
              onChange={this.handleInputChange}
            />
          </div>

          <div className="form-group">
            <label>Publish Date: </label>
            <input type="date" data-date-format="YYYY"
              name="publishDate"
              className="form-control"
              value={this.state.publishDate}
              onChange={this.handleInputChange}
            />
          </div>
          <div className="form-group">
            <input onClick={this.saveBook.bind(this)} type="submit" value="Save" className="btn btn-primary" />
          </div>
        </form>
      </div>
    );
  }
}
