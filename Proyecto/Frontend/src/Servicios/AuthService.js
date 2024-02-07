class AuthService{
    baseUrl = "https://localhost:7279/";
    UserController = "user";
    
    async GetToken(username, password){
        let options = {
            method: 'POST',
            body: JSON.stringify({
                username: username,
                password: password
            }),
            headers:{
              "Content-Type": "application/json",
            },
            credentials: 'include',
          };

        let response = null;
        try {
            const response = await fetch(`${this.baseUrl}api/${this.UserController}/GetToken`, options)
            const users = await response.json();
            return users;
        } catch (error) {
            console.log(error);
            return response;
        }
    }

    async GetAllUsers(){
        let options = {
            method: 'GET',
            headers:{
              "Content-Type": "application/json",
            },
            credentials: 'include',
          };

        let response = null;
        try {
            const response = await fetch(`${this.baseUrl}api/${this.UserController}/GetAllUsers`, options)
            if(response.status !== 200){
                localStorage.removeItem("loggedIn");
            }
            const users = await response.json();
            return users;
        } catch (error) {
            console.log(error);
            return response;
        }
    }
}

const useAuth = () => {
    //getting token from local storage
    const user = localStorage.getItem('loggedIn')
    //checking whether token is preset or not
    if (user) {
        return true;
    } else {
        return false
    }
};

export {AuthService, useAuth}