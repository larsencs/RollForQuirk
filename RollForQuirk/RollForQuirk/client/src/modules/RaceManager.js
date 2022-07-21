const baseUrl = "/api/Race"

export const getAllRaces = () =>{
    return fetch(baseUrl)
        .then(res => res.json())
}

export const getRaceById = (id) =>{
    return fetch(`${baseUrl}/${id}`)
        .then(res => res.json())
}