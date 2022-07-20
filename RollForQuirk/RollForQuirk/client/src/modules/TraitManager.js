const baseUrl = "api/Trait"

export const getAllTraits = () =>{
    return fetch(baseUrl)
        .then(res => res.json())
}

export const getTraitbyId = (id) =>{
    return fetch(`${baseUrl}/${id}`)
        .then(res => res.json())
}