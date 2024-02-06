function Validation(values){
    let error ={}
    const email_pattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
    const password_pattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W)[a-zA-Z0-9\W]{8,}$/

    if(values.email === ""){
        error.email = "Name should not be empty"
    }
    else if (!email_pattern.test(values.email)){
        error.email = "Email Didn't match"
    }else {
        error.email =""
    }

    if(values.password === ""){
        error.password = "Password should not be empty"
    }
    /*
    Quité esta regla de validacion ya que las contraseñas por defecto de 
    la API son "testpassword", lo cual no cumple con el patron de contraseñas.
    De todos modos si un usuario se pudo registrar es porque su contraseña si vale
    
    else if(!password_pattern.test(values.password)){
        error.password = "Password didn't match"
    }
    */
    else{
        error.password =""
    }

    return error;
}

export default Validation;