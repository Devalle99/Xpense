class CategoryService{
    baseUrl = "https://localhost:7279/"
    baseController = "Category"

    async GetCategories () {
        let response = null;
        try {
            const response =await fetch(`${this.baseUrl}${this.baseController}/GetAll`)
            const categories = await response.json();
            return categories;
        } catch (error) {
            console.log(error);
            return response;
        }
        
    }

    async AddCategory (data) {
        // agregar porpiedad de usuarioId, la cual es necesaria 
        // pero va a ser sobreescrita en el backend
        data.usuarioId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        let options = {
            method: 'POST',
            body: JSON.stringify(data),
            headers:{
              "Content-Type": "application/json",
            }
          };

        let response = null;
        try {
            const response = await fetch(`${this.baseUrl}${this.baseController}/Create`, options)
            const category = await response.json();
            return category;
        }
        catch (error) {
            console.log(error);
            return response;
        }
    }
}

export {CategoryService}