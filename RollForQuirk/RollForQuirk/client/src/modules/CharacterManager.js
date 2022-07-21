const baseUrl = "api/Character"

export const getCharacterByUserId = (userId) =>{
    return fetch(`${baseUrl}/${userId}`)
        .then(res => res.json())
}