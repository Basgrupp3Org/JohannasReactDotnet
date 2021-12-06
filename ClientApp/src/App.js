import React, { useContext } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import HomePage from './components/Home/HomePage';
import HistoryPage from './components/History/HistoryPage';
import BudgetPage from './components/Budget/BudgetPage';
import './custom.css'
import { ThemeContext } from './Theme';

export default function App() {
  // const displayName = App.name;
  const { theme } = useContext(ThemeContext)

  // const MyComponent = (props) => {

  // }
  // MyComponent.displayName = App.name;
  return (
    <Layout >
      <Route exact path='/' component={Home} />
      <AuthorizeRoute path='/HomePage' component={HomePage} />
      <AuthorizeRoute path='/HistoryPage' component={HistoryPage} />
      <AuthorizeRoute path='/BudgetPage' component={BudgetPage} />
      <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
    </Layout>
  );
}

