import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { ListBooks } from './components/ListBooks';
import { AddBook } from './components/AddBook';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={ListBooks} />
        <Route path='/list-books' component={ListBooks} />
        <Route path='/add-book' component={AddBook} />
      </Layout>
    );
  }
}
