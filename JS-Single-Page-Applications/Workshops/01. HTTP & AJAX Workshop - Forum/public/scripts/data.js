var data = (function () {
  const USERNAME_STORAGE_KEY = 'username-key';
  const URL = 'http://localhost:1509/api/threads';

  // start users
  function userLogin(user) {
    localStorage.setItem(USERNAME_STORAGE_KEY, user);
    return Promise.resolve(user);
  }

  function userLogout() {
    localStorage.removeItem(USERNAME_STORAGE_KEY)
    return Promise.resolve();
  }

  function userGetCurrent() {
    return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
  }
  // end users

  // start threads
  function threadsGet() {
    return new Promise((resolve, reject) => {
      $.getJSON('api/threads')
        .done(resolve)
        .fail(reject);
    });
  }

  let $inputTitle = $('#input-add-thread');

  function threadsAdd(title) {
    let promise = new Promise((resolve, reject) => {
      $.ajax(URL, {
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ title }),
        success: function (response) {
          resolve(response);
        },
        error: function (err) {
          reject(err);
        }
      });
    });
    return promise;
  }

  function threadById(id) {
    let promise = new Promise((resolve, reject) => {
      $.ajax(URL + `/${id}`, {
        method: 'GET',
        contentType: 'application/json',
        success: function (response) {
          resolve(response);
        },
        error: function (err) {
          reject(err);
        }
      });
    });

    return promise;
  }

  function getUser(user) {
    userGetCurrent()
      .then(function (value) {
        user.name = value;
        console.log(value);
      })
      .then();
  }

  function threadsAddMessage(threadId, content) {
    return userGetCurrent()
      .then(function (username) {
        let promise = new Promise((resolve, reject) => {
          $.ajax(URL + `/${threadId}/messages`, {
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
              content,
              username
            }),
            success: function (response) {
              resolve(threadId);
            },
            error: function (err) {
              reject(err);
            }
          });
        });

        return promise;
      });
  }
  // end threads

  // start gallery
  function galleryGet() {
    const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;
    let promise = new Promise((resolve) => {
      $.getJSON(REDDIT_URL, function (json) {
        resolve(json);
      });
    });

    return promise;
  }
  // end gallery

  return {
    users: {
      login: userLogin,
      logout: userLogout,
      current: userGetCurrent
    },
    threads: {
      get: threadsGet,
      add: threadsAdd,
      getById: threadById,
      addMessage: threadsAddMessage
    },
    gallery: {
      get: galleryGet,
    }
  }
})();