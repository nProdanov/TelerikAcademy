describe('usersModel Tests', () => {
    describe('Register tests', () => {
        beforeEach(function () {
            sinon.stub(CryptoJS, 'SHA1', (password) => {
                return hash;
            });
            sinon.stub(app.requester, 'post', (url, options) => {
                return new Promise((resolve, reject) => {
                    if (url !== 'api/users') {
                        reject(new Error(`Invalid url ${url}`));
                        return;
                    }
                    if (options.data.passHash !== hash) {
                        reject(new Error('Password is not hashed correctly'));
                    }
                    const props = Object.keys(options.data).sort();
                    if (props.length != 2 || props[0] !== 'passHash' || props[1] !== 'username') {
                        reject(new Error('Requested user data is not valid'));
                    }
                    resolve(response);
                });
            });
        });
        afterEach(function () {
            app.requester.post.restore();
            CryptoJS.SHA1.restore();
        });

        const hash = 'asjkhfjhafaaafa';

        const response = {
            username: '',
            authKey: ''
        };
        const user = {
            username: 'alsdlajdlajdaladsa',
            password: '123'
        };

        it('usersModel.register should return correct response', function (done) {
            app.usersModel.register(user)
                .then(actual => {
                    expect(actual).to.eql(response);
                })
                .then(done, done);
        });

    });

    describe('Login Tests', () => {
        beforeEach(function () {
            sinon.stub(CryptoJS, 'SHA1', (password) => {
                return hash;
            });
            sinon.stub(app.requester, 'put', (url, options)=>{
                return new Promise((resolve, reject)=>{
                    if(url !== 'api/users/auth'){
                        reject(new Error(`Invalid url ${url}`));
                        return;
                    }
                    if (options.data.passHash !== hash) {
                        reject(new Error('Password is not hashed correctly'));
                    }
                    const props = Object.keys(options.data).sort();
                    if (props.length != 2 || props[0] !== 'passHash' || props[1] !== 'username') {
                        reject(new Error('Requested user data is not valid'));
                    }
                    resolve(response);
                });
            });
        });
        afterEach(function () {
            localStorage.removeItem('STORAGE_AUTH_KEY');
            localStorage.removeItem('STORAGE_USERNAME');
            CryptoJS.SHA1.restore();
            app.requester.put.restore();
        });
        
        const hash = 'asjkhfjhafaaafa';

        const response = {
            username: 'User',
            authKey: 'Key'
        };
        const user = {
            username: 'alsdlajdlajdaladsa',
            password: '123'
        };

        it('usersModel.login should resolve correct response', function(done){
            app.usersModel.login(user)
                .then((actual)=>{
                    expect(actual).to.eql(response);
                })
                .then(done, done);
        });

        it('usersModel.login should set localStorage items', function(done){
            app.usersModel.login(user)
                .then((actual)=>{
                    expect(actual.username).to.equal(localStorage.getItem('STORAGE_USERNAME'));
                    expect(actual.authKey).to.equal(localStorage.getItem('STORAGE_AUTH_KEY'));
                })
                .then(done, done);
        });
    });

    describe('usersModel.logout', ()=>{
        it('usersModel.logout should remove items from localStorage', function(done){
            localStorage.setItem('STORAGE_USERNAME', 'User');
            localStorage.setItem('STORAGE_AUTH_KEY', 'Key');
            app.usersModel.logout()
                .then(()=>{
                    expect(localStorage.getItem('STORAGE_AUTH_KEY')).to.equal(null);
                    expect(localStorage.getItem('STORAGE_USERNAME')).to.equal(null);
                })
                .then(done, done);
        });
    });
});

