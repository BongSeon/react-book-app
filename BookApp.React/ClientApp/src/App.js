import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import './custom.css'

import { BooksIndex } from './components/Books/BooksIndex';
import { BooksEdit } from './components/Books/BooksEdit';
import { BooksDelete } from './components/Books/BooksDelete';
import { BooksCreate } from './components/Books/BooksCreate';
import { Wheather } from './components/FetchTests/Wheather';
import { FetchRandomUser } from './components/FetchTests/FetchRandomUser';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
            <Route path='/fetch-data' component={FetchData} />
            <Route path={['/Books', '/Books/Index']} component={BooksIndex} exact />
            <Route path='/Books/Create' component={BooksCreate} exact={true} />
            <Route path='/Books/Edit/:id' component={BooksEdit} exact />
            <Route path='/Books/Delete/:id' component={BooksDelete} exact />
            <Route path='/Wheather' component={Wheather} />
            <Route path='/RandomUser' component={FetchRandomUser} />
      </Layout>
    );
  }
}
