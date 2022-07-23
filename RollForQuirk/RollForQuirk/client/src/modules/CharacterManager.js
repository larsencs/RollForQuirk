const baseUrl = "api/Character"

export const getCharacterByUserId = (userId) =>{
    return fetch(`${baseUrl}/${userId}`)
        .then(res => res.json())
}

export const addCharacter = (charObj) =>{
    return fetch(baseUrl, {
        method: "POST",
        headers:{
            "Content-Type" : "application/json"
        },
        body: JSON.stringify(charObj)
    }).then(res => res.json())
        
}

export const getCharacterById = (charId) =>{
    return fetch(`${baseUrl}/GetByCharacterId/${charId}`)
        .then(res => res.json())
}

export const editCharacter = (charObj) =>{
    return fetch(`${baseUrl}/${charObj.id}`, {
        method: "PUT",
        headers: {
            "Content-Type" : "application/json"
        },
        body: JSON.stringify(charObj)
    })
}