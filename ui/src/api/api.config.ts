import toast from 'react-hot-toast';
import { API_BASE_URL } from '../util/Constants';

export const _fetch = (url: string, options: any = {}) => {
  return new Promise((resolve, reject) => {
    const fetchData = {
      method: options?.method || 'GET',
      headers: {
        Authentication: `Bearer ${localStorage.getItem('token')}`,
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: options.body ? JSON.stringify(options.body) : undefined,
    };
    const api = API_BASE_URL + url;
    fetch(api, fetchData)
      .then((response) => {
        if (response.ok) {
          const json = response.json();
          if (json) {
            json
              .then((json) => resolve(json))
              .catch(() => {
                resolve(null);
              });
          }
        } else {
          response.json().then((json) => reject(json));
        }
      })
      .catch(() => {
        toast('Something went wrong.');
      });
  });
};
