const baseUrl = "api/Profession"

export const getAllProfessions = () =>{
    return fetch(baseUrl)
        .then(res => res.json())
}

export const GetProfessionById = (id) =>{
    return fetch(`${baseUrl}/${id}`)
        .then(res => res.json())
}