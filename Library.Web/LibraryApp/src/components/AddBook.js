import React, { Component } from 'react';
import { API_CONFIG } from '../config/api-config.js';
import './AddBook.css';

export class AddBook extends Component {
  static displayName = "Test";

  constructor(props) {
    super(props);
    if(props.location.state == undefined){
      this.state = {
        book: {
          id:null,
          title: '',
          author: '',
          publisher: '',
          publishDate: null,
        }
      };
    }
    else{
      this.state = {book: props.location.state.book}
    }

    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleBlur = (field) => (evt) => {
    this.setState({
      touched: { ...this.state.touched, [field]: true },
    });
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

  saveBook(event) {

    if(this.state.book.title == '' || this.state.book.author == '')
      return;

    let endpointConfig = this.state.book.id == null ? API_CONFIG.post : API_CONFIG.edit;

    (async () => {
      const rawResponse = await fetch(endpointConfig.endpoint, {
        method: endpointConfig.method,
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.state.book)
      });
      const content = await rawResponse.json();
      if(content.statusCode = 200){
        event.preventDefault();
        this.props.history.push(`/list-books`);
      }
    })()
  }

  render() {
    return (
      <div style={{ marginTop: 10 }}>
        <h3>Add New Book</h3>
        <form onSubmit={this.onSubmit}>
          <div className="form-group">
            <label>Title:  </label> <label className='mark-required'> *</label>
            <input
              type="text"
              className="form-control"
              name="title"
              value={this.state.book.title}
              onChange={this.handleInputChange}
              required="required"
            />
          </div>
          <div className="form-group">
            <label>Author: </label> <label className='mark-required'> *</label>
            <input type="text"
              name="author"
              className="form-control"
              value={this.state.book.author}
              onChange={this.handleInputChange}
              required="required"
            />
          </div>
          <div className="form-group">
            <label>Publisher: </label>
            <input type="text"
              name="publisher"
              className="form-control"
              value={this.state.book.publisher}
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
            <input onClick={this.saveBook.bind(this)} type='submit' value="Save" className="btn btn-primary" />
          </div>
        </form>
      </div>
    );
  }
}
