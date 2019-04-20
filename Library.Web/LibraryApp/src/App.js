import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { ListBooks } from './components/ListBooks';
import { Counter } from './components/Counter';
import { API_ENDPOINTS } from './config/api-config.js';
import { AddBook } from './components/AddBook';

export default class App extends Component {
  static displayName = App.name;
  static endpoints = API_ENDPOINTS;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/list-books' component={ListBooks} />
        <Route path='/add-book' component={AddBook} />
      </Layout>
    );
  }
}
