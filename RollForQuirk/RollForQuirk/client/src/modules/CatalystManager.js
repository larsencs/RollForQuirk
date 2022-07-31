const baseUrl = "api/Catalyst"

export const getCatalyst = () =>{
    return fetch(baseUrl).then(res => res.json())
}