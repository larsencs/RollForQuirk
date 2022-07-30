const baseUrl = "api/Trait"
const stressUrl = "api/Stress"
const fearUrl = "api/Fear"
const flawUrl = "api/Flaw"

export const getFlaw = () =>{
    return fetch(flawUrl).then(res => res.json())
}

export const getFear = () =>{
    return fetch(fearUrl).then(res => res.json())
}

export const getStress = () => {
    return fetch(stressUrl).then(res => res.json())
}




//TO-BE-DELETED Functions
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