class CategoryService{
    baseUrl = "https://localhost:7279/";
    baseController = "Category";
    defaultUserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

    async AddCategory (data) {
        // agregar porpiedad de usuarioId, la cual es necesaria 
        // pero va a ser sobreescrita en el backend
        data.usuarioId = this.defaultUserId;

        let options = {
            method: 'POST',
            body: JSON.stringify(data),
            headers:{
              "Content-Type": "application/json",
            },
            credentials: 'include',
          };

        let response = null;
        try {
            const response = await fetch(`${this.baseUrl}${this.baseController}/Create`, options);
            const category = await response.json();
            return category;
        }
        catch (error) {
            console.log(error);
            return response;
        }
    }

    async UpdateCategory(category) {
        category.usuarioId = this.defaultUserId;

        const url = `${this.baseUrl}${this.baseController}/Update`;
        let options = {
            method: 'PUT',
            body: JSON.stringify(category),
            headers: {
                'Content-Type': 'application/json',
            },
            credentials: 'include',
        }
        let response = null;
        try {
            const response = await fetch(url, options);
            const updatedCategory = await response.json();
            return updatedCategory;
        } catch (error) {
            console.log(error);
            return response;
        }
    }

    async DeleteCategory(id) {

        const url = `${this.baseUrl}${this.baseController}/Delete/${id}`;
        let response = false;

        try {
            const response = await fetch(url, {
                method: 'DELETE',
                credentials: 'include',
            });
            return response;

        } catch (error) {
            console.log(error);
            return response;
        }
    }

    async GetCategories () {
        let response = null;
        try {
            const response = await fetch(`${this.baseUrl}${this.baseController}/GetAll`, {
                credentials: 'include',
            });
            const categories = await response.json();
            return categories;
        } catch (error) {
            console.log(error);
            return response;
        }   
    }
}

export {CategoryService}