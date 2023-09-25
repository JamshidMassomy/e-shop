import React from 'react';

// router
import { Outlet, Route, Routes } from 'react-router-dom';
import PrivateRoute from '../auth/PrivateRoute';
import NotFound from '../container/error_page/NotFound';
import HomePage from '../container/home_page/HomePage';
import LoginPage from '../container/login_page/LoginPage';

export default function Router() {
  return (
    <Routes>
      <Route path="/login" element={<LoginPage />} />
      <Route path="/" element={<HomePage />} />
      <Route
        path="/"
        element={
          <PrivateRoute>
            {/* <Navbar />
            <div className="dashboard-content min-h-fit bg-gray-50">
              <Outlet />
            </div> */}
          </PrivateRoute>
        }
      >
        {/* <Route
          path="/"
          element={
            <PrivateRoute>
              <News />
            </PrivateRoute>
          }
        /> */}
      </Route>

      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}
