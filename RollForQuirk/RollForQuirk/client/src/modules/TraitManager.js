const baseUrl = "api/Trait"

export const getAllTraits = () =>{
    return fetch(baseUrl)
        .then(res => res.json())
}

export const getTraitbyId = (id) =>{
    return fetch(`${baseUrl}/${id}`)
        .then(res => res.json())
}

export const getCount = () =>{
    return fetch(`${baseUrl}/GetCount`)
        .then(res => res.json())
}

export const getRandom = () =>{
    return fetch(`${baseUrl}/GetRandom`)
        .then(res => res.json())
}

export const addTrait = (traitObj) =>{
    return fetch(`${baseUrl}/`, {
        method: "POST",
        headers:{
            "Content-Type" : "application/json"
        },
        body: JSON.stringify(traitObj)
    })
}