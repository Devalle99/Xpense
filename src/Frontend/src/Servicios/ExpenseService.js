class ExpenseService {
    baseUrl = "https://localhost:7279/";
    baseController = "Expense";
    defaultUserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
    defaultDate = "2024-02-08T19:04:33";

    constructor() {
        this.currentDate = new Date();
        // Calcular primer día del mes
        this.firstDayOfMonth = new Date(this.currentDate.getFullYear(), this.currentDate.getMonth(), 1);
        this.firstDayOfMonth = this.firstDayOfMonth.toISOString();

        // Calcular el último día del mes
        this.lastDayOfMonth = new Date(this.currentDate.getFullYear(), this.currentDate.getMonth() + 1, 0);
        this.lastDayOfMonth = this.lastDayOfMonth.toISOString();
    }

    async AddExpense(data) {
        // agregar porpiedad de usuarioId, la cual es necesaria 
        // pero va a ser sobreescrita en el backend
        data.usuarioId = this.defaultUserId;

        let options = {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                "Content-Type": "application/json",
            },
            credentials: 'include',
        };

        let response = null;
        try {
            const response = await fetch(`${this.baseUrl}${this.baseController}/Create`, options)
            const expense = await response.json();
            return expense;
        }
        catch (error) {
            console.log(error);
            return response;
        }
    }

    async UpdateExpense(expense) {
        // agregar porpiedades necesarias
        // pero que van a ser sobreescritas en el backend
        expense.createdAt = this.defaultDate;
        expense.usuarioId = this.defaultUserId;

        const url = `${this.baseUrl}${this.baseController}/Update`;
        let options = {
            method: 'PUT',
            body: JSON.stringify(expense),
            headers: {
                'Content-Type': 'application/json',
            },
            credentials: 'include',
        }
        let response = null;
        try {
            const response = await fetch(url, options);
            const updatedExpense = await response.json();
            return updatedExpense;
        } catch (error) {
            console.log(error);
            return response;
        }
    }

    async DeleteExpense(id) {

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

    async GetExpenses(options = {}) {
        let response = null;
        try {
            // Construir la URL con los parámetros de consulta
            let url = `${this.baseUrl}${this.baseController}/GetAllForUser`;

            if (options) {
                const { orderBy, categoryId, minAmount, startDate, endDate } = options;

                if (orderBy) {
                    url += `?orderBy=${orderBy}`;
                }

                if (categoryId) {
                    url += `${url.includes('?') ? '&' : '?'}categoryId=${categoryId}`;
                }

                if (minAmount) {
                    url += `${url.includes('?') ? '&' : '?'}minAmount=${minAmount}`;
                }

                if (startDate) {
                    url += `${url.includes('?') ? '&' : '?'}startDate=${startDate}`;
                }

                if (endDate) {
                    url += `${url.includes('?') ? '&' : '?'}endDate=${endDate}`;
                }
            }

            const response = await fetch(url, {
                credentials: 'include',
            });
            const expenses = await response.json();
            return expenses;
        } catch (error) {
            console.log(error);
            return response;
        }
    }

    async GetTotals(attribute = "general", categoryId = null, month = null) {
        let response = null;
        try {
            // Construir la URL con los parámetros de consulta
            let url = `${this.baseUrl}${this.baseController}/GetTotalsForUser?attribute=${attribute}`;

            if (categoryId) {
                url += `&categoryId=${categoryId}`;
            }

            if (month) {
                // La fecha debe estar en formato año-mes
                const formattedMonth = month.toISOString().slice(0, 7);
                url += `&month=${formattedMonth}`;
            }

            const response = await fetch(url, {
                credentials: 'include',
            });
            const totals = await response.text();
            return totals;
        } catch (error) {
            console.log(error);
            return response;
        }
    }

    async GetChartData(startDate = this.firstDayOfMonth, endDate = this.lastDayOfMonth) {
        let response = null;
        try {
            // Construir la URL con los parámetros de consulta
            let url = `${this.baseUrl}${this.baseController}/GetTotalsByCategory?startDate=${startDate}&endDate=${endDate}`;

            const response = await fetch(url, {
                credentials: 'include',
            });
            const totals = await response.json();
            return totals;
        } catch (error) {
            console.log(error);
            return response;
        }
    }

}

export { ExpenseService }