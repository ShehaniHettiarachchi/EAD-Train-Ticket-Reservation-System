import React from 'react';

import Link from '../Link/Link';

const footer = () => {
  return (
    <footer className=''>
      <div className='container text-light pt-5'>
        <div className='row'>
          <div className='col-sm-6 col-md-6 col-lg-4 mb-5'>
            <div className='footer-title'>
              <h6>About Us</h6>
            </div>
            <div className='footer-content'>
              <p>
                <small >
                  Aenean suscipit eget mi act fermentum phasellus vulputate
                  turpis tincidunt. Aenean suscipit eget. Aenean suscipit eget
                  mi act fermentum phasellus vulputate turpis tincidunt. Aenean
                  suscipit ege Aenean suscipit eget mi act fermentum phasellus.
                </small>
              </p>
              <button className='btn btn-sm btn-primary rounded-0'>
                Learn more
              </button>
            </div>
          </div>
          <div className='col-sm-6 col-md-6 col-lg-2 mb-5'>
           
          </div>
          <div className='col-sm-6 col-md-6 col-lg-3 mb-5'>
            
          </div>
          <div className='col-sm-6 col-md-6 col-lg-3 mb-5'>
            <div className='footer-title'>
              <h6>Contact Us</h6>
            </div>
            <div className='footer-content'>
              <p >
                <small>Address : 123 main street</small>
              </p>
              <p >
                <small>Phone : +213 (0) 123 456 789</small>
              </p>
              <p >
                <small>E-mail : contact@email.com</small>
              </p>
              <div className='social-media mt-4'>
                <a href='!#' className='text-light'>
                  <i className='fab fa-facebook-f mr-4' />
                </a>
                <a href='!#' className='text-light'>
                  <i className='fab fa-twitter mr-4' />
                </a>
                <a href='!#' className='text-light'>
                  <i className='fab fa-instagram mr-4' />
                </a>
                <a href='!#' className='text-light'>
                  <i className='fab fa-github' />
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className='bottom-footer pt-3 pb-3 text-center'>
        <small>© All Right Reserved.</small>
      </div>
    </footer>
  );
};

export default footer;
