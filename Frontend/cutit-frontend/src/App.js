import Loadable from 'react-loadable';
import React, { Component } from 'react';

import './App.css';
import '../node_modules/material-icons/iconfont/material-icons.css';

const Loading = () => <div>Page is loading...</div>;
const LinksPage = Loadable({
  loader: () => import('./containers/links'),
  loading: Loading
});

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <h1 className="App-title">Welcome to CutIt App</h1>
        </header>
        <LinksPage/>
      </div>
    );
  }
}

export default App;
